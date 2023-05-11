namespace yzDirLibrary;

public class DirectoryObserverCache : IDirectoryObserverCache
{
    private Dictionary<string, DirectoryObserver> _cache = new();
    
    public DirectoryObserver GetDirectoryObserver(string path)
    {
        DirectoryObserver observer;
        if (_cache.ContainsKey(path))
        {
            observer = _cache[path];
            if (observer.IsChanged)
                observer.GatherFolderContent();
            return observer;
        }
        observer = new DirectoryObserver(path);
        observer.GatherFolderContent();
        _cache.Add(path, observer);
        return observer;
    }
}