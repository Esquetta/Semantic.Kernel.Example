using Codeblaze.SemanticKernel.Connectors.Ollama;
using Level5.PluginConfiguration.Plugins;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel;

var builder = Kernel.CreateBuilder().AddOllamaChatCompletion("deepseek-r1:latest", "http://localhost:11434");

builder.Services.AddScoped<HttpClient>();

var kernel = builder.Build();


kernel.Plugins.AddFromType<APlugin>();
kernel.Plugins.AddFromType<BPlugin>();
kernel.Plugins.AddFromType<CPlugin>();

PromptExecutionSettings promptExecutionSettings = new()
{
    FunctionChoiceBehavior = FunctionChoiceBehavior.Auto()
};

#region Given plugin will execute on promt1
PromptExecutionSettings promptExecutionSettings1 = new()
{
    FunctionChoiceBehavior = FunctionChoiceBehavior.Auto(functions: [
        kernel.Plugins.GetFunction(nameof(APlugin), "a"),
        kernel.Plugins.GetFunction(nameof(CPlugin), "c")
        ])
};
#endregion

#region No pluging will add on execution
PromptExecutionSettings promptExecutionSettings2 = new()
{
    FunctionChoiceBehavior = FunctionChoiceBehavior.Auto(functions: [])
};
#endregion

#region We are forcing to ai model to chose one plugin
PromptExecutionSettings promptExecutionSettings3 = new()
{
    FunctionChoiceBehavior = FunctionChoiceBehavior.Required()
};
#endregion

#region No plugin will be executed
PromptExecutionSettings promptExecutionSettings4 = new()
{
    FunctionChoiceBehavior = FunctionChoiceBehavior.None()
};
#endregion


await kernel.InvokePromptAsync("...", new(promptExecutionSettings));

Console.Read();