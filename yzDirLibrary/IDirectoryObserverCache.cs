namespace yzDirLibrary;

public interface IDirectoryObserverCache
{
    DirectoryObserver GetDirectoryObserver(string path);
}