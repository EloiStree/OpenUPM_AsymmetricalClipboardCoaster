
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

    [ContextMenu("Reload From Inspector XML")]
    public void ReloadFromInspectorXml()
    {

        SetFromPrivateKeyXmlToB58(keyPair.m_privateKeyOriginal);
    }
    [ContextMenu("Reload From Inspector B58")]
    public void ReloadFromInspectorB58()
    {

        SetFromRsaB58ToXML(keyPair.m_privateKeyB58);
    }

    public void SetFromRsaB58ToXML(string privateKeyXml)
    {
        Bit4096B58Pkcs1SHA256.CreateFromBase58PrivateKeyFormat(
            keyPair.m_privateKeyB58,
            out keyPair.m_publicAddressOriginal,
            out keyPair.m_privateKeyOriginal,
            out keyPair.m_publicKeyB58);

    }

    public void SetFromPrivateKeyXmlToB58(string privateKey) {

        Bit4096B58Pkcs1SHA256.CreateFromPrivateKeyXmlToBase58(
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
