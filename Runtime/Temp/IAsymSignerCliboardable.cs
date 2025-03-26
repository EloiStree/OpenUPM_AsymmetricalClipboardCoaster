

/// <summary>
/// This class will sign a message in a clibpardable format usable by human and server 
/// The code of to build it is in the class that inherit from it
/// </summary>
public interface IAsymSignerCliboardable
{
    void GetClipboardSignedMessage(string message, out string clipboardableSignedMessage);
}
