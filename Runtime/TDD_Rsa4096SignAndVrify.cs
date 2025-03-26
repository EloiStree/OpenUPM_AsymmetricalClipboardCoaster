using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TDD_Rsa4096SignAndVrify : MonoBehaviour
{

    public AsymSignerMono_SignerRsa4096 m_privateKey;
    public string m_message = "Hello, World!";

    public string m_signedCliboard;

    public string m_signedMessage;
    public string m_publicKeyB58;
    public string m_signatureB58;
    
    public bool m_isVerified;



    [ContextMenu("Check Sign Then Verify")]
    public void CheckSignThenVerify() 
    {
        DefaultRsaCreateSignVerify_Bit4096_B58_Pkcs1_SHA256 t = new DefaultRsaCreateSignVerify_Bit4096_B58_Pkcs1_SHA256();


        m_privateKey.GetClipboardSignedMessage(m_message, out m_signedCliboard);
        t.GetClipboardableAsSplitMessage(m_signedCliboard,
            out  m_signedMessage,
            out  m_publicKeyB58,
            out  m_signatureB58
            );

        m_privateKey.GetLinkedKeyPair(out IAsymmetricPrivateKeyHolderGet keyPair);
        m_isVerified = DefaultRsaCreateSignVerify_Bit4096_B58_Pkcs1_SHA256.
            VerifySignatureB58(m_signedMessage, m_signatureB58, keyPair);



    
    
    }
}
