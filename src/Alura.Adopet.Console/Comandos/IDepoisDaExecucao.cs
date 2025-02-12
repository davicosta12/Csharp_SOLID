using FluentResults;

namespace Alura.Adopet.Console.Comandos
{
    public interface IDepoisDaExecucao
    {
        public event Action<Result>? DepoisDaExecucao;
    }
}