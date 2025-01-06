public class MaskSignerMono_SignerRsa4096 : MaskSignerMono_AbstractClipboardSigner
{
    public MaskSignerMono_AbstractPrivateKey m_keyHolder;

    public override void GetClipboardSignedMessage(string message, out string clipboardableSignedMessage)
    {
        DefaultRsaCreateSignVerify_Bit4096_B58_Pkcs1_SHA256 t = new DefaultRsaCreateSignVerify_Bit4096_B58_Pkcs1_SHA256();
        t.SignMessageAsClipboardable(m_keyHolder, message, out clipboardableSignedMessage);            
    }
    public void GetLinkedKeyPair(out IAsymmetricMaskPrivateKeyHolderGet keyPair)
    {
        keyPair = m_keyHolder;
    }
}
