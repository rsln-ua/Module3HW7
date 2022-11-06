namespace Module3HW7;

public class Starter
{
    public async Task Run()
    {
        var config = await ConfigService.Get();
        var loggerService = new LoggerService(config);
        var backupService = new BackupService(config);

        loggerService.BackupHandler += backupService.Save;

        var foo = new Foo(loggerService, config);

        await Task.WhenAll(foo.Bar(), foo.Baz());
    }
}