using System.Text.Json;
using GerenciadorDeTarefas.App.Models;

namespace GerenciadorDeTarefas.App.Repositories
{
    /// <summary>
    /// Repositório para gerenciar a persistência das tarefas em um arquivo JSON.
    /// </summary>
    public class TarefaRepository: ITarefaRepository 
    {
        // Caminho do arquivo JSON onde as tarefas serão armazenadas.
        private readonly string _caminhoArquivo;

        public TarefaRepository(string caminhoArquivo = "tarefas.json")
        {
            _caminhoArquivo = caminhoArquivo;
        }

        /// <summary>
        /// Lê todas as tarefas do arquivo JSON.
        /// </summary>
        /// <returns>Uma lista de tarefas.</returns>
        public List<Tarefa> ObterTodas()
        {
            // Verifica se o arquivo não existe. Se não, retorna uma lista vazia.
            if (!File.Exists(_caminhoArquivo))
            {
                return new List<Tarefa>();
            }

            // Lê todo o conteúdo do arquivo.
            string json = File.ReadAllText(_caminhoArquivo);
            
            // Desserializa o JSON para uma lista de objetos Tarefa.
            return JsonSerializer.Deserialize<List<Tarefa>>(json) ?? new List<Tarefa>();
        }

        /// <summary>
        /// Salva uma lista de tarefas no arquivo JSON.
        /// </summary>
        /// <param name="tarefas">A lista de tarefas a ser salva.</param>
        public void SalvarTodas(List<Tarefa> tarefas)
        {
            // Configurações para formatar o JSON de forma legível (indentado).
            var options = new JsonSerializerOptions { WriteIndented = true };
            
            // Serializa a lista de tarefas para uma string JSON.
            string json = JsonSerializer.Serialize(tarefas, options);
            
            // Escreve a string JSON no arquivo, sobrescrevendo o conteúdo existente.
            File.WriteAllText(_caminhoArquivo, json);
        }
    }
}