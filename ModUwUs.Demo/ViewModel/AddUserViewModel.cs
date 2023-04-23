using System;
using System.Threading;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ModUwUs.Interfaces;

namespace ModUwUs.Demo.ViewModel; 

public partial class AddUserViewModel : ViewModelBase, IModalDialogViewModel, IClosable {

    public event EventHandler? RequestClose;
    
    [ObservableProperty] private string _firstName = string.Empty;

    [ObservableProperty] private string _lastName = string.Empty;

    public IAsyncRelayCommand AddUserCommand { get; }
    
    public AddUserViewModel() {
        AddUserCommand = new AsyncRelayCommand(AddUser);
    }

    private Task AddUser(CancellationToken token) {
        DialogResult = true;
        RequestClose?.Invoke(this, EventArgs.Empty);
        return Task.CompletedTask;
    }
    
    public bool? DialogResult { get; private set; }
}