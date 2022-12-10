using MarketPlays.Database.IRepositories;
using MarketPlays.Entities;

namespace MarketPlays.Database.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext context;
    private IUserRepository _userRepository { get; set; }
    public IUserRepository userRepository
    {
        get; set;
    }
    public IProductRepository productRepository { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public ICategoryRepository categoryRepository { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public IOrganisationRepository organisationRepository { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public int Save()
    {
        throw new NotImplementedException();
    }
}
