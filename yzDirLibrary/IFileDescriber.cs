namespace yzDirLibrary;

public interface IFileDescriber
{
    DateTime ChangedAt { set; get; }
    string Type { set; get; }
    int Size { set; get; }
    string Name { set; get; }
}