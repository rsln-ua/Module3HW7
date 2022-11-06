namespace Module3HW7;

public class Foo
{
    private readonly LogType[] _types = { LogType.Info, LogType.Error, LogType.Warning };
    private readonly IFooConfig _config;

    private readonly Dictionary<LogType, string> _logMessages = new()
    {
        { LogType.Error, "Some Error" },
        { LogType.Warning, "Some Warning" },
        { LogType.Info, "Some Info" },
    };

    private readonly LoggerService _loggerService;

    public Foo(LoggerService loggerService, IFooConfig config)
    {
        _loggerService = loggerService;
        _config = config;
    }

    public async Task Bar()
    {
        for (var i = 0; i < _config.LogsAmount; i++)
        {
            await GetRandomLog();
        }
    }

    public async Task Baz()
    {
        for (var i = 0; i < _config.LogsAmount; i++)
        {
            await GetRandomLog();
        }
    }

    private Task GetRandomLog()
    {
        var randType = _types[new Random().Next(_types.Length)];
        return _loggerService.Add(randType, _logMessages[randType]);
    }
}