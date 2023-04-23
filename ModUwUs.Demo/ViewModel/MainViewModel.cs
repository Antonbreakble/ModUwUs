using System.Threading;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ModUwUs.Demo.View;
using ModUwUs.Services.DialogService;

namespace ModUwUs.Demo.ViewModel; 

public partial class MainViewModel : ViewModelBase {
    private readonly IDialogService _dialogService;

    [ObservableProperty] private string _newAccount = string.Empty;
    
    public AsyncRelayCommand OpenAddUserDialogCommand { get; }
    public AsyncRelayCommand OpenAddUserWindowCommand { get; }
    public MainViewModel(IDialogService dialogService) {
        _dialogService = dialogService;
        OpenAddUserDialogCommand = new AsyncRelayCommand(OpenAddUserDialog);
        OpenAddUserWindowCommand = new AsyncRelayCommand(OpenAddUserWindow);
    }
    
    private async Task OpenAddUserDialog(CancellationToken arg) {
        var viewModel = new AddUserViewModel();
        var dialogResult = await _dialogService.ShowDialog<AddUserView>(this, viewModel);
        if(dialogResult is true)
            NewAccount = $"{viewModel.FirstName} {viewModel.LastName}";
    }
    
    private Task OpenAddUserWindow(CancellationToken arg) {
        var viewModel = new AddUserViewModel();
        _dialogService.Show<AddUserView>(this, viewModel);
        return Task.CompletedTask;
    }
}