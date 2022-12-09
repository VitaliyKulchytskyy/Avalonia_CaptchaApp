using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using CaptchaApp.Models;
using CaptchaApp.Views;

namespace CaptchaApp
{
    public class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow{};
                desktop.MainWindow.Height = Constant.Window.MainWindowHeight;
                desktop.MainWindow.Width = Constant.Window.MainWindowWidth;
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}