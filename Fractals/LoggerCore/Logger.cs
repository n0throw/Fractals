using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Text;
using System.Text.Json;

namespace Fractals.LoggerCore;

internal class Logger
{
    private List<Log> logs;

    internal Logger()
    {
        logs = new List<Log>();
    }

    internal void Add(Log log)
    {
        logs.Add(log);
        Write(log);
    }

    internal void Add(string message, LogType type, DateTime time)
        => Add(new Log(message, type, time));

    internal void Add(string message, LogType type)
        => Add(new Log(message, type, DateTime.Now));

    internal void Close(Exception? ex)
    {
        if (ex is null)
        {
            Add(new Log(
                "Close window",
                LogType.Succes,
                DateTime.Now));
        }
        else
        {
            Add(new Log(
                ex.Message,
                LogType.Error,
                DateTime.Now));
        }

        SaveLog();
    }

    private static void Write(Log log)
    {
        SetColor(log.Type);
        Console.WriteLine($"[{log.Time}] {log.Message}");
        SetColor(null);
    }

    private static void SetColor(LogType? type = null)
    {
        Console.ForegroundColor = type switch
        {
            LogType.Succes => ConsoleColor.Green,
            LogType.Warning => ConsoleColor.Yellow,
            LogType.Error => ConsoleColor.Red,
            _ => ConsoleColor.White,
        };
    }

    private void SaveLog()
    {
        string? path = Path.GetDirectoryName(
            Process.GetCurrentProcess().MainModule?.FileName);

        path ??= Assembly.GetExecutingAssembly().Location;
        path += $"/log{DateTime.Now.ToString(new CultureInfo("ru-RU"))}";


        string logsJson = JsonSerializer.Serialize(logs);
        string logsLog = string.Join("\n", logs);

        // запись json
        using (FileStream fstream = new(path + ".json", FileMode.Create))
        {
            byte[] buffer = Encoding.Default.GetBytes(logsJson);
            fstream.Write(buffer, 0, buffer.Length);
        }
        // запись log
        using (FileStream fstream = new(path + ".log", FileMode.Create))
        {
            byte[] buffer = Encoding.Default.GetBytes(logsLog);
            fstream.Write(buffer, 0, buffer.Length);
        }

        Add(new Log(
            $"Лог записан по пути: {path}",
            LogType.Succes,
            DateTime.Now));
        logs.Clear();
    }
}