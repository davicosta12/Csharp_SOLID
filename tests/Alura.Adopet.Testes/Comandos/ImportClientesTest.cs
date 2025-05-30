using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos.Abstracoes;
using Alura.Adopet.Testes.Builder;
using FluentResults;
using Moq;

namespace Alura.Adopet.Testes.Comandos
{
    public class ImportClientesTest
    {
        [Fact]
        public async Task QuandoClienteEstiverNoArquivoDeveSerImportado()
        {
            //Arrange
            List<Cliente> listaDeClientes = new();
            var cliente = new Cliente(
                id: new Guid("456b24f4-19e2-4423-845d-4a80e8854a99"),
                nome: "Jeni Entity",
                email: "jeni@example.org"
            );
            listaDeClientes.Add(cliente);

            Mock<ILeitorDeArquivos<Cliente>> leitorDeArquivo = listaDeClientes.GetMock();

            Mock<IApiServices<Cliente>> mockService = ApiServiceMockBuilder.GetMock<Cliente>();

            ImportClientes import = new(mockService.Object, leitorDeArquivo.Object);

            //Act
            Result resultado = await import.ExecutarAsync();

            //Assert
            Assert.True(resultado.IsSuccess);
            var sucesso = (SuccessWithClientes)resultado.Successes[0];
            Assert.Equal("Jeni Entity", sucesso.Data.First().Nome);
        }
    }
}