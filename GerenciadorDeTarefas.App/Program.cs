using GerenciadorDeTarefas.App.Models;
using GerenciadorDeTarefas.App.Services;
using GerenciadorDeTarefas.App.Repositories; 

// Instancia o serviço que contém toda a lógica de negócio.
ITarefaRepository repositorio = new TarefaRepository();
TarefaService servico = new TarefaService(repositorio);
bool executando = true;

// Loop principal do menu da aplicação.
while (executando)
{
    Console.Clear();
    Console.WriteLine("===== Gerenciador de Tarefas =====");
    Console.WriteLine("1. Adicionar Tarefa");
    Console.WriteLine("2. Listar Todas as Tarefas");
    Console.WriteLine("3. Listar Tarefas Pendentes");
    Console.WriteLine("4. Listar Tarefas Concluídas");
    Console.WriteLine("5. Marcar Tarefa como Concluída");
    Console.WriteLine("6. Remover Tarefa");
    Console.WriteLine("7. Sair");
    Console.WriteLine("==================================");
    Console.Write("Escolha uma opção: ");

    // Lê a opção do usuário.
    string? opcao = Console.ReadLine();

    // Estrutura switch para tratar a escolha do usuário.
    switch (opcao)
    {
        case "1":
            AdicionarTarefaUI();
            break;
        case "2":
            ListarTarefasUI(servico.ListarTodas(), "Todas as Tarefas");
            break;
        case "3":
            ListarTarefasUI(servico.ListarPendentes(), "Tarefas Pendentes");
            break;
        case "4":
            ListarTarefasUI(servico.ListarConcluidas(), "Tarefas Concluídas");
            break;
        case "5":
            MarcarTarefaConcluidaUI();
            break;
        case "6":
            RemoverTarefaUI();
            break;
        case "7":
            executando = false;
            Console.WriteLine("Saindo...");
            break;
        default:
            Console.WriteLine("Opção inválida. Pressione qualquer tecla para continuar.");
            Console.ReadKey();
            break;
    }
}

// Método para a interface de adicionar tarefa.
void AdicionarTarefaUI()
{
    Console.Clear();
    Console.WriteLine("--- Adicionar Nova Tarefa ---");
    Console.Write("Título: ");
    string? titulo = Console.ReadLine();
    Console.Write("Descrição: ");
    string? descricao = Console.ReadLine();

    // Validação simples de entrada.
    if (!string.IsNullOrWhiteSpace(titulo) && descricao != null)
    {
        servico.AdicionarTarefa(titulo, descricao);
        Console.WriteLine("Tarefa adicionada com sucesso!");
    }
    else
    {
        Console.WriteLine("Título não pode ser vazio.");
    }
    Pausar();
}

// Método genérico para exibir listas de tarefas.
void ListarTarefasUI(List<Tarefa> tarefas, string titulo)
{
    Console.Clear();
    Console.WriteLine($"--- {titulo} ---");
    if (!tarefas.Any())
    {
        Console.WriteLine("Nenhuma tarefa encontrada.");
    }
    else
    {
        // Itera sobre a lista de tarefas e exibe seus detalhes.
        foreach (var tarefa in tarefas)
        {
            string status = tarefa.Concluida ? "[X]" : "[ ]";
            Console.WriteLine($"{status} ID: {tarefa.Id} - Título: {tarefa.Titulo}");
            Console.WriteLine($"    Descrição: {tarefa.Descricao}");
            Console.WriteLine($"    Criada em: {tarefa.DataCriacao:g}");
            Console.WriteLine("----------------------------------");
        }
    }
    Pausar();
}

// Método para a interface de marcar tarefa como concluída.
void MarcarTarefaConcluidaUI()
{
    Console.Clear();
    Console.WriteLine("--- Marcar Tarefa como Concluída ---");
    Console.Write("Digite o ID da tarefa a ser concluída: ");
    if (int.TryParse(Console.ReadLine(), out int id))
    {
        if (servico.MarcarComoConcluida(id))
        {
            Console.WriteLine("Tarefa marcada como concluída!");
        }
        else
        {
            Console.WriteLine("Tarefa não encontrada.");
        }
    }
    else
    {
        Console.WriteLine("ID inválido.");
    }
    Pausar();
}

// Método para a interface de remover tarefa.
void RemoverTarefaUI()
{
    Console.Clear();
    Console.WriteLine("--- Remover Tarefa ---");
    Console.Write("Digite o ID da tarefa a ser removida: ");
    if (int.TryParse(Console.ReadLine(), out int id))
    {
        if (servico.RemoverTarefa(id))
        {
            Console.WriteLine("Tarefa removida com sucesso!");
        }
        else
        {
            Console.WriteLine("Tarefa não encontrada.");
        }
    }
    else
    {
        Console.WriteLine("ID inválido.");
    }
    Pausar();
}

// Método auxiliar para pausar a execução até o usuário pressionar uma tecla.
void Pausar()
{
    Console.WriteLine("\nPressione qualquer tecla para continuar...");
    Console.ReadKey();
}