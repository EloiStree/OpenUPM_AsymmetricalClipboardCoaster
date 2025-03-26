using System;
using UnityEngine;

public  class UrlAsymmetricSignerUtility<T> where T : IAssymentricCreateSignVerify , new() {

    public static T Signer = new T();

    public static string m_urlToSignOnlieMessageDefault= "https://eloistree.github.io/SignMetaMaskTextHere/index.html?q=";
    public static void ReplaceSignUrlDefault(string url)
    {
        m_urlToSignOnlieMessageDefault = url;
    }
    public static void OpenUrlToSignPublicAddress(string url)
    {
        Application.OpenURL(m_urlToSignOnlieMessageDefault + url);
    }

    public static void GenerateRandomPrivateKeyHolder(out STRUCT_AssymetricPrivateKey key)
    {
        Signer.CreatePrivateKey(out IAsymmetricPrivateKeyHolderGet privateKeyHolder);
        key = new STRUCT_AssymetricPrivateKey();
        key.m_privateKeyOriginal = privateKeyHolder.GetPrivateKeyInB58UrlFromat();
        key.m_publicAddressOriginal = privateKeyHolder.GetPublicAddressInB58UrlFormat();

    }

    public static void GenerateRandomPrivateKeyHolder(out IAsymmetricPrivateKeyHolderGet key)
    {
        Signer.CreatePrivateKey(out key);
    }


    public static void SignerAsClipboardable(IAsymmetricPrivateKeyHolderGet key, string message, out string clipboardableSignedMessage)
    {
        Signer.SignMessageAsClipboardable(key, message, out clipboardableSignedMessage);
    }

}
