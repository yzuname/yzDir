using System.Windows;
using Autofac;

namespace yzDirWPF
{
    public partial class App : Application
    {
        private MainWindow _mainWindow;
        private IContainer _container;
        public ILifetimeScope Scope { get; private set; }

        public App()
        {
            _container = ContainerConfig.Configure();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            Scope = _container.BeginLifetimeScope();
            _mainWindow = new MainWindow();
            _mainWindow.Show();
            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
        }
    }
}