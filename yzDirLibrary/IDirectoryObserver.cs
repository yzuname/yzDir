namespace yzDirLibrary;

public interface IDirectoryObserver
{
    bool IsChanged { get; }
    List<FileDescriber> Content { get; }
    void GatherFolderContent();
    void Output();
}