using System.ComponentModel;
using ModUwUs.Interfaces;

namespace ModUwUs.Services.DialogService; 

public class DialogService : IDialogService {
    private IModalApplication _application;
    
    public DialogService(IModalApplication application) {
        _application = application;
    }
    
    /// <summary>
    /// Display is non-modal dialog
    /// </summary>
    /// <param name="ownerViewModel">ViewModel from Owner Window</param>
    /// <param name="viewModel">New Dialog View Model</param>
    /// <typeparam name="TView">Type of Dialog</typeparam>
    public void Show<TView>(INotifyPropertyChanged ownerViewModel, IModalDialogViewModel viewModel) where TView : IModalDialogView {
        if (ownerViewModel == null) 
            throw new ArgumentNullException(nameof(ownerViewModel));
        if (viewModel == null) 
            throw new ArgumentNullException(nameof(viewModel));
        
        var view = CreateDialog<TView>(ownerViewModel, viewModel);
        var owner = FindOwnerViewByViewModel(ownerViewModel);
        view.Show(owner);
    }
    
    /// <summary>
    /// Display is dialog window
    /// </summary>
    /// <param name="ownerViewModel">ViewModel from Owner Window</param>
    /// <param name="viewModel">New Dialog View Model</param>
    /// <typeparam name="TView">Type of Dialog</typeparam>
    public async Task<bool?> ShowDialog<TView>(INotifyPropertyChanged ownerViewModel, IModalDialogViewModel viewModel) where TView : IModalDialogView {
        if (ownerViewModel == null) 
            throw new ArgumentNullException(nameof(ownerViewModel));
        if (viewModel == null) 
            throw new ArgumentNullException(nameof(viewModel));

        var view = CreateDialog<TView>(ownerViewModel, viewModel);
        var owner = FindOwnerViewByViewModel(ownerViewModel);
        await view.ShowDialog<bool>(owner);
        return viewModel.DialogResult;
    }
    
    private IView FindOwnerViewByViewModel(INotifyPropertyChanged ownerViewModel) {
        if (ownerViewModel == null) 
            throw new ArgumentNullException(nameof(ownerViewModel));
        var view = _application.Windows.First(view => Equals(view?.DataContext, ownerViewModel));
        if (view is null)
            throw new ArgumentException("Owner View not Found");
        return view;
    }

    private TView CreateDialog<TView>(INotifyPropertyChanged ownerViewModel, IModalDialogViewModel viewModel) where TView : IModalDialogView {
        var view = Activator.CreateInstance<TView>();
        view.DataContext = viewModel;
        HandleDialogEvent(viewModel, view);
        return view;
    }

    private void HandleDialogEvent<TView>(INotifyPropertyChanged viewModel, TView dialog) where TView : IView {
        if (viewModel is IClosable closable)
            closable.RequestClose += (sender, args) => dialog.Close();
    }
    
}