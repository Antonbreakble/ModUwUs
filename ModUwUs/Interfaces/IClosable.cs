namespace ModUwUs.Interfaces; 

public interface IClosable {
    event EventHandler? RequestClose;
}