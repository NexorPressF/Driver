using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media.Imaging;
using Avalonia.Platform.Storage;
using DriverDB1.Classes;
using DriverDB1.Venom;
using Microsoft.EntityFrameworkCore;
using MsBox.Avalonia;

namespace DriverDB1.Views;

public partial class AddDriverView : UserControl
{
    public int _id;
    public AddDriverView(int id = -1)
    {
        InitializeComponent();
        Help.MainTC.Drivers.Load();
        _id = id;

        if (id == -1)
        {
            AddSp.DataContext = new Driver() {Photo = new Photo()};
        }
        else
        {
            var user = Help.MainTC.Drivers.FirstOrDefault(el => el.Id == id);
            AddSp.DataContext = user;
        }

        if (id == -1)
        {
            AddSp.IsEnabled = true;
        }
        else
        {
            AddSp.IsEnabled = false;
        }
    }

    private void AddBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        try
        {
            Regex regPhone = new Regex(@"\+7\(\d\d\d\)\d\d\d-\d\d\d\d");
            if (!regPhone.IsMatch(MobPhoneTb.Text))
            {
                MessageBoxManager.GetMessageBoxStandard("Error", "����������� ����� ������ �� �� �������");
                return;
            }

            Regex regEmail = new Regex("[^@]+@[^@]+");
            if (!regEmail.IsMatch(EmailTb.Text))
            {
                MessageBoxManager.GetMessageBoxStandard("Error", "����� ������� �� �� �������");
                return;
            }

            if (_id == -1)
            {
                Help.MainTC.Drivers.Add(AddSp.DataContext as Driver);
            }
            Help.MainTC.SaveChanges();
            Help.MainCC.Content = new MainView();
        }
        catch
        {
            MessageBoxManager.GetMessageBoxStandard("Error", "��������� �� ��� ������");
        }
    }

    private async void OpenImageBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        var topLevel = TopLevel.GetTopLevel(this);
        var file = await topLevel.StorageProvider.OpenFilePickerAsync(new Avalonia.Platform.Storage.FilePickerOpenOptions()
        {
            Title = "Open Image File",
            AllowMultiple = false,
            FileTypeFilter = new[] {FilePickerFileTypes.ImageAll }
        });

        if (file.Count > 0)
        {
            var driver = AddSp.DataContext as Driver;
            driver.Photo.Photo1 = File.ReadAllBytes(file[0].Path.LocalPath);
            DriverPhoto.Source = new Bitmap(file[0].Path.LocalPath);
        }
    }

    private void OtmBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        Help.MainCC.Content = new InspectorView();
    }
}