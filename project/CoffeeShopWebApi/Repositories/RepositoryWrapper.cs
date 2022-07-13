using CoffeeShopWebApi.Contracts;

namespace CoffeeShopWebApi.Repositories;

public class RepositoryWrapper : IRepositoryWrapper
{
    private RepositoryContext _repositoryContext;
    private ICoffeeRepository _coffee;
    public RepositoryWrapper(RepositoryContext repositoryContext)
    {
        _repositoryContext = repositoryContext;
    }
    public async Task SaveAsync()
    {
        await _repositoryContext.SaveChangesAsync();
    }
    public ICoffeeRepository Coffee
    {
        get
        {
            if (_coffee == null)
            {
                _coffee = new CoffeeRepository(_repositoryContext);
            }
            return _coffee;
        }
    }
}