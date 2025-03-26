using UnityEngine;

public abstract class AsymSignerMono_AbstractClipboardSigner<T> : MonoBehaviour where T: IAssymentricCreateSignVerify, new()
{
    public T m_createSignVerify = new T();
    public AsymSignerMono_AbstractPrivateKey m_privateKeys;
    public abstract void GetClipboardSignedMessage(string message, out string coasterSignedMessage);

}
