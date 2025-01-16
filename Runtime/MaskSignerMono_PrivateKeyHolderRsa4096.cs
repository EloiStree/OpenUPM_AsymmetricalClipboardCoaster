
using Eloi;
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

    public void SetFromPrivateKey(string privateKey) {

        Bit4096B58Pkcs1SHA256.CreateFromPrivateKeyAsBase58(
            privateKey, 
            out string publicKey,
            out string privateKeyAsB58,
            out string publicKeyAsB58);

        keyPair.m_publicAddressOriginal = publicKey;
        keyPair.m_privateKeyOriginal = privateKey;
        keyPair.m_publicKeyB58 = publicKeyAsB58;
        keyPair.m_privateKeyB58 = privateKeyAsB58;
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
