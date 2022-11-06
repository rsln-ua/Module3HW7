namespace Module3HW7;

public class BackupService
{
    private readonly IBackupConfig _config;

    public BackupService(IBackupConfig config)
    {
        _config = config;
        CreateDir();
    }

    public async Task Save(string logs)
    {
        await new FileService(GetFilePath()).Write(logs!);
    }

    private string GetFilePath()
    {
        var fileName = DateTime.Now.ToString("O");
        return $"{_config.BackupPath}/{fileName}.txt";
    }

    private void CreateDir()
    {
        var dirInfo = new DirectoryInfo(_config.BackupPath);

        if (!dirInfo.Exists)
        {
            dirInfo.Create();
        }
    }
}