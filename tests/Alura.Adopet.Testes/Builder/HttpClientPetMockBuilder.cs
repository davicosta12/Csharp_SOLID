using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos.Http;
using Moq;

namespace Alura.Adopet.Testes.Builder;

internal static class HttpClientPetMockBuilder
{
    public static Mock<PetService> GetMock()
    {
        var petService = new Mock<PetService>(MockBehavior.Default,
            It.IsAny<HttpClient>());
        return petService;
    }

    public static Mock<PetService> GetMockList(List<Pet> lista)
    {
        var petService = new Mock<PetService>(MockBehavior.Default,
            It.IsAny<HttpClient>());
        petService.Setup(_ => _.ListAsync())
            .ReturnsAsync(lista);
        return petService;
    }

}
