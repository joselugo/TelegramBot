using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

var botClient = new TelegramBotClient("6268675240:AAEY03IinkO7J5rVNN5gJq0WR6iub6wdNQ8");

var cancellantionToken = new CancellationTokenSource();

var me = await botClient.GetMeAsync(cancellantionToken.Token);

botClient.StartReceiving(
    updateHandler: UpdateHandlerAsync,
    pollingErrorHandler: PollingErrorHandlerAsync,
    receiverOptions: new ReceiverOptions
    {
        AllowedUpdates = Array.Empty<UpdateType>()
    },
    cancellationToken: cancellantionToken.Token
);

Task PollingErrorHandlerAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cts)
{
    Console.WriteLine(exception.Message);
    return Task.CompletedTask;
}

async Task UpdateHandlerAsync(ITelegramBotClient botClient, Update update, CancellationToken cts)
{
    if (update.Message is not { } message)
        return;

    if (message.Text is not { } messageText)
        return;

    var chatId = message.Chat.Id;

    Console.WriteLine($"Mensaje recebido: {messageText}");

    if (messageText == "/start")
    {
        var sendMessage = await botClient.SendTextMessageAsync(
            chatId: chatId,
            text: $"Hola soy {me.Username} tu BOT de apoyo, te indico los comando a seleccionar para brindarte mi ayuda.\n\n" +
            "Reporte DB Personas usa el comando /personas \n" +
            "Reporte DB Vehiculos usa el comando /vehiculos \n" +
            "Reporte DB Incidentes usa el comando /incidentes \n" +
            "Reporte DB ABIS usa el comando /abis \n",
            cancellationToken: cts
        );
    }
    else if (messageText == "/personas")
    {
        var sendMessage = await botClient.SendTextMessageAsync(
            chatId: chatId,
            text: $"Elegiste el comando \"{messageText}\". \n\n" +
            "Aun estoy en desarrollo no tengo ninguna funcion implementada pero mas adelante te podre compartir los reportes.",
            cancellationToken: cts
        );
    }
    else if (messageText == "/vehiculos")
    {
        var sendMessage = await botClient.SendTextMessageAsync(
            chatId: chatId,
            text: $"Elegiste el comando \"{messageText}\". \n\n" +
            "Aun estoy en desarrollo no tengo ninguna funcion implementada pero mas adelante te podre compartir los reportes.",
            cancellationToken: cts
        );
    }
    else if (messageText == "/incidentes")
    {
        var sendMessage = await botClient.SendTextMessageAsync(
            chatId: chatId,
            text: $"Elegiste el comando \"{messageText}\". \n\n" +
            "Aun estoy en desarrollo no tengo ninguna funcion implementada pero mas adelante te podre compartir los reportes.",
            cancellationToken: cts
        );
    }
    else if (messageText == "/abis")
    {
        var sendMessage = await botClient.SendTextMessageAsync(
            chatId: chatId,
            text: $"Elegiste el comando \"{messageText}\". \n\n" +
            "Aun estoy en desarrollo no tengo ninguna funcion implementada pero mas adelante te podre compartir los reportes.",
            cancellationToken: cts
        );
    }
    else
    {
        var sendMessage = await botClient.SendTextMessageAsync(
            chatId: chatId,
            text: $"Lo siento... \"{messageText}\" no es un comando, usa alguno de los mencionados anteriormente.",
            cancellationToken: cts
        );
    }



}

Console.WriteLine($"Escuchando {me.Username}");
    Console.ReadLine();
    cancellantionToken.Cancel();
