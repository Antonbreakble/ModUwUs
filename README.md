# ModUwUs
ModUwUs - Simple Service For Open/Close Modal Window on Avalonia
# How To Use
## Mark View
### Mark you View (Owner for your model window) via ```IView``` Interface and implement it
```csharp
public IView? ViewOwner
{
    get => Owner as IView;
    set
    {
        if (value is Window window)
            Owner = window;
    }
}
```
### Mark you Modal View via ```IModalDialogView``` Interface and implement it
```csharp
public IView? ViewOwner
{
    get => Owner as IView;
    set
    {
        if (value is Window window)
            Owner = window;
    }
}

public void Show(IView owner)
{
    Show(owner as Window);
}
    
public Task<TResult> ShowDialog<TResult>(IView owner)
{
    return ShowDialog<TResult>(owner as Window);
}
```
### Mark Dialog View Model via IModalDialogViewModel and if need IClosable for hand closed event from view

Example: https://github.com/Antonbreakble/ModUwUs/blob/master/ModUwUs.Demo/ViewModel/AddUserViewModel.cs

### Implement ```IModalApplication``` interface

Example for Avalonia Classic Desktop App: https://github.com/Antonbreakble/ModUwUs/blob/master/ModUwUs.Demo/Helpers/ModUwUs/ModalApplication.cs

### Create and Inject DialogService and use it 
```csharp
var viewModel = new AddUserViewModel();
var dialogResult = await _dialogService.ShowDialog<AddUserView>(this, viewModel);
if(dialogResult is true)
    //some logic
```
For more info: https://github.com/Antonbreakble/ModUwUs/tree/master/ModUwUs.Demo
