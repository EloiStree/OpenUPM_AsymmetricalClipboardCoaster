using UnityEngine;

public abstract class MaskSignerMono_AbstractClipboardSigner<T> : MonoBehaviour where T: IAssymentricMaskCreateSignVerify, new()
{
    public T m_createSignVerify = new T();
    public MaskSignerMono_AbstractPrivateKey m_privateKeys;
    public abstract void GetClipboardSignedMessage(string message, out string coasterSignedMessage);

}
