public class AsymSignerMono_Rsa4096Builder : AsymSignerMono_AbstractBuilder
{
    public class Signer : IAsymSignerClipboardable
    { 
      public IAsymmetricPrivateKeyHolderGet m_privateKey;

        public Signer()
        {
            AsymSignerRsa4096Utility.GenerateRandomPrivateKeyHolder(out m_privateKey);
        }
        public void GetClipboardSignedMessage(string message, out string clipboardableSignedMessage)
        {
            AsymSignerRsa4096Utility.SignerAsClipboardable(m_privateKey, message, out clipboardableSignedMessage);
        }
    }
    public override IAsymSignerClipboardable BuildSigner()
    {
        return (IAsymSignerClipboardable)new Signer();
    }

    public override void BuildSigner(out IAsymSignerClipboardable signer)
    {
        signer = (IAsymSignerClipboardable)new Signer();
    }
}