using Alura.Adopet.Console.Servicos.Arquivos;
using Alura.Adopet.Console.Servicos.Http;

namespace Alura.Adopet.Console.Comandos;

public class ImportFactory : IComandoFactory
{
    public bool ConsegueCriarOTipo(Type? tipoComando)
    {
        return tipoComando?.IsAssignableTo(typeof(Import)) ?? false;
    }

    public IComando? CriarComando(string[] argumentos)
    {
        var petService = new PetService(new AdopetAPIClientFactory().CreateClient("adopet"));
        var leitorDeArquivos = LeitorDeArquivosFactory.CreatePetFrom(argumentos[1]);
        if (leitorDeArquivos is null) return null;
        return new Import(petService, leitorDeArquivos);
    }
}