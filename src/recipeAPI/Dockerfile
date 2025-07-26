FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /source
COPY *sln .
COPY src/recipeAPI/recipeAPI.csproj ./src/recipeAPI/
RUN dotnet restore src/recipeAPI/recipeAPI.csproj


COPY . ./

RUN dotnet publish -c release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "recipeAPI.dll"]
