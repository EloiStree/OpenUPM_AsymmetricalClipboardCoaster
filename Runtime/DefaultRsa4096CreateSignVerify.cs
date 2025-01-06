using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

//https://www.browserling.com/tools/base58-decode
//https://www.browserling.com/tools/base58-encode
/// <summary>
/// Bit4096 because I only need to sign from time to time, so I can afford to have a big key
/// Pkcs1 because it is the most common
/// Sha256 because it is the most common
/// B58 because I need to be able to copy past in url.
/// </summary>
/// 
///https://raskeyconverter.azurewebsites.net/XmlToPem?handler=ConvertPEM
public class DefaultRsaCreateSignVerify_Bit4096_B58_Pkcs1_SHA256 : IAssymentricMaskCreateSignVerify
{
    [System.Serializable]
    public class RsaKeyPairHolder : IAsymmetricMaskPrivateKeyHolderGet
    {
        public string m_publicAddressAsB58;
        private string m_privateKeyAsB58;
        public string m_publicXml;
        private string m_privateXml;

        public string GetPrivateKeyInB58UrlFromat()
        {
            return m_privateKeyAsB58;
        }

        public string GetPublicAddressInB58UrlFormat()
        {
            return m_publicAddressAsB58;
        }

        public string GetPrivateKeyInOrignalFormat()
        {
            return m_privateXml;
        }

        public string GetPublicAddressInOrignalFormat()
        {
            return m_publicXml;
        }

        public void SetPrivateKeyB58(string privateKey)
        {
            m_privateKeyAsB58 = privateKey;
        }

        public void SetPublicAddressB58(string publicAddress)
        {
            m_publicAddressAsB58 = publicAddress;
        }

        public void SetPrivateKeyXml(string privateKey)
        {
            m_privateXml = privateKey;
        }

        public void SetPublicAddressXml(string publicAddress)
        {
            m_publicXml = publicAddress;
        }

        public void GetPrivateKeyInB58UrlFromat(out string b58UrlPrivateKey)
        {
            b58UrlPrivateKey = m_privateKeyAsB58;
        }

        public void GetPublicAddressInB58UrlFormat(out string b58UrlPublicAddress)
        {
            b58UrlPublicAddress = m_publicAddressAsB58;
        }

        public void GetPrivateKeyInOrignalFormat(out string privateKey)
        {
            privateKey = m_privateXml;
        }

        public void GetPublicAddressInOrignalFormat(out string pbulicAddress)
        {
            pbulicAddress = m_publicXml;
        }
    }
    public void CreatePrivateKey(out string privateKey)
    {
        using (var rsa = RSA.Create())
        {
            rsa.KeySize = KEY_SIZE;
            privateKey = rsa.ToXmlString(true);
        }
    }

    public const string m_startPublicKey = "pBit4096B58Pkcs1SHA256";
    public const string m_startPrivateKey = "PBit4096B58Pkcs1SHA256";
    public void CreatePrivateKey(out IAsymmetricMaskPrivateKeyHolderGet privateKeyHolder)
    {
        privateKeyHolder = null;
        using (var rsa = RSA.Create())
        {
            rsa.KeySize = KEY_SIZE;
            RsaKeyPairHolder holder = new RsaKeyPairHolder();
            string privateKey = rsa.ToXmlString(true);
            string publicAddress = rsa.ToXmlString(false);
            StringToB58(privateKey
                , out string b58PrivateKey);
            StringToB58(publicAddress
                , out string b58PublicAddress);
            holder.SetPrivateKeyB58(m_startPrivateKey + b58PrivateKey);
            holder.SetPublicAddressB58 (m_startPublicKey + b58PublicAddress);
            holder.SetPrivateKeyXml(privateKey);
            holder.SetPublicAddressXml(publicAddress);
            privateKeyHolder = holder;
        }
    }


    public static void IsTextB58Fromat(string text, out bool isB58,out  bool isPublic)
    {
        if (string.IsNullOrEmpty(text)) { 
            isB58 = false;
            isPublic = false;
            return;
        }
        isB58 = text.StartsWith(m_startPublicKey) || text.StartsWith(m_startPrivateKey);
        isPublic = text.StartsWith("p");
    }

    public void GetClipboardableAsSplitMessage(
        string clipboardableSignedMessage,
        out string messageGivenToSign,
        out string claimedAddress,
        out string signedMessage)
    {
        string[] parts = clipboardableSignedMessage.Split('|');
        if (parts.Length != 3)
        {
            messageGivenToSign = string.Empty;
            claimedAddress = string.Empty;
            signedMessage = string.Empty;
            return;
        }
        messageGivenToSign = parts[0].Trim();
        claimedAddress = parts[1].Trim();
        signedMessage = parts[2].Trim();
    }

    public void GetClipboardableCoasterAsSplitMessage(
        string clipboardable,
        out string messageGivenToSign,
        out string coasterPublicAddress,
        out string signedMessageByCoaster,
        out string masterPublicAddress,
        out string signedMessageByMaster)
    { 
        string[] parts = clipboardable.Split('|');
        if (parts.Length != 5)
        {
            messageGivenToSign = string.Empty;
            coasterPublicAddress = string.Empty;
            signedMessageByCoaster = string.Empty;
            masterPublicAddress = string.Empty;
            signedMessageByMaster = string.Empty;
            return;
        }
        messageGivenToSign = parts[0].Trim();
        coasterPublicAddress = parts[1].Trim();
        signedMessageByCoaster = parts[2].Trim();
        masterPublicAddress = parts[3].Trim();
        signedMessageByMaster = parts[4].Trim();
    }
    

    public void IsVerifiedClipboardSignMessage(string clipboardableSignedMessage, out bool isVerified)
    {
        GetClipboardableAsSplitMessage(clipboardableSignedMessage, 
            out string messageGivenToSign,
            out string claimedAddress,
            out string signedMessage);

        isVerified = VerifySignature(messageGivenToSign, claimedAddress, signedMessage);
       

    }

    public void IsVerifiedClipboardSignMessage(string clipboardableSignedMessage,
        out bool isVerified, 
        out string claimedAddress,
        out string recoveredAddress)
    {

        GetClipboardableAsSplitMessage(clipboardableSignedMessage,
            out string messageGivenToSign,
            out claimedAddress,
            out string signedMessage);

        isVerified = VerifySignature(messageGivenToSign, claimedAddress, signedMessage);
        recoveredAddress= isVerified?claimedAddress:string.Empty;

    }

    public void SignMessageAsClipboardable(IAsymmetricMaskPrivateKeyHolderGet privateKeyHolder
        , string message, out string clipboardableSignedMessage)
    {
       
        string signB58 = SignData(message, privateKeyHolder);
        clipboardableSignedMessage= $"{message}|{privateKeyHolder.GetPublicAddressInB58UrlFormat()}|{signB58}";
    }


    public const int KEY_SIZE = 4096;


    public static void GetXmlKeyPrivateFromB58(IAsymmetricMaskPrivateKeyHolderGet key, out string xmlKeyPrivate, out string xmlKeyPublic)
    {
        key.GetPublicAddressInOrignalFormat(out xmlKeyPublic);
        key.GetPrivateKeyInOrignalFormat(out xmlKeyPrivate);
    }



    public static string SignData(in string text, in IAsymmetricMaskPrivateKeyHolderGet keyPair)
    {
        UTF8ToBytes(text, out byte[] bytes);
        byte[] bytesSigned=  SignData(bytes, keyPair);
        BytesToB58(bytesSigned, out string utf8SignMessage);
        return utf8SignMessage;
    }

    public static byte[] SignData(in byte[] data, in IAsymmetricMaskPrivateKeyHolderGet keyPair)
    {
        keyPair.GetPrivateKeyInOrignalFormat(out string xmlPrivate);
        return SignData(data, xmlPrivate);
    }

    public static byte[] SignData(in byte[] data, in string xmlPrivate)
    {
        using (RSA rsa = RSA.Create())
        {
            rsa.KeySize = KEY_SIZE;
            rsa.FromXmlString(xmlPrivate);
            return rsa.SignData(data, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
        }
    }

    public static bool VerifySignatureB58(in string message, in string b58Signature, in IAsymmetricMaskPrivateKeyHolderGet keyPair)
    {
        UTF8ToBytes(message, out byte[] dataByteFromUtf);
        B58ToBytes(b58Signature, out byte[] signature);
        return VerifySignature(dataByteFromUtf, signature, keyPair);
    }
    
    public static bool VerifySignature(in byte[] data, in byte[] signature, IAsymmetricMaskPrivateKeyHolderGet keyPair)
    {
        keyPair.GetPublicAddressInOrignalFormat(out string xmlPublicKey);
        using (RSA rsa = RSA.Create())
        {
            rsa.KeySize = KEY_SIZE;
            rsa.FromXmlString(xmlPublicKey);
            return rsa.VerifyData(data, signature, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
        }
    }



    public static bool VerifySignature(in string message, in string publicAddress, in string b64Signature)
    {

        byte[] dataByteFromUtf = System.Text.Encoding.UTF8.GetBytes(message);
        B58ToBytes(b64Signature, out byte[] signature);
        return VerifySignature(dataByteFromUtf, signature, publicAddress);

    }

    public static bool VerifySignature(in byte[] dataUtf8, in byte[] signatureB64, in string publicKeyXml)
    {
        using (RSA rsa = RSA.Create())
        {
            rsa.KeySize = KEY_SIZE;
            rsa.FromXmlString(publicKeyXml);
            return rsa.VerifyData(dataUtf8, signatureB64, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
        }
    }
    //public static byte[] SignData(in byte[] data, in RSAParameters privateKey)
    //{

    //    using (RSA rsa = RSA.Create())
    //    {
    //        rsa.KeySize = KEY_SIZE;
    //        rsa.ImportParameters(privateKey);
    //        return rsa.SignData(data, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
    //    }
    //}
    //public static string SignData(in string data, in RSAParameters privateKey)
    //{
    //    B58ToBytes(data, out byte[] dataBytes);
    //    BytesToB58(SignData(dataBytes, privateKey), out string signMessage);
    //    return signMessage;
    //}



    public static void BytesToUTF8(byte[] bytes, out string utf8)
    {
        utf8 = System.Text.Encoding.UTF8.GetString(bytes);
    }
    public static void UTF8ToBytes(string utf8, out byte[] bytes)
    {
        bytes = System.Text.Encoding.UTF8.GetBytes(utf8);
    }

    public static void StringToB58(string str, out string b58)
    {
        b58 = Base58Encoder.Base58EncodeToUTF8(str);
    }
    public static void B58ToString(string b58, out string str)
    {
        str = Base58Encoder.Base58DecodeFromUTF8(b58);
    }

    public static void BytesToB58(byte[] bytes, out string b58)
    {
        b58 = Base58Encoder.Base58Encode(bytes); 
    }
    public static void B58ToBytes(string b58, out byte[] bytes)
    {
        bytes = Base58Encoder.Base58Decode(b58);
    }

}


