using Codeblaze.SemanticKernel.Connectors.Ollama;
using Level1.Essentials.ViewModels;
using Microsoft.SemanticKernel.ChatCompletion;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddKernel().AddOllamaChatCompletion("deepseek-r1", "http://localhost:11434");
builder.Services.AddRequestTimeouts();
builder.Services.AddHttpClient();
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseRequestTimeouts();
app.UseAuthorization();

app.MapPost("/chat", async(IChatCompletionService chatCompletionService,ChatModel chatModel) =>
{
    var response = await chatCompletionService.GetChatMessageContentAsync(chatModel.Input);
    return response.ToString();
}).WithRequestTimeout(TimeSpan.FromMinutes(10));

app.MapControllers();

app.Run();
