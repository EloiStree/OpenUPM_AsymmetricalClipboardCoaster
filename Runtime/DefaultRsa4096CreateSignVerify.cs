using Eloi;
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
        Bit4096B58Pkcs1SHA256.CreateXmlRsa4096PrivateKey(out privateKey);
    }

    public void CreatePrivateKey(out IAsymmetricMaskPrivateKeyHolderGet privateKeyHolder)
    {
        Bit4096B58Pkcs1SHA256.CreatePrivateKeyAsBase58(
            out string privateKey,
            out string publicKey,
            out string privateKeyBase58,
            out string publicKeyBase58
            );
        RsaKeyPairHolder holder = new RsaKeyPairHolder();
        holder.SetPrivateKeyB58(privateKeyBase58);
        holder.SetPublicAddressB58(publicKeyBase58);
        holder.SetPrivateKeyXml(privateKey);
        holder.SetPublicAddressXml(publicKey);
        privateKeyHolder = holder;
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

    public static void GetXmlKeyPrivateFromB58(IAsymmetricMaskPrivateKeyHolderGet key, out string xmlKeyPrivate, out string xmlKeyPublic)
    {
        key.GetPublicAddressInOrignalFormat(out xmlKeyPublic);
        key.GetPrivateKeyInOrignalFormat(out xmlKeyPrivate);
    }



    public static string SignData(in string text, in IAsymmetricMaskPrivateKeyHolderGet keyPair)
    {
        Bit4096B58Pkcs1SHA256.SignTextUtf8ToTextBase58(text, keyPair.GetPrivateKeyInOrignalFormat(), out string signatureBase58);
        return signatureBase58;
    }

    public static byte[] SignData(in byte[] data, in IAsymmetricMaskPrivateKeyHolderGet keyPair)
    {
        keyPair.GetPrivateKeyInOrignalFormat(out string xmlPrivate);
        return SignData(data, xmlPrivate);
    }

    public static byte[] SignData(in byte[] data, in string xmlPrivate)
    {
        Bit4096B58Pkcs1SHA256.SignDataWithRsaXmlPrivateKey(data, xmlPrivate, out byte[] signature);
        return signature;
    }

    public static bool VerifySignatureB58(in string message, in string b58Signature, in IAsymmetricMaskPrivateKeyHolderGet keyPair)
    {
        return Bit4096B58Pkcs1SHA256
            .VerifySignatureFromB58Signature(
            message,
            b58Signature,
            keyPair.GetPublicAddressInOrignalFormat()
            );
    }
    
    public static bool VerifySignature(in byte[] data, in byte[] signature, IAsymmetricMaskPrivateKeyHolderGet keyPair)
    {
        
        return Bit4096B58Pkcs1SHA256
            .VerifySignatureFromRawBytes(
            data,
            signature,
            keyPair.GetPublicAddressInOrignalFormat()
            );
    }



    public static bool VerifySignature(in string message, in string publicAddress, in string b64Signature)
    {
        return Bit4096B58Pkcs1SHA256
            .VerifySignatureFromB58Signature(
            message,
            b64Signature,
            publicAddress
            );

    }

    public static bool VerifySignature(in byte[] dataUtf8, in byte[] signatureAsBytes, in string publicKeyXml)
    {
       
        return Bit4096B58Pkcs1SHA256
            .VerifySignatureFromRawBytes(
            dataUtf8,
            signatureAsBytes,
            publicKeyXml
            );
    }
    
}


