# API Books 📚

API desenvolvida em ASP.NET Core para gerenciamento de livros. A API permite operações CRUD (Create, Read, Update, Delete) e segue boas práticas RESTful.

## 📌 Funcionalidades
- Criar um novo livro
- Listar todos os livros
- Buscar um livro por ID
- Atualizar um livro
- Atualizar parcialmente um livro
- Excluir um livro
- Verificar os métodos suportados pela API

## 🛠 Tecnologias Utilizadas
- C# com ASP.NET Core
- Entity Framework Core
- PostgreSQL
- Swagger (OpenAPI)

## 🚀 Como Executar o Projeto
### 1️⃣ Pré-requisitos
Certifique-se de ter instalado:
- [.NET 6+](https://dotnet.microsoft.com/en-us/download)
- [PostgreSQL](https://www.postgresql.org/download/)

### 2️⃣ Clonar o repositório
```sh
git clone https://github.com/seu-usuario/API_Books.git
cd API_Books
```

### 3️⃣ Configurar o banco de dados
Altere a string de conexão no `Program.cs` para apontar para seu banco de dados PostgreSQL:
```csharp
builder.Services.AddDbContext<ConnectionContext>(options =>
    options.UseNpgsql("Server=localhost;Port=5432;Database=books_sample;User Id=postgres;Password=123;")
);
```

### 4️⃣ Aplicar migrações
```sh
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### 5️⃣ Executar a API
```sh
dotnet run
```
A API estará disponível em `https://localhost:5001`.

## 📖 Endpoints

### ➤ Criar um livro
**POST** `/api/v0/book`
```json
{
    "nome": "O Senhor dos Anéis",
    "autor": "J.R.R. Tolkien",
    "status": "Disponível"
}
```

### ➤ Listar todos os livros
**GET** `/api/v0/book`

### ➤ Buscar livro por ID
**GET** `/api/v0/book/{id}`

### ➤ Atualizar um livro
**PUT** `/api/v0/book/{id}`
```json
{
    "nome": "O Hobbit",
    "autor": "J.R.R. Tolkien",
    "status": "Emprestado"
}
```

### ➤ Atualizar parcialmente um livro
**PATCH** `/api/v0/book/{id}`
```json
{
    "status": "Disponível"
}
```

### ➤ Excluir um livro
**DELETE** `/api/v0/book/{id}`

### ➤ Métodos suportados pela API
**OPTIONS** `/api/v0/book`

## 🔗 Referências
- [ASP.NET Core Docs](https://learn.microsoft.com/aspnet/core/)
- [Entity Framework Core Docs](https://learn.microsoft.com/ef/core/)
- [PostgreSQL Docs](https://www.postgresql.org/docs/)

---

📌 **Desenvolvido por [JV Pinheiro](https://www.linkedin.com/in/jv-pinheiro)** 🚀
