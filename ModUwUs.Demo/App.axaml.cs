using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using ModUwUs.Demo.Helpers.ModUwUs;
using ModUwUs.Demo.ViewModel;
using ModUwUs.Services.DialogService;

namespace ModUwUs.Demo {
    public partial class App : Application {
        public override void Initialize() {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted() {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop) {
                desktop.MainWindow = new View.MainWindow() {
                    DataContext = new MainViewModel(new DialogService(desktop.AsModalApplication()))
                };
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}