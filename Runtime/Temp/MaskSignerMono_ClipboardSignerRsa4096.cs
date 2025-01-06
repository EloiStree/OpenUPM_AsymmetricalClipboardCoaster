public class MaskSignerMono_ClipboardSignerRsa4096 : MaskSignerMono_AbstractClipboardSigner<DefaultRsaCreateSignVerify_Bit4096_B58_Pkcs1_SHA256>
{
    public override void GetClipboardSignedMessage(string message, out string coasterSignedMessage)
    {
        m_createSignVerify.SignMessageAsClipboardable(m_privateKeys, message, out coasterSignedMessage);
    }
}