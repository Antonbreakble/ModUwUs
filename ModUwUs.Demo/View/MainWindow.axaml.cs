using System.Threading.Tasks;
using Avalonia.Controls;
using ModUwUs.Interfaces;

namespace ModUwUs.Demo.View {
    public partial class MainWindow : Window, IView {
        public MainWindow() {
            InitializeComponent();
        }

        public IView? ViewOwner {
            get => Owner as IView;
            set {
                if (value is Window window)
                    Owner = window;
            }
        }
    }
}