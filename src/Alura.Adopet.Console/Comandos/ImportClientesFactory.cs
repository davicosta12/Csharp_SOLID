using Alura.Adopet.Console.Servicos.Arquivos;
using Alura.Adopet.Console.Servicos.Http;

namespace Alura.Adopet.Console.Comandos;

public class ImportClientesFactory : IComandoFactory
{
    public bool ConsegueCriarOTipo(Type? tipoComando)
    {
        return tipoComando?.IsAssignableTo(typeof(ImportClientes)) ?? false;
    }

    public IComando? CriarComando(string[] argumentos)
    {
        var clienteService = new ClienteService(new AdopetAPIClientFactory().CreateClient("adopet"));
        var leitorDeArquivosCliente = LeitorDeArquivosFactory.CreateClienteFrom(argumentos[1]);
        if (leitorDeArquivosCliente is null) return null;
        return new ImportClientes(clienteService, leitorDeArquivosCliente);
    }
}
