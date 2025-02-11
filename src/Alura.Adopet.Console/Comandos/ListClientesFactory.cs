using Alura.Adopet.Console.Servicos.Http;

namespace Alura.Adopet.Console.Comandos;

public class ListClientesFactory : IComandoFactory
{
    public bool ConsegueCriarOTipo(Type? tipoComando)
    {
        return tipoComando?.IsAssignableTo(typeof(ListClientes)) ?? false;
    }

    public IComando? CriarComando(string[] argumentos)
    {
        var clienteService = new ClienteService(
            new AdopetAPIClientFactory()
            .CreateClient("adopet list comando que exibe no terminal o conteúdo cadastrado na base de dados da AdoPet.")
        );
        
        return new ListClientes(clienteService);
    }
}