using Entities.Models;

namespace Contracts
{
    public interface IScrappedDataRepository {
      Task<IEnumerable<ScrappedData>>  GetScrappedDataAsync(bool trackChanges);
      Task<ScrappedData> GetEmployeeAsync(Guid productId,bool trackChanges);

      void AddProduct(ScrappedData scrappedData);
      void DeleteProduct(ScrappedData scrappedData);

    //   void CreateEmployee(Guid companyId, Employee employee);

    //   void DeleteEmployee(Employee employee);
    }
}



