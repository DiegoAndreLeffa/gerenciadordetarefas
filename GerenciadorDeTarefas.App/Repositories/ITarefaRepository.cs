using GerenciadorDeTarefas.App.Models;

namespace GerenciadorDeTarefas.App.Repositories
{
    public interface ITarefaRepository
    {
        List<Tarefa> ObterTodas();
        void SalvarTodas(List<Tarefa> tarefas);
    }
}