# RecipeAPI
## Descrição

Essa API permite o gerenciamento de receitas e ingredientes. 
É possível criar, listar, atualizar e deletar receitas e ingredientes, além de buscar receitas que possuem vários ingredientes associados, com quantidade e unidade.

```text
+-------------------+         +---------------------+        +-------------------+
|    Recipe         | 1     * |   RecipeItem        | *    1 |   Ingredient       |
+-------------------+         +---------------------+        +-------------------+
| Id                |         | Id                  |        | Id                |
| Name              |         | RecipeId (FK)       |        | Name              |
| Instructions      |         | IngredientId (FK)   |        | Unit              |
+-------------------+         | Quantity            |        +-------------------+
                              +---------------------+
```
## Funcionalidades principais

- CRUD completo de receitas:
  - Criar, listar, buscar por ID, atualizar e deletar
- CRUD completo de ingredientes:
  - Criar, listar, buscar por ID, atualizar e deletar
- Buscar receitas por ingrediente