public class MaskSignerMono_Rsa4096Builder : MaskSignerMono_AbstractBuilder
{
    public class Signer : IMaskSignerCliboardable
    { 
      public IAsymmetricMaskPrivateKeyHolderGet m_privateKey;

        public Signer()
        {
            MetaMaskSignerRsa4096Utility.GenerateRandomPrivateKeyHolder(out m_privateKey);
        }
        public void GetClipboardSignedMessage(string message, out string clipboardableSignedMessage)
        {
            MetaMaskSignerRsa4096Utility.SignerAsClipboardable(m_privateKey, message, out clipboardableSignedMessage);
        }
    }
    public override IMaskSignerCliboardable BuildSigner()
    {
        return (IMaskSignerCliboardable)new Signer();
    }

    public override void BuildSigner(out IMaskSignerCliboardable signer)
    {
        signer = (IMaskSignerCliboardable)new Signer();
    }
}