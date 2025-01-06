
using UnityEngine;

public abstract class MaskSignerMono_AbstractClipboardSigner : MonoBehaviour, IMaskSignerCliboardable
{
    public abstract void GetClipboardSignedMessage(string message, out string clipboardableSignedMessage);
}


