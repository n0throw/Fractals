using System.Globalization;

namespace Fractals.LoggerCore;

internal record struct Log
{
    internal string Message { get; init; }
    internal LogType Type { get; init; }
    internal string Time { get; init; }

    internal Log(string message, LogType type, DateTime time)
    {
        Message = message;
        Type = type;
        Time = time.ToString(new CultureInfo("ru-RU"));
    }

    public override string ToString()
        => $"{TypeToString(Type)}[{Time}] {Message}";

    private string TypeToString(LogType type) => type switch
    {
        LogType.Succes => "Succes",
        LogType.Warning => "Warning",
        LogType.Error => "Error",
        _ => "Error",
    };
}
