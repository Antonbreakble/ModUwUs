namespace ModUwUs.Interfaces; 

public interface IModalDialogView : IView {
    void Show(IView owner);
    Task<TResult> ShowDialog<TResult>(IView owner);
}