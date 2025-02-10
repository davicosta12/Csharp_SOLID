using Alura.Adopet.Console.Servicos.Abstracoes;
using Moq;

namespace Alura.Adopet.Testes.Builder
{
    public static class ApiServiceMockBuilder
    {
        public static Mock<IApiServices<T>> GetMock<T>()
        {
            return new Mock<IApiServices<T>>();
        }
    }
}