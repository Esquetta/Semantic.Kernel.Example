using Microsoft.SemanticKernel;

namespace Level6.Filters.Filters
{
    public sealed class SafePromptFilter : IPromptRenderFilter
    {
        public async Task OnPromptRenderAsync(PromptRenderContext context, Func<PromptRenderContext, Task> next)
        {
            await next(context);
            context.RenderedPrompt = "3 + 5 sonucu kaçtır?";
        }
    }
}
