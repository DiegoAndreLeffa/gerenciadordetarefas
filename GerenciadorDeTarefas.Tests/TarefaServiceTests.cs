using Xunit;
using System.Collections.Generic;
using GerenciadorDeTarefas.App.Models;
using GerenciadorDeTarefas.App.Services;
using GerenciadorDeTarefas.App.Repositories;
using System.Linq;

namespace GerenciadorDeTarefas.Tests
{
    // Um repositório "fake" que funciona em memória para isolar os testes do sistema de arquivos.
    public class TarefaRepositoryMock : ITarefaRepository
    {
        private List<Tarefa> _bancoDeDadosFake = new List<Tarefa>();

        public List<Tarefa> ObterTodas()
        {
            // Retorna uma cópia para evitar que o serviço modifique a lista interna do mock diretamente.
            return new List<Tarefa>(_bancoDeDadosFake);
        }

        public void SalvarTodas(List<Tarefa> tarefas)
        {
            // Simula o salvamento, substituindo a lista interna pela nova.
            _bancoDeDadosFake = tarefas;
        }
    }

    public class TarefaServiceTests
    {
        // O atributo [Fact] indica que este é um método de teste.
        [Fact]
        public void AdicionarTarefa_DeveAumentarAListaDeTarefas()
        {
            // Arrange (Preparação)
            var repoMock = new TarefaRepositoryMock();
            var service = new TarefaService(repoMock);
            var titulo = "Testar aplicação";
            var descricao = "Criar testes unitários.";

            // Act (Ação)
            service.AdicionarTarefa(titulo, descricao);
            var tarefas = service.ListarTodas();

            // Assert (Verificação)
            Assert.Single(tarefas); // Verifica se há exatamente 1 item na lista.
            Assert.Equal(titulo, tarefas.First().Titulo); // Verifica se o título está correto.
        }

        [Fact]
        public void RemoverTarefa_ComIdExistente_DeveDiminuirALista()
        {
            // Arrange
            var repoMock = new TarefaRepositoryMock();
            var service = new TarefaService(repoMock);
            service.AdicionarTarefa("Tarefa 1", "Desc 1");

            // Act
            bool resultado = service.RemoverTarefa(1);
            var tarefas = service.ListarTodas();

            // Assert
            Assert.True(resultado); // Verifica se a operação retornou sucesso.
            Assert.Empty(tarefas); // Verifica se a lista está vazia.
        }

        [Fact]
        public void MarcarComoConcluida_DeveAlterarOStatusDaTarefa()
        {
            // Arrange
            var repoMock = new TarefaRepositoryMock();
            var service = new TarefaService(repoMock);
            service.AdicionarTarefa("Tarefa para concluir", "Desc");

            // Act
            service.MarcarComoConcluida(1);
            var tarefa = service.ListarTodas().First();

            // Assert
            Assert.True(tarefa.Concluida); // Verifica se o status da tarefa mudou para true.
        }
    }
}