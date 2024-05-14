namespace Contracts
{
    public interface IRepositoryManager
    {
        IScrappedDataRepository ScrappedData {get;}

        Task SaveAsync();
    }
}