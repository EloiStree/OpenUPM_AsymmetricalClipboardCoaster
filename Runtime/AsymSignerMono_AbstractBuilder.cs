using UnityEngine;

/// <summary>
/// Use to stress test server it allows to build random clients .
/// </summary>
public abstract class AsymSignerMono_AbstractBuilder : MonoBehaviour
{
    public abstract IAsymSignerClipboardable BuildSigner();
    public abstract void BuildSigner(out IAsymSignerClipboardable signer);
}
