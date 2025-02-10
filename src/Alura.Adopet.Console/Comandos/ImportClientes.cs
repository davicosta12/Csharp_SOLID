using System.Text.Json;
using Alura.Adopet.Console.Atributos;
using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos.Abstracoes;
using FluentResults;

namespace Alura.Adopet.Console.Comandos
{
    [DocComandoAttribute(instrucao: "import-clientes",
     documentacao: "adopet import-clientes <ARQUIVO> comando que realiza a importação do arquivo de clientes.")]
    public class ImportClientes : IComando
    {
        private IApiServices<Cliente> apiService;
        private ILeitorDeArquivos<Cliente> leitor;

        public ImportClientes(IApiServices<Cliente> apiService, ILeitorDeArquivos<Cliente> leitor)
        {
            this.apiService = apiService;
            this.leitor = leitor;
        }

        public async Task<Result> ExecutarAsync()
        {
            try
            {
                var lista = leitor.RealizaLeitura();
                foreach (var cliente in lista)
                {
                    await apiService.CreateAsync(cliente);
                }
                return Result.Ok().WithSuccess(new SuccessWithClientes(lista, "Importação Realizada com Sucesso!"));
            }
            catch (Exception exception)
            {
                return Result.Fail(new Error("Importação falhou!").CausedBy(exception));
            }
        }
    }
}