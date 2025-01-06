using UnityEngine;


[System.Serializable]
public struct STRUCT_AssymetricPrivateKey : IAsymmetricMaskPrivateKeyHolderGet
{
    [TextArea(0, 10)]
    public string m_publicAddressOriginal;
    public string m_privateKeyOriginal;

    /// <summary>
    /// B58 format is a format that can be us in url.
    /// If you think the key is already usable in url, you can just copy paste it.
    /// </summary>
    [TextArea(0, 10)]
    public string m_publicKeyB58;
    public string m_privateKeyB58;

    public string GetPrivateKeyInB58UrlFromat()
    {
        return m_privateKeyB58;
    }

    public void GetPrivateKeyInB58UrlFromat(out string b58UrlPrivateKey)
    {
        b58UrlPrivateKey = m_privateKeyB58;
    }

    public string GetPrivateKeyInOrignalFormat()
    {
        return m_privateKeyOriginal;
    }

    public void GetPrivateKeyInOrignalFormat(out string privateKey)
    {
        privateKey = m_privateKeyOriginal;
    }

    public string GetPublicAddressInB58UrlFormat()
    {
        return m_publicKeyB58;
    }

    public void GetPublicAddressInB58UrlFormat(out string b58UrlPublicAddress)
    {
        b58UrlPublicAddress = m_publicKeyB58;
    }

    public string GetPublicAddressInOrignalFormat()
    {
        return m_publicAddressOriginal;
    }

    public void GetPublicAddressInOrignalFormat(out string pbulicAddress)
    {
        pbulicAddress = m_publicAddressOriginal;
    }
}
