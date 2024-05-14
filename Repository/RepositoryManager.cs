using Contracts;
using Entities;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private RepositoryContext _repositoryContext;

        private IScrappedDataRepository _scrappedDataRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }


        public IScrappedDataRepository ScrappedData
                {
            get
            {
                if (_scrappedDataRepository == null)
                    _scrappedDataRepository = new ScrappedDataRepository(_repositoryContext);

                return _scrappedDataRepository;
            }
        }

        public Task SaveAsync() => _repositoryContext.SaveChangesAsync();
    }
}