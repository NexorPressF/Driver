using Avalonia.Controls;
using Avalonia.Interactivity;
using DriverDB1.Classes;

namespace DriverDB1.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        Help.MainCC = MainCC;
        MainCC.Content = new MainView();
    }

    private void ExitBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        Help.MainCC.Content = new MainView();
    }
}