using System.Text.Json;
using Alura.Adopet.Console.Servicos.Abstracoes;

namespace Alura.Adopet.Console.Servicos.Arquivos
{
    public class LeitorDeArquivoJson<T> : ILeitorDeArquivos<T>
    {
        private string caminhoArquivo;

        public LeitorDeArquivoJson(string caminhoArquivo)
        {
            this.caminhoArquivo = caminhoArquivo;
        }

        public IEnumerable<T> RealizaLeitura()
        {
            if (string.IsNullOrEmpty(caminhoArquivo))
            {
                return null;
            }
            using var stream = new FileStream(caminhoArquivo, FileMode.Open, FileAccess.Read);
            return JsonSerializer.Deserialize<IEnumerable<T>>(stream) ?? Enumerable.Empty<T>();
        }
    }
}