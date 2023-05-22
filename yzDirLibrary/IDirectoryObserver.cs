namespace yzDirLibrary;

public interface IDirectoryObserver
{
    string FullPath { get; }
    bool IsChanged { get; }
    List<FileDescriber> Content { get; }
    void GatherFolderContent();
}