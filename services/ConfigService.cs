using System.Text.Json;

namespace Module3HW7;

public static class ConfigService
{
    private const string Path = "config.json";

    private static Config? _configInstance;

    public static async Task<Config> Get()
    {
        if (_configInstance == null)
        {
            await GetConfig();
        }

        return _configInstance!;
    }

    private static async Task GetConfig()
    {
        await using var jsonStream = new FileStream(Path, FileMode.Open);
        _configInstance = await JsonSerializer.DeserializeAsync<Config>(jsonStream)!;
    }
}