using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos.Abstracoes;
using Alura.Adopet.Console.Servicos.Arquivos;

namespace Alura.Adopet.Testes.Servicos
{
    public class LeitorDeArquivosFactoryTest
    {
        [Fact]
        public void QuantoExtensaoForCsvDeveRetornarTipoLeitorDeArquivoCsv()
        {
            //Arrange          
            string caminhoArquivo = "pets.csv";
            ILeitorDeArquivos<Pet>? leitorDeArquivos = LeitorDeArquivosFactory.CreatePetFrom(caminhoArquivo);
            //Assert
            Assert.IsType<PetsDoCsv>(leitorDeArquivos);
        }

        [Fact]
        public void QuantoExtensaoForJsonDeveRetornarTipoLeitorDeArquivoJson()
        {
            //Arrange          
            string caminhoArquivo = "pets.json";
            //Act
            ILeitorDeArquivos<Pet>? leitorDeArquivos = LeitorDeArquivosFactory.CreatePetFrom(caminhoArquivo);
            //Assert

            Assert.IsType<LeitorDeArquivoJson<Pet>>(leitorDeArquivos);
        }

        [Fact]
        public void QuantoExtensaoNaoSuportadaDeveRetornarNulo()
        {
            //Arrange          
            string caminhoArquivo = "pets.html";
            //Act
            ILeitorDeArquivos<Pet>? leitorDeArquivos = LeitorDeArquivosFactory.CreatePetFrom(caminhoArquivo);
            //Assert
            Assert.Null(leitorDeArquivos);
        }
    }
}