
using UnityEngine;

public abstract class AsymSignerMono_AbstractClipboardSigner : MonoBehaviour, IAsymSignerClipboardable
{
    public abstract void GetClipboardSignedMessage(string message, out string clipboardableSignedMessage);
}


