using Entities.Models;

namespace Contracts
{
    public interface IScrappedDataRepository {
      Task<IEnumerable<ScrappedData>>  GetScrappedDataAsync(bool trackChanges);
      Task<ScrappedData> GetProductAsync(Guid productId,bool trackChanges);

      void AddProduct(ScrappedData scrappedData);
      void DeleteProduct(ScrappedData scrappedData);

      Task<IEnumerable<ScrappedData>> GetScrapedDataByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);

    //   void CreateEmployee(Guid companyId, Employee employee);

    //   void DeleteEmployee(Employee employee);
    }
}



