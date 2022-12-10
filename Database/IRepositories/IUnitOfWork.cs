namespace MarketPlays.Database.IRepositories;

public interface IUnitOfWork 
{
    public IUserRepository userRepository { get; set; }
    public IProductRepository productRepository { get; set; }
    public ICategoryRepository categoryRepository { get; set; }
    public IOrganisationRepository organisationRepository { get; set; }
    int Save();
}
