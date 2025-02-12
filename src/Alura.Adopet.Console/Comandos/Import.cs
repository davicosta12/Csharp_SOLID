using Alura.Adopet.Console.Atributos;
using FluentResults;
using Alura.Adopet.Console.Results;
using Alura.Adopet.Console.Servicos.Abstracoes;
using Alura.Adopet.Console.Modelos;

namespace Alura.Adopet.Console.Comandos
{
    [DocComandoAttribute(instrucao: "import",
        documentacao: "adopet import <ARQUIVO> comando que realiza a importação do arquivo de pets.")]
    public class Import : IComando, IDepoisDaExecucao, ITrabalhoEmProgresso
    {
        private readonly IApiServices<Pet> clientPet;

        private readonly ILeitorDeArquivos<Pet> leitor;

        public Import(IApiServices<Pet> clientPet, ILeitorDeArquivos<Pet> leitor)
        {
            this.clientPet = clientPet;
            this.leitor = leitor;
        }

        public event Action<Result>? DepoisDaExecucao;
        public event Action<int, int> ProgressChanged;

        public async Task<Result> ExecutarAsync()
        {
            return await this.ImportacaoArquivoPetAsync();
        }

        private async Task<Result> ImportacaoArquivoPetAsync()
        {
            try
            {
                var listaDePet = leitor.RealizaLeitura();
                int i = 0;
                foreach (var pet in listaDePet)
                {
                    i++;
                    await clientPet.CreateAsync(pet);
                    OnProgressChanged(i, listaDePet.Count());
                }
                var resultado = Result.Ok().WithSuccess(new SuccessWithPets(listaDePet, "Importação Realizada com Sucesso!"));
                DepoisDaExecucao?.Invoke(resultado);
                return resultado;
            }
            catch (Exception exception)
            {

                return Result.Fail(new Error("Importação falhou!").CausedBy(exception));
            }
        }

        private void OnProgressChanged(int i, int total)
        {
            ProgressChanged?.Invoke(i, total);
            Thread.Sleep(100);
        }
    }
}
