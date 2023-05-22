using yzDirLibrary;

namespace yzDir;

public class DirectoryObserverOutput
{
    private IDirectoryObserver _directoryObserver; 
    public DirectoryObserverOutput(IDirectoryObserver directoryObserver)
    {
        _directoryObserver = directoryObserver;
    }

    public void Output()
    {
        Console.WriteLine($"Full path: { _directoryObserver.FullPath }");
        foreach (var file in _directoryObserver.Content)
        {
            Console.WriteLine($"{file.ChangedAt.Date}\t " +
                              $"{file.ChangedAt:HH:m:s}\t " +
                              $"{file.Type}\t " +
                              $"{file.Size}\t " +
                              $"{file.Name}");
        }
    }
}