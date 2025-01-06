using System;
using UnityEngine;

public  class MetaMaskSignerUtility<T> where T : IAssymentricMaskCreateSignVerify , new() {

    public static T Signer = new T();

    public static string m_metaMaskSignUrlDefault= "https://eloistree.github.io/SignMetaMaskTextHere/index.html?q=";
    public static void ReplaceMetaMaskSignUrlDefault(string url)
    {
        m_metaMaskSignUrlDefault = url;
    }
    public static void OpenUrlToSignPublicAddress(string url)
    {
        Application.OpenURL(m_metaMaskSignUrlDefault + url);
    }

    public static void GenerateRandomPrivateKeyHolder(out STRUCT_AssymetricPrivateKey key)
    {
        Signer.CreatePrivateKey(out IAsymmetricMaskPrivateKeyHolderGet privateKeyHolder);
        key = new STRUCT_AssymetricPrivateKey();
        key.m_privateKeyOriginal = privateKeyHolder.GetPrivateKeyInB58UrlFromat();
        key.m_publicAddressOriginal = privateKeyHolder.GetPublicAddressInB58UrlFormat();

    }

    public static void GenerateRandomPrivateKeyHolder(out IAsymmetricMaskPrivateKeyHolderGet key)
    {
        Signer.CreatePrivateKey(out key);
    }


    public static void SignerAsClipboardable(IAsymmetricMaskPrivateKeyHolderGet key, string message, out string clipboardableSignedMessage)
    {
        Signer.SignMessageAsClipboardable(key, message, out clipboardableSignedMessage);
    }

}
