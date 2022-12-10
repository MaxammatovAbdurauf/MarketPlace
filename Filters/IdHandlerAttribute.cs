using MarketPlays.Database;
using MarketPlays.Exceptions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using MarketPlays.Entities;

namespace MarketPlays.Filters;

public class IdHandlerAttribute : ActionFilterAttribute
{
    private readonly AppDbContext dbContext;
    public IdHandlerAttribute (AppDbContext _dbContext)
    {
        dbContext = _dbContext;
    }
public override void OnActionExecuting(ActionExecutingContext context)
    { 
        base.OnActionExecuting(context);

        if (context.ActionArguments.TryGetValue("Id", out object? Id))
        {
           
        }


        if (context.ActionArguments.TryGetValue ("productId",out object? productId))
        {
            if (productId != null && Guid.TryParse(productId.ToString(), out Guid _productId))
            {
                var product = dbContext.Products.FirstOrDefaultAsync(p => p.Id == _productId);
                if (product is null)
                {
                    throw new NotFoundException<Product> ();
                }
            }
        }

        if (context.ActionArguments.TryGetValue("categoryId", out object? categoryId))
        {
            if (categoryId != null && int.TryParse(categoryId.ToString(), out int _categoryId))
            {
                var category = dbContext.Categories.FirstOrDefaultAsync(c => c.Id == _categoryId);
                if (category is null)
                {
                    throw new NotFoundException<Category>();
                }
            }
        }

        if (context.ActionArguments.TryGetValue("orgId", out object? orgId))
        {
            if (productId != null && Guid.TryParse(productId.ToString(), out Guid _orgId))
            {
                var org = dbContext.Organisations.FirstOrDefaultAsync(o => o.Id == _orgId);
                if (org is null)
                {
                    throw new NotFoundException<Organisation>();
                }
            }
        }

        if (context.ActionArguments.TryGetValue("userId", out object? userId))
        {
            if (userId != null && Guid.TryParse(userId.ToString(), out Guid _userId))
            {
                var user = dbContext.Organisations.FirstOrDefaultAsync(u => u.Id == _userId);
                if (user is null)
                {
                    throw new NotFoundException<AppUser>();
                }
            }
        }
    }
}