using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using DriverDB1.Classes;
using DriverDB1.Venom;
using Microsoft.EntityFrameworkCore;
using MsBox.Avalonia;

namespace DriverDB1.Views;

public partial class InspectorView : UserControl
{
    public InspectorView()
    {
        InitializeComponent();
        Help.MainTC.Drivers.Load();
        MainDG.ItemsSource = Help.MainTC.Drivers.ToList();
    }

    private void DeleteBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        var user = MainDG.SelectedItem as Driver;
        if (user == null)
        {
            MessageBoxManager.GetMessageBoxStandard("ОШИБКА!!!", "НЕ ВЫБРАН ПОЛЬЗОВАТЕЛЬ!!!").ShowAsync();
            return;
        }
        Help.MainTC.Drivers.Remove(user);
        Help.MainTC.SaveChanges();
        Help.MainCC.Content = new InspectorView();
    }
    

    private void AddBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        Help.MainCC.Content = new AddDriverView();
    }

    private void ObZBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        var user = MainDG.SelectedItem as Driver;
        if (user == null)
        {
            MessageBoxManager.GetMessageBoxStandard("ОШИБКА!!!", "НЕ ВЫБРАН ПОЛЬЗОВАТЕЛЬ!!!").ShowAsync();
            return;
        }
        Help.MainCC.Content = new AddDriverView(user.Id);
        
        
    }
}