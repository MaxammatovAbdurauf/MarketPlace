using Microsoft.EntityFrameworkCore;
using System.Net;

namespace MarketPlays.Database.Repositories;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
{
    private readonly AppDbContext context;
    private readonly DbSet<TEntity> DbSet;
    public GenericRepository(AppDbContext _context)
    {
        context = _context;
        DbSet = context.Set<TEntity>();
    }

    //Add
    public async Task AddAsync(TEntity entity)
    {
        await DbSet.AddAsync(entity);
    }

    public async Task AddRange(IEnumerable<TEntity> entities)
    {
        await DbSet.AddRangeAsync(entities);
    }

    //Get
    public async Task <TEntity?> Get(int Id) =>  await DbSet.FindAsync(Id);

    public async Task <TEntity?> Get(Guid Id) => await DbSet.FindAsync(Id);

    public async Task<IEnumerable<TEntity>> GetAll()
    {
        return await DbSet.ToListAsync();
    }

    //Delete
    public void Remove(TEntity entity)
    {
       DbSet.Remove(entity);
    }

    public void RemoveRange(IEnumerable<TEntity> entities)
    {
        DbSet.RemoveRange(entities);
    }

    //Update
    public void Update(TEntity entity)
    {
        DbSet.Update(entity);
    }

    public void UpdateRange (IEnumerable<TEntity> entities)
    {
        DbSet.UpdateRange(entities);
    }
}