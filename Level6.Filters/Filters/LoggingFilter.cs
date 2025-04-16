using Microsoft.SemanticKernel;

namespace Level6.Filters.Filters
{
    public sealed class LoggingFilter : IFunctionInvocationFilter
    {
        public async Task OnFunctionInvocationAsync(FunctionInvocationContext context, Func<FunctionInvocationContext, Task> next)
        {
            Console.WriteLine($"Çalıştırılıyor = Eklenti Adı : {context.Function.PluginName} | Fonksiyon Adı : {context.Function.Name}");
            await next(context);
            Console.WriteLine($"Çalışırıldı = Eklenti Adı: {context.Function.PluginName} | Fonksiyon Adı: {context.Function.Name}");
        }
    }
}
