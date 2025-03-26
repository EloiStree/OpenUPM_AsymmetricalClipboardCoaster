using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TDD_SignMessageWithCoasterSigner : MonoBehaviour
{

    public string m_message= "Hello World"; 
    public AsymSignerMono_AbstractClipboardSigner m_signer;

    [TextArea(0,15)]
    public string m_signatureClipboardable;

    [ContextMenu("Sign")]
    public void Sign()
    {
       m_signer.GetClipboardSignedMessage(m_message, out m_signatureClipboardable);
    }


    [ContextMenu("GenerateGuid")]
    public void SetMessageAsGuid()
    {
        string guid = System.Guid.NewGuid().ToString();
        m_message = guid;
        Sign();
    }

}
