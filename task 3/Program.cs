using System;
using System.Collections.Generic;


interface INotificationChannel
{
    void Send(string message);
}

interface IMessageLogger
{
    void Log(string message);
}



class NotificationService
{
    private readonly INotificationChannel _channel;
    private readonly IMessageLogger _logger;

    public NotificationService(
        INotificationChannel channel,
        IMessageLogger logger)
    {
        _channel = channel;
        _logger = logger;
    }

    public void Send(string message)
    {
        _channel.Send(message);
        _logger.Log(message);
    }
}


class EmailChannel : INotificationChannel
{
    public void Send(string message)
    {
        Console.WriteLine($"[Email] {message}");
    }
}

class SmsChannel : INotificationChannel
{
    public void Send(string message)
    {
        Console.WriteLine($"[SMS] {message}");
    }
}

class FileLogger : IMessageLogger
{
    public void Log(string message)
    {
        Console.WriteLine($"[Log] {message}");
    }
}


class Program
{
    static void Main()
    {
        IMessageLogger logger = new FileLogger();


        List<INotificationChannel> channels = new List<INotificationChannel>
        {
            new EmailChannel(),
            new SmsChannel()
        };

        foreach (INotificationChannel channel in channels)
        {
            NotificationService service =
                new NotificationService(channel, logger);

            service.Send("Hello from Session 7!");
        }
    }
}
