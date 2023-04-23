using System.ComponentModel;
using ModUwUs.Interfaces;

namespace ModUwUs.Services.DialogService; 

public interface IDialogService {
    void Show<TView>(INotifyPropertyChanged ownerViewModel, IModalDialogViewModel viewModel) where TView : IModalDialogView;
    Task<bool?> ShowDialog<TView>(INotifyPropertyChanged ownerViewModel, IModalDialogViewModel viewModel) where TView : IModalDialogView;
}