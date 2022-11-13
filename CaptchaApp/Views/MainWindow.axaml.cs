using Avalonia.Controls;
using CaptchaApp.ViewModels;
namespace CaptchaApp.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new CaptchaViewModel();
    }
}