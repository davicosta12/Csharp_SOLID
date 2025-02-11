using Alura.Adopet.Console.Atributos;
using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos.Abstracoes;
using FluentResults;

namespace Alura.Adopet.Console.Comandos
{
    [DocComandoAttribute(instrucao: "list-clientes",
    documentacao: "adopet list comando que exibe no terminal o conteúdo cadastrado na base de dados da AdoPet.")]
    public class ListClientes : IComando
    {
        private readonly IApiServices<Cliente> service;

        public ListClientes(IApiServices<Cliente> service)
        {
            this.service = service;
        }

        public async Task<Result> ExecutarAsync()
        {
            try
            {
                IEnumerable<Cliente>? clientes = await service.ListAsync();
                return Result.Ok().WithSuccess(new SuccessWithClientes(clientes, "Listagem de Pet's realizada com sucesso!"));
            }
            catch (Exception exception)
            {

                return Result.Fail(new Error("Listagem falhou!").CausedBy(exception));
            }
        }
    }
}