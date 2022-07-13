namespace CoffeeShopWebApi.Contracts;

public interface IRepositoryBase<T>
{
    void Create(T entity);
    void Update(T entity);
    void Delete(T entity);
    IQueryable<T> FindAll();
    IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
}