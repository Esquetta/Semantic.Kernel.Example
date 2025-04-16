using Microsoft.SemanticKernel;

namespace Level6.Filters.Filters
{
    public sealed class EarlyTerminationFilter : IAutoFunctionInvocationFilter
    {
        public async Task OnAutoFunctionInvocationAsync(AutoFunctionInvocationContext context, Func<AutoFunctionInvocationContext, Task> next)
        {
            await next(context);
            var result = context.Result.GetValue<string>();
            if (result == "desired result")
            {
                context.Terminate = true;
            }
        }
    }
}
