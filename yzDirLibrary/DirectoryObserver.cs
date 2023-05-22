namespace yzDirLibrary;

public class DirectoryObserver : IDirectoryObserver
{
    private List<FileDescriber> _content = new();
    private FileSystemWatcher _watcher;

    private readonly string _path;
    private bool _isChanged;

    public string FullPath => _path;

    public bool IsChanged
    {
        get => _isChanged;
    }
    
    public List<FileDescriber> Content
    {
        get => _content;
    }
    
    public DirectoryObserver(string path)
    {
        _path = path;
        _watcher = new FileSystemWatcher(path);
        _watcher.NotifyFilter = NotifyFilters.Attributes
                              | NotifyFilters.CreationTime
                              | NotifyFilters.DirectoryName
                              | NotifyFilters.FileName
                              | NotifyFilters.LastAccess
                              | NotifyFilters.LastWrite
                              | NotifyFilters.Security
                              | NotifyFilters.Size;
        _watcher.Changed += (sender, args) => { _isChanged = true; };
        _watcher.Created += (sender, args) => { _isChanged = true; };
        _watcher.Deleted += (sender, args) => { _isChanged = true; };
        _watcher.EnableRaisingEvents = true;
    }

    public void GatherFolderContent()
    {
        _content.Clear();
        var fileEntries = Directory.GetFileSystemEntries(_path);
        foreach (var fileEntry in fileEntries)
        {
            var fileDescriber = new FileDescriber();
            fileDescriber.Name = Path.GetFileName(fileEntry);
            
            var attributes = File.GetAttributes(fileEntry);
            if ((attributes & FileAttributes.Directory) == FileAttributes.Directory)
            {
                var directoryInfo = new DirectoryInfo(fileEntry);
                fileDescriber.Type = "DIR";
                fileDescriber.ChangedAt = directoryInfo.LastWriteTime;
            }
            else
            {
                var fileInfo = new FileInfo(fileEntry);
                fileDescriber.Size = (int)fileInfo.Length;
                fileDescriber.ChangedAt = fileInfo.LastWriteTime;
            }
            _content.Add(fileDescriber);
        }
    }
}