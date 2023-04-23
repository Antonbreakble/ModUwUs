using System.ComponentModel;

namespace ModUwUs.Interfaces; 

public interface IModalDialogViewModel : INotifyPropertyChanged {
    bool? DialogResult { get; }
}