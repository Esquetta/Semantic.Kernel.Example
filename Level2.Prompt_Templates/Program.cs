using Codeblaze.SemanticKernel.Connectors.Ollama;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel;

var builder = Kernel.CreateBuilder().AddOllamaChatCompletion("deepseek-r1","http://localhost:11434");

builder.Services.AddScoped<HttpClient>();


var kernel = builder.Build();

// promptTemplates string side is placeholder but $input side is parameter for promt  , InvokeAsync uses for promt and arguements for $input both params $ and instance from kernelArguments params keys must be same

var promptTemplate = "Yanda ki işlemi hesapla : {{$input}}";
var function = kernel.CreateFunctionFromPrompt(promptTemplate);
var arguments = new KernelArguments { ["input"] = "1+2+5*3" };
var result = await function.InvokeAsync(kernel, arguments);
Console.WriteLine(result);
