using GerenciadorDeTarefas.App.Models;
using GerenciadorDeTarefas.App.Repositories;

namespace GerenciadorDeTarefas.App.Services
{
    /// <summary>
    /// Serviço para gerenciar as operações de negócio relacionadas a tarefas.
    /// </summary>
    public class TarefaService
    {
        private readonly ITarefaRepository _repositorio;
        private List<Tarefa> _tarefas;

        public TarefaService(ITarefaRepository repositorio)
        {
            _repositorio = repositorio;
            // Carrega as tarefas do repositório ao iniciar o serviço.
            _tarefas = _repositorio.ObterTodas();
        }

        /// <summary>
        /// Adiciona uma nova tarefa à lista.
        /// </summary>
        public void AdicionarTarefa(string titulo, string descricao)
        {
            // Encontra o maior ID existente e adiciona 1 para o novo ID.
            // Usa LINQ (Max) para encontrar o valor máximo. Se a lista estiver vazia, começa com 1.
            int novoId = _tarefas.Any() ? _tarefas.Max(t => t.Id) + 1 : 1;
            
            var novaTarefa = new Tarefa(novoId, titulo, descricao);
            _tarefas.Add(novaTarefa);
            _repositorio.SalvarTodas(_tarefas);
        }

        /// <summary>
        /// Remove uma tarefa com base no seu ID.
        /// </summary>
        public bool RemoverTarefa(int id)
        {
            // Usa LINQ (FirstOrDefault) para encontrar a tarefa com o ID especificado.
            var tarefa = _tarefas.FirstOrDefault(t => t.Id == id);
            if (tarefa != null)
            {
                _tarefas.Remove(tarefa);
                _repositorio.SalvarTodas(_tarefas);
                return true; // Sucesso
            }
            return false; // Tarefa não encontrada
        }

        /// <summary>
        /// Marca uma tarefa como concluída.
        /// </summary>
        public bool MarcarComoConcluida(int id)
        {
            var tarefa = _tarefas.FirstOrDefault(t => t.Id == id);
            if (tarefa != null)
            {
                tarefa.Concluida = true;
                _repositorio.SalvarTodas(_tarefas);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Retorna todas as tarefas.
        /// </summary>
        public List<Tarefa> ListarTodas()
        {
            return _tarefas;
        }

        /// <summary>
        /// Retorna apenas as tarefas pendentes usando LINQ.
        /// </summary>
        public List<Tarefa> ListarPendentes()
        {
            // Usa LINQ (Where) para filtrar as tarefas onde 'Concluida' é false.
            return _tarefas.Where(t => !t.Concluida).ToList();
        }

        /// <summary>
        /// Retorna apenas as tarefas concluídas usando LINQ.
        /// </summary>
        public List<Tarefa> ListarConcluidas()
        {
            // Usa LINQ (Where) para filtrar as tarefas onde 'Concluida' é true.
            return _tarefas.Where(t => t.Concluida).ToList();
        }
    }
}