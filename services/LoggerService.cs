namespace Module3HW7;

public class LoggerService
{
    private const int LineOfStatus = 10;
    private readonly ILoggerConfig _config;

    public LoggerService(Config config)
    {
        _config = config;
    }

    public event Func<string, Task>? BackupHandler;

    public Logger Logger
    {
        get { return LoggerInstance ??= new Logger(); }
    }

    private static Logger LoggerInstance { get; set; } = null!;

    public static string ToString(Log log)
    {
        return $"{log.Timestamp.ToString("O")}  |  {log.Type.ToString().PadRight(LineOfStatus)}  |  {log.Message}";
    }

    public static Log Create(LogType type, string message)
    {
        return new Log() { Timestamp = DateTime.Now, Message = message, Type = type };
    }

    public async Task Save(Log log)
    {
        Logger.History.Add(log);

        if ((Logger.History.Count % _config.BackupStep == 0) && BackupHandler != null)
        {
            await BackupHandler(ListToString(new List<Log>(Logger.History)));
        }
    }

    public async Task Add(LogType type, string message)
    {
        var log = Create(type, message);
        await Save(log);
    }

    private static string ListToString(List<Log> allLogs)
    {
        var logs = default(string);

        foreach (var log in allLogs)
        {
            logs += ToString(log) + Environment.NewLine;
        }

        return logs!;
    }
}