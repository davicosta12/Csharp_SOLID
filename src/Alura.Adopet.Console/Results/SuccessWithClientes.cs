using Alura.Adopet.Console.Modelos;
using FluentResults;

public class SuccessWithClientes : Success
{
    public IEnumerable<Cliente> Data { get; }

    public SuccessWithClientes(IEnumerable<Cliente> data, string mensagem) : base(mensagem)
    {
        Data = data;
    }
}