using FilterDemos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FilterDemos
{
    public class ValidationFilterAttribute : ActionFilterAttribute, IActionFilter
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("ValidationFilterAttribute.OnActionExecuted...");
            Console.WriteLine(string.Format("Action Method {0} executing at {1}",
                context.ActionDescriptor.DisplayName,
                DateTime.Now.ToShortDateString())
            );

        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("ValidationFilterAttribute.OnActionExecuting...");
            Console.WriteLine(string.Format("Action Method {0} executing at {1}",
                context.ActionDescriptor.DisplayName,
                DateTime.Now.ToShortDateString())
            );

            var param = context.ActionArguments.SingleOrDefault(p => p.Value is IEntity);
            if (param.Value == null)
            {
                context.Result = new BadRequestObjectResult("Object is null");
                return;
            }
        }
    }
}
