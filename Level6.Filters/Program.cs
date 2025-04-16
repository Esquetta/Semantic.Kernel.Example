using Codeblaze.SemanticKernel.Connectors.Ollama;
using Level6.Filters.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel;

var builder = Kernel.CreateBuilder().AddOllamaChatCompletion("deepseek-r1:latest", "http://localhost:11434");


builder.Services.AddScoped<HttpClient>();

builder.Services.AddSingleton<IFunctionInvocationFilter, LoggingFilter>();
builder.Services.AddSingleton<IPromptRenderFilter, SafePromptFilter>();
builder.Services.AddSingleton<IAutoFunctionInvocationFilter, EarlyTerminationFilter>();
var kernel = builder.Build();

kernel.FunctionInvocationFilters.Add(new LoggingFilter());
kernel.PromptRenderFilters.Add(new SafePromptFilter());
kernel.AutoFunctionInvocationFilters.Add(new EarlyTerminationFilter());