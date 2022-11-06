namespace Module3HW7;

public class Config : IBackupConfig, ILoggerConfig, IFooConfig
{
    public Config(int backupStep, int logsAmount, string backupPath)
    {
        BackupPath = backupPath;
        BackupStep = backupStep;
        LogsAmount = logsAmount;
    }

    public int BackupStep { get; set; }
    public int LogsAmount { get; set; }
    public string BackupPath { get; set; }
}