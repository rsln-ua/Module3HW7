namespace Module3HW7;

public class FileService
{
    private readonly string _path;

    public FileService(string path)
    {
        _path = path;
    }

    public Task Write(string data)
    {
        return File.WriteAllTextAsync(_path, data);
    }

    public Task<string> Read()
    {
        return File.ReadAllTextAsync(_path);
    }
}