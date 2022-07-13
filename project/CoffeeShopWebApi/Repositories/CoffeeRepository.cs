using Microsoft.EntityFrameworkCore;

namespace CoffeeShopWebApi.Repositories
{
    public class CoffeeRepository : RepositoryBase<Coffee>, ICoffeeRepository
    {
        public CoffeeRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
        public void CreateCoffee(Coffee coffee) => Create(coffee);
        public void UpdateCoffee(Coffee coffee) => Update(coffee);
        public void DeleteCoffee(Coffee coffee) => Delete(coffee);
        public async Task<IEnumerable<Coffee>> GetAllCoffees() => await FindAll().OrderBy(c => c.Name).ToListAsync();
        public async Task<Coffee> GetCoffee(string value)
        {
            var isGuid = Guid.TryParse(value, out Guid guid);
            if (isGuid)
                return await FindByCondition(coffee => coffee.Id.Equals(guid)).FirstOrDefaultAsync();
            return await FindByCondition(coffee => coffee.Name.Contains(value)).FirstOrDefaultAsync();
        }
    }
}