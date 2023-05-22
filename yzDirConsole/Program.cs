using Autofac;
using yzDirLibrary;

namespace yzDir;

internal class Program
{
    private const string ExitCommand = "Exit";
    
    private static async Task Main(string[] args)
    {
        var container = ContainerConfig.Configure();
        using (var scope = container.BeginLifetimeScope())
        {
            while (true)
            {
                Console.WriteLine($"Current directory is { Directory.GetCurrentDirectory() }");
                Console.Write("Input path (for exit type 'Exit'): ");
                var path = await Console.In.ReadLineAsync();
                if (path == ExitCommand)
                    return;
                try
                {
                    var fullPath = Path.GetFullPath(path);
                    var observer = scope.Resolve<IDirectoryObserverCache>().GetDirectoryObserver(fullPath);
                    new DirectoryObserverOutput(observer).Output();
                }
                catch
                {
                    Console.WriteLine("The path is incorrect");
                }
            }
        }
    }
}