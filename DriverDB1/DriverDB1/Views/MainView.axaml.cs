using Avalonia.Controls;
using Avalonia.Interactivity;
using DriverDB1.Classes;
using MsBox.Avalonia;

namespace DriverDB1.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
    }

    private void AutBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        if (LoginTb.Text == "inspector" && PassTb.Text == "inspector")
        {
            Help.MainCC.Content = new InspectorView();
        }
        else
        {
            MessageBoxManager.GetMessageBoxStandard("ОШИБКА!!!!!!!!!!!!!", "ВЫ ВВЕЛИ НЕПРАВИЛЬНЫЙ ПАРОЛЬ ИЛИ ЛОГИН!!!").ShowAsync();
            return;
        }
    }
}