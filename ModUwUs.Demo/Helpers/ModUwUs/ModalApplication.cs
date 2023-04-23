using System.Collections.Generic;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using ModUwUs.Interfaces;

namespace ModUwUs.Demo.Helpers.ModUwUs; 

public class ModalApplication : IModalApplication {

    private readonly IClassicDesktopStyleApplicationLifetime _desktop;
    
    public IView? MainWindow => _desktop.MainWindow as IView;

    public IEnumerable<IView?> Windows => _desktop.Windows.Select(window => window as IView);

    public ModalApplication(IClassicDesktopStyleApplicationLifetime desktop) {
        _desktop = desktop;
    }
}