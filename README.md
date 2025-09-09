# 🚀 Gerenciador de Tarefas em C #

Um simples, porém robusto, sistema de gerenciamento de tarefas (To-Do List) desenvolvido como um Console App em C# (.NET), focado em demonstrar boas práticas de programação, arquitetura e testes.

## ✨ Funcionalidades

* **Adicionar Tarefas**: Crie novas tarefas com título e descrição.
* **Listar Tarefas**: Visualize todas as tarefas, ou filtre por pendentes e concluídas.
* **Marcar como Concluída**: Altere o status de uma tarefa para concluída.
* **Remover Tarefas**: Exclua tarefas da lista.
* **Persistência de Dados**: As tarefas são salvas em um arquivo `tarefas.json`, garantindo que os dados não sejam perdidos ao fechar a aplicação.

## 🛠️ Tecnologias e Conceitos Aplicados

* **Linguagem**: C# 10
* **Plataforma**: .NET 6
* **Testes**: xUnit
* **Persistência**: Arquivo JSON
* **Manipulação de Dados**: LINQ para filtros e consultas em coleções.
* **Princípios de OOP**: Encapsulamento, Abstração.
* **Princípios SOLID**:
  * **SRP (Single Responsibility Principle)**: As classes `TarefaService`, `TarefaRepository` e a UI do console têm responsabilidades bem definidas.
  * **DIP (Dependency Inversion Principle)**: O `TarefaService` depende de uma abstração (`ITarefaRepository`), permitindo a Injeção de Dependência e facilitando os testes.

## 📂 Estrutura do Projeto

```
/
├── GerenciadorDeTarefas.App/     # Projeto principal (Console App)
│   ├── Models/                   # Contém a classe de domínio `Tarefa`.
│   ├── Repositories/             # Classes responsáveis pelo acesso a dados (leitura/escrita JSON).
│   ├── Services/                 # Classes com a lógica de negócio (CRUD).
│   └── Program.cs                # Interface do usuário (UI) do console.
│
├── GerenciadorDeTarefas.Tests/   # Projeto de testes unitários
│   └── TarefaServiceTests.cs     # Testes para a classe de serviço.
│
├── GerenciadorDeTarefas.sln      # Arquivo da solução.
└── README.md                     # Este arquivo.
```

## 🚀 Como Executar

### Pré-requisitos

* [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0) ou superior.

### Rodando a Aplicação

1. Clone o repositório:

    ```bash
    git clone https://github.com/SEU_USUARIO/GerenciadorDeTarefas.git
    cd GerenciadorDeTarefas
    ```

2. Navegue até a pasta do projeto principal:

    ```bash
    cd GerenciadorDeTarefas.App
    ```

3. Execute a aplicação:

    ```bash
    dotnet run
    ```

### Rodando os Testes

Para verificar a integridade da lógica de negócio, execute os testes unitários a partir da pasta raiz do projeto:

```bash
dotnet test
```

## 📝 Autor

* **Diego** 
