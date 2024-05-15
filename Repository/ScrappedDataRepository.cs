using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class ScrappedDataRepository : RepositoryBase<ScrappedData>, IScrappedDataRepository
    {
        public ScrappedDataRepository(RepositoryContext repositoryContext)
            :base(repositoryContext)
        {
        }

        public void AddProduct(ScrappedData scrappedData)
        {
            
             Create(scrappedData);
        }

        public async Task<IEnumerable<ScrappedData>> GetScrappedDataAsync(bool trackChanges) =>
        
           await FindAll(trackChanges)
                    .OrderBy(e => e.Title)
                    .ToListAsync();

        public async Task<IEnumerable<ScrappedData>>  GetScrapedDataByIdsAsync(IEnumerable<Guid> ids, bool trackChanges)
        {
            return await FindByCondition(x => ids.Contains(x.Id), trackChanges)
            .ToListAsync();
        }            

        public async Task<ScrappedData> GetProductAsync(Guid productId, bool trackChanges) =>
                await FindByCondition(c => c.Id.Equals(productId), trackChanges)
                     .SingleOrDefaultAsync();

        // public async Task<IEnumerable<ScrappedData>>  GetEmployeesAsync(Guid companyId, bool trackChanges) =>
        //     await FindByCondition(c => c.CompanyId.Equals(companyId), trackChanges)
        //            .OrderBy(e => e.Name)
        //            .ToListAsync();


        // public async Task<Employee>  GetEmployeeAsync(Guid companyId, Guid employeeId, bool trackChanges) =>
        //     await FindByCondition(c => c.CompanyId.Equals(companyId) && c.Id.Equals(employeeId), trackChanges)
        //           .SingleOrDefaultAsync();

        // public void CreateEmployee(Guid companyId, Employee employee){
        //     employee.CompanyId = companyId;
        //     Create(employee);
        // }

        // public void DeleteEmployee(Employee employee)
        // {
        //     Delete(employee);
        // }



        





        public void DeleteProduct(ScrappedData scrappedData)
        {
            throw new NotImplementedException();
        }


    }
}
