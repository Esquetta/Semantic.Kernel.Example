using Codeblaze.SemanticKernel.Connectors.Ollama;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel;

var builder = Kernel.CreateBuilder().AddOllamaChatCompletion("deepseek-r1:latest","http://localhost:11434");

builder.Services.AddScoped<HttpClient>();
var kernel = builder.Build();



while (true)
{
    Console.WriteLine("Ask Question: ");
    string input = Console.ReadLine();
    var response = await kernel.InvokePromptAsync(input);
    Console.WriteLine($"Answer: {response.ToString()}");
}
