using MarketPlays.Database;
using MarketPlays.Exceptions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace MarketPlays.Filters;

public class OrganisationExistsFilter : ActionFilterAttribute
{
    public readonly AppDbContext dbContext;

    public OrganisationExistsFilter (AppDbContext _dbContext)
    {
        dbContext = _dbContext;
    }

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (context.ActionArguments.ContainsKey("productId"))
        {
            var guid = (Guid)context.ActionArguments["productId"]!;
            if (!dbContext.Products.Any(x => x.Id == guid))
            {
                throw new notFoundException ("product not exists");
            }
        };
    }
}