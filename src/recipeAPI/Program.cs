using Microsoft.EntityFrameworkCore;
using recipeAPI.Data;
using recipeAPI.Services.Ingredient;
using recipeAPI.Services.Recipe;
using OpenTelemetry;
using OpenTelemetry.Trace;
using OpenTelemetry.Logs;
using OpenTelemetry.Resources;
using OpenTelemetry.Metrics;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IRecipeInterface, RecipeService>();
builder.Services.AddScoped<IIngrendientInterface, IngredientService>();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});


builder.Services.AddOpenTelemetry()
    .WithTracing(tracing => tracing
        // The rest of your setup code goes here
        .AddOtlpExporter()
        .AddAspNetCoreInstrumentation()
        .AddHttpClientInstrumentation())
    .WithMetrics(metrics => metrics
        // The rest of your setup code goes here
        .AddPrometheusExporter()
        .AddAspNetCoreInstrumentation()
        .AddHttpClientInstrumentation());

builder.Logging.AddOpenTelemetry(logging => {
    // The rest of your setup code goes here
    logging.AddOtlpExporter();
});


builder.Logging.AddConsole();
builder.Logging.AddOpenTelemetry(options =>
{
    options.IncludeFormattedMessage = true;
    options.SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("recipeAPI"));
    options.AddOtlpExporter(opt =>
    {
        opt.Endpoint = new Uri("http://loki:3100/otlp/v1/logs");
    });
}); 




var app = builder.Build();

var logger = app.Services.GetRequiredService<ILogger<Program>>();
logger.LogInformation("Iniciando aplicação com OpenTelemetry.");

app.UseDefaultFiles(); // Ativa index.html automaticamente
app.UseStaticFiles();  // Serve arquivos da pasta wwwroot
                       // Teste de lint no Pull Request

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    Console.WriteLine("Aplicando migrations...");
    db.Database.Migrate();
    Console.WriteLine("Migrations aplicadas com sucesso.");
}

app.UseHttpsRedirection();
app.UseOpenTelemetryPrometheusScrapingEndpoint();

app.UseAuthorization();

app.MapControllers();

app.Run();
