using System;
using System.Windows;
using Autofac;
using yzDirLibrary;

namespace yzDirWPF;

public partial class MainWindow : Window
{
    private IDirectoryObserverCache _observerCache;

    public MainWindow()
    {
        var application = (App)Application.Current;
        _observerCache = application.Scope.Resolve<IDirectoryObserverCache>();
        InitializeComponent();
    }

    void OnGatherClick(object sender, RoutedEventArgs e)
    {
        listViewDirectoryContent.Items.Clear();
        try
        {
            var observer = _observerCache.GetDirectoryObserver(textBoxPath.Text);
            foreach (var file in observer.Content)
            {
                listViewDirectoryContent.Items.Add(file);
            }
        }
        catch (Exception exception)
        {
            MessageBox.Show("Incorrect path", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}