using Microsoft.AspNetCore.Mvc.Filters;

namespace FilterDemos
{
    public class SampleActionFilter : ActionFilterAttribute, IActionFilter
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("SampleActionFilter.OnActionExecuted...");
            Console.WriteLine(string.Format("Action Method {0} executing at {1}", 
                context.ActionDescriptor.DisplayName, 
                DateTime.Now.ToShortDateString())
            );

        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("SampleActionFilter.OnActionExecuting...");
            Console.WriteLine(string.Format("Action Method {0} executing at {1}",
                context.ActionDescriptor.DisplayName,
                DateTime.Now.ToShortDateString())
            );
        }
    }
}
