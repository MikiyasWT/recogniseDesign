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

        public async Task<ScrappedData> GetProductAsync(Guid productId, bool trackChanges)
        {
            return await FindByCondition(c => c.Id.Equals(productId), trackChanges)
                     .SingleOrDefaultAsync();
        }

        public void DeleteProduct(ScrappedData scrappedData)
        {
            Delete(scrappedData);
        }


    }
}
