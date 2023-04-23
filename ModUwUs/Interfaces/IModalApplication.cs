namespace ModUwUs.Interfaces; 

public interface IModalApplication {
    IView? MainWindow { get; }
    IEnumerable<IView?> Windows { get; }
}