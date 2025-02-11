using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos.Http;
using Alura.Adopet.Console.Settings;
using Alura.Adopet.TestesIntegracao.Builder;

namespace Alura.Adopet.TestesIntegracao;

public class ImportIntegrationTest
{

    [Fact]
    public async void QuandoAPIEstaNoArDeveRetornarListaDePet()
    {
        //Arrange
        var listaDePet = new List<Pet>();
        var pet = new Pet(new Guid("456b24f4-19e2-4423-845d-4a80e8854a41"),
              "Lima", TipoPet.Cachorro); //"456b24f4-19e2-4423-845d-4a80e8854a41;Lima Limão;1";
        listaDePet.Add(pet);
        var leitorDeArquivo = LeitorDeArquivosMockBuilder.GetMock(listaDePet);       
          var petService = new PetService(new AdopetAPIClientFactory(Configurations.ApiSetting.Uri).CreateClient("adopet"));
        var import = new Import(petService,leitorDeArquivo.Object);
         
        //Act
        await import.ExecutarAsync();
        
        //Assert
        var listaPet = await petService.ListAsync();
        Assert.NotNull(listaPet);
    }
}
