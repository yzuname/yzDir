using Autofac;
using yzDirLibrary;

namespace yzDir;

public class ContainerConfig
{
    public static IContainer Configure()
    {
        var builder = new ContainerBuilder();

        builder.RegisterType<DirectoryObserverCache>().As<IDirectoryObserverCache>();

        return builder.Build();
    }
}