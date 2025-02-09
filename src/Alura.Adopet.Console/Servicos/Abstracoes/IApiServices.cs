namespace Alura.Adopet.Console.Servicos.Abstracoes
{
    public interface IApiServices<T>
    {
        Task CreateAsync(T pet);
        Task<IEnumerable<T>?> ListAsync();
    }
}