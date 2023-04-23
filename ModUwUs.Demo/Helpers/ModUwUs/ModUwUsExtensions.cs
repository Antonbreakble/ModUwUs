using Avalonia.Controls.ApplicationLifetimes;

namespace ModUwUs.Demo.Helpers.ModUwUs; 

public static class ModUwUsExtensions {
    public static ModalApplication AsModalApplication(this IClassicDesktopStyleApplicationLifetime desktop) {
        return new ModalApplication(desktop);
    }
}