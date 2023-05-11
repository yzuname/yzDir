namespace yzDirLibrary;

public class FileDescriber : IFileDescriber
{
    public DateTime ChangedAt { set; get; }
    
    public string Type { set; get; }
    
    public int Size { set; get; }
    public string Name { set; get; }
    
    public FileDescriber()
    {
        Name = "";
        Type = "";
    }
}