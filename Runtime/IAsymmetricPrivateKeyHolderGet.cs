
/// <summary>
/// All assymentric key holder have a private key and a public address or key
/// </summary>
public interface IAsymmetricPrivateKeyHolderGet
{
    string GetPrivateKeyInB58UrlFromat();
    string GetPublicAddressInB58UrlFormat();
    string GetPrivateKeyInOrignalFormat();
    string GetPublicAddressInOrignalFormat();
    void GetPrivateKeyInB58UrlFromat(out string b58UrlPrivateKey);
    void GetPublicAddressInB58UrlFormat(out string b58UrlPublicAddress);
    void GetPrivateKeyInOrignalFormat(out string privateKey);
    void GetPublicAddressInOrignalFormat(out string pbulicAddress);
}
