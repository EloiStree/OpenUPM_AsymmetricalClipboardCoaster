
using UnityEngine;

public abstract class AsymSignerMono_AbstractClipboardSigner : MonoBehaviour, IAsymSignerCliboardable
{
    public abstract void GetClipboardSignedMessage(string message, out string clipboardableSignedMessage);
}


