
using UnityEngine;

public class MaskSignerMono_PrivateKeyHolderRsa4096 : MaskSignerMono_PrivateKeyHolder<DefaultRsaCreateSignVerify_Bit4096_B58_Pkcs1_SHA256>
{
    private void Reset()
    {
        GenerateKeys();
    }

    [ContextMenu("Generate Keys")]
    public void GenerateKeys()
    {
        Build();

    }
    public void GetPublicKeyAsB58(out string privateKeyAsB58, out string publicKeyAsB58)
    {

        privateKeyAsB58 = base.GetPrivateKeyInB58UrlFromat();
        publicKeyAsB58 = base.GetPublicAddressInB58UrlFormat();

    }
    public void GetKeyPairAsXml(out string privateKeyAsXml, out string publicKeyAsXml)
    {
        DefaultRsaCreateSignVerify_Bit4096_B58_Pkcs1_SHA256.
            GetXmlKeyPrivateFromB58(this, out privateKeyAsXml, out publicKeyAsXml);
    }


    [ContextMenu("Open Url to generate coaster")]
    public void GenerateCoasterWithOpenUrl()
    {
        base.OpenUrlToSignPublicAddress();
    }

    
}
