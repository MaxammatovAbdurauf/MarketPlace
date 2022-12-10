using System.Linq.Expressions;

namespace MarketPlays.Database.Repositories;

public interface IGenericRepository<TEntity> where TEntity : class
{
    //Get
    Task<TEntity?> Get(int Id);
    Task<TEntity?> Get(Guid id);
    Task<IEnumerable<TEntity>> GetAll();
    //IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> expression);

    //Add
    Task AddAsync(TEntity entity);
    Task AddRange(IEnumerable<TEntity> entity);

    //Update
    void Update(TEntity entity);
    void UpdateRange(IEnumerable<TEntity> entities);

    //Delete
    void Remove(TEntity entity);
    void RemoveRange(IEnumerable<TEntity> entities);
}