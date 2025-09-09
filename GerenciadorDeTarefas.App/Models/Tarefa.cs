namespace GerenciadorDeTarefas.App.Models
{
    /// <summary>
    /// Representa uma tarefa a ser realizada.
    /// </summary>
    public class Tarefa
    {
        // Propriedade para o identificador único da tarefa.
        public int Id { get; set; }

        // Propriedade para o título da tarefa. Não pode ser nulo ou vazio.
        public string Titulo { get; set; }

        // Propriedade para a descrição detalhada da tarefa.
        public string Descricao { get; set; }

        // Propriedade que indica se a tarefa foi concluída ou não.
        public bool Concluida { get; set; }

        // Propriedade para a data de criação da tarefa.
        public DateTime DataCriacao { get; set; }

        /// <summary>
        /// Construtor para criar uma nova tarefa.
        /// </summary>
        /// <param name="id">O ID da tarefa.</param>
        /// <param name="titulo">O título da tarefa.</param>
        /// <param name="descricao">A descrição da tarefa.</param>
        public Tarefa(int id, string titulo, string descricao)
        {
            if (string.IsNullOrWhiteSpace(titulo))
            {
                throw new ArgumentException("O título não pode ser nulo ou vazio.", nameof(titulo));
            }

            Id = id;
            Titulo = titulo;
            Descricao = descricao;
            Concluida = false; // Por padrão, uma nova tarefa não está concluída.
            DataCriacao = DateTime.Now; // Define a data de criação para o momento atual.
        }
    }
}