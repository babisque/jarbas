namespace Jarbas.Worker;

public class Worker(ILogger<Worker> logger, IConfiguration configuration) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var httpClient = new HttpClient();
        var response = await httpClient.GetAsync($"https://api.telegram.org/bot{configuration["Telegram:BotToken"]}/getMe");

        if (response.IsSuccessStatusCode)
        {
            logger.LogInformation("Bot is running successfully.");
        }
        else
        {
            logger.LogError("Failed to connect to the Telegram Bot API.");
        }
    }
}
