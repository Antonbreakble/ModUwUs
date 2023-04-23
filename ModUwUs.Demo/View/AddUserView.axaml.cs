using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using ModUwUs.Interfaces;

namespace ModUwUs.Demo.View; 

public partial class AddUserView : Window, IModalDialogView {
    public AddUserView() {
        InitializeComponent();
#if DEBUG
        this.AttachDevTools();
#endif
    }

    private void InitializeComponent() {
        AvaloniaXamlLoader.Load(this);
    }

    public IView? ViewOwner {
        get => Owner as IView;
        set {
            if (value is Window window)
                Owner = window;
        }
    }
    public void Show(IView owner) {
        Show(owner as Window);
    }
    
    public Task<TResult> ShowDialog<TResult>(IView owner) {
        return ShowDialog<TResult>(owner as Window);
    }
}