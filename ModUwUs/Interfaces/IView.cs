namespace ModUwUs.Interfaces; 

public interface IView {
    object? DataContext { get; set; }
    IView? ViewOwner { get; set; }
    
    void Close();
}