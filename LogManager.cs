// Arquivo: LogManager.cs
using System;
using System.Diagnostics;
using System.Globalization;

public static class LogManager
{
    public delegate void LogEventHandler(string message);
    public static event LogEventHandler? LogEvent;

    public static void Log(string message)
    {
        Debug.WriteLine(message);
        string formattedMessage = $"{DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss", CultureInfo.CurrentCulture)}: {message}";

        //Sends log event to all subscribers
        LogEvent?.Invoke(formattedMessage);
    }
}