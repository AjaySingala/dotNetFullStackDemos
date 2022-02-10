using Microsoft.AspNetCore.Mvc.Filters;

namespace FilterDemos
{
    public class SampleActionFilterAsync : ActionFilterAttribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context,
            ActionExecutionDelegate next)
        {
            // execute any code before the action executes.
            Console.WriteLine("SampleActionFilterAsync.OnActionExecutionAsync Before...");
            Console.WriteLine(string.Format("Action Method {0} executing at {1}",
                context.ActionDescriptor.DisplayName,
                DateTime.Now.ToShortDateString())
            );

            var result = await next();

            // execute any code after the action executes
            Console.WriteLine("SampleActionFilterAsync.OnActionExecutionAsync After...");
            Console.WriteLine($"result: {result.ActionDescriptor.DisplayName}");
            Console.WriteLine(string.Format("Action Method {0} executing at {1}",
                context.ActionDescriptor.DisplayName,
                DateTime.Now.ToShortDateString())
            );
        }
    }
}
