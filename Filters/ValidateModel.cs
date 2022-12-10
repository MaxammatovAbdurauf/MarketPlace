using Microsoft.AspNetCore.Mvc.Filters;

namespace MarketPlays.Filters;

public class ValidateModel : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        base.OnActionExecuting(context);

        if (!context.ModelState.IsValid)
        {
            throw new Exception("DTO is not valid");
        }
    }
}