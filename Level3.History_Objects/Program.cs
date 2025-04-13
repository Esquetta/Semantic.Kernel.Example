using Codeblaze.SemanticKernel.Connectors.Ollama;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;

var builder = Kernel.CreateBuilder().AddOllamaChatCompletion("deepseek-r1:latest", "http://localhost:11434");

builder.Services.AddScoped<HttpClient>();
var kernel = builder.Build();

var history = new ChatHistory();

history.AddUserMessage("Merhaba bu gün hava nasıl");

var chatCompletionService = kernel.GetRequiredService<IChatCompletionService>();
var response = await chatCompletionService.GetChatMessageContentsAsync(history);
history.AddAssistantMessage(response.ToString());

history.AddUserMessage("Peki hafta önümüzde ki hafta için tahminler nasıl?");
var response2 = await chatCompletionService.GetChatMessageContentsAsync(history);
history.AddAssistantMessage(response2.ToString());

Console.WriteLine(response2.First().Content);

Console.Read();

