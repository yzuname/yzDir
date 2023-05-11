using Autofac;
using yzDirLibrary;

namespace yzDir;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var container = ContainerConfig.Configure();
        using (var scope = container.BeginLifetimeScope())
        {
            while (true)
            {
                Console.Write("Input path (for exit type 'Exit'): ");
                var path = await Console.In.ReadLineAsync();
                if (path == "Exit")
                    return;
                try
                {
                    var observer = scope.Resolve<IDirectoryObserverCache>().GetDirectoryObserver(path);
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