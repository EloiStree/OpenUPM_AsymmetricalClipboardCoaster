
//using Codice.CM.Common.Tree.Partial;
//using Nethereum.Signer;
//using System;
//using System.Security.Cryptography;





//public class MetaMaskSignCoasterUtility {

//    public static void GenerateClipboardSignCoasterMessage(
//        string messageToSign,
//        string publicAddressCoaster,
//        string signedMessageCoaster,
//        string publicAddressMaster,
//        string signedMarqueLetter,
//        out string clipboardableSignature)
//    {
//        clipboardableSignature = string.Join("|", messageToSign.Trim(), publicAddressCoaster.Trim(), signedMessageCoaster.Trim(), publicAddressMaster.Trim(), signedMarqueLetter.Trim());
//    }

//    public static void IsMaqueLetterValide(
//        IEthMaskCoasterMaqueLetter maqueLetterRef,
//        out bool isMaqueLetterValide)
//    {
//        isMaqueLetterValide = false;
//        if (maqueLetterRef == null)
//            return;
//        maqueLetterRef.GetCoasterAddress(out string coasterAddress);
//        maqueLetterRef.GetMasterAddress(out string masterAddress);
//        maqueLetterRef.GetSignedMarqueLetter(out string signedMarqueLetter);
//        if (string.IsNullOrEmpty(coasterAddress)) return;
//        if (string.IsNullOrEmpty(masterAddress)) return;
//        if (string.IsNullOrEmpty(signedMarqueLetter)) return;
//        isMaqueLetterValide = MaskSignerUtility.VerifySignedMessage(masterAddress, signedMarqueLetter, coasterAddress, out _);
//    }


//    public static void GenerateClipboardSignCoasterMessage(
//        IEthMaskPrivateKeyHolderGet coasterKey,
//        IEthMaskCoasterMaqueLetter maqueLetterRef,
//        in string message,
//        out string coasterSignedMessage)
//    {
//        coasterSignedMessage= "";

//        if (coasterKey == null || maqueLetterRef == null)
//        {
//            return;
//        }
//        IsMaqueLetterValide(maqueLetterRef, out bool isMaqueLetterValide);
//        if (!isMaqueLetterValide)
//        {
//            return;
//        }

//        string privateCoasterKey = coasterKey.GetPrivateKey();
//        MaskSignerUtility.GetPublicAddressFromPrivateKey(privateCoasterKey, out string coasterPublicAddress);
//        if (string.IsNullOrEmpty(coasterPublicAddress)) 
//            return;
//        MaskSignerUtility.GetSignedMessage(privateCoasterKey, message, out string messageSignedbyCoaster);

//        maqueLetterRef.GetMasterAddress(out string masterAddress);
//        maqueLetterRef.GetSignedMarqueLetter(out string signedMarqueLetter);
//        MetaMaskSignCoasterUtility.GenerateClipboardSignCoasterMessage(
//            message,
//            coasterPublicAddress,
//            messageSignedbyCoaster,
//            masterAddress,
//            signedMarqueLetter,
//            out coasterSignedMessage);
//    }

//    public static void OpenPageToSignCoaster(IAssymentricMaskPrivateKeyHolderGet keyHolder)
//    {
//        MaskSignerUtility.GetPublicAddressFromPrivateKey(keyHolder,out string address);
//        MaskSignerUtility.OpenPageToSignMessage(address);
//    }
//}

//public class MaskSignerUtility
//{

//    // Generate a clipboard message containing the original message, public address, and signed message
//    public static void GenerateClipboardSignMessage(IAssymentricMaskPrivateKeyHolderGet privateKey, string message, out string clipboardMessage)
//    {
//        GenerateClipboardSignMessage(privateKey.GetPrivateKey(), message, out clipboardMessage);
//    }
//    // Generate a clipboard message containing the original message, public address, and signed message
//    public static void GenerateClipboardSignMessage(string privateKey, string message, out string clipboardMessage)
//    {
//        GetSignedMessage(privateKey, message, out string signedMessage);
//        GetPublicAddressFromPrivateKey(privateKey, out string publicAddress);
//        clipboardMessage = $"{message}|{publicAddress}|{signedMessage}";
//    }



//    // Check if the clipboard message is verified
//    public static bool IsVerifiedClipboardSignMessage(string clipboardMessage)
//    {
//        IsVerifiedClipboardSignMessage(clipboardMessage, out bool isVerified, out _, out _);
//        return isVerified;
//    }

//    public static void SplitClipboardMessage(string clipboardMessage, out string message, out string claimedAddress, out string signedMessage)
//    {
//        string[] parts = clipboardMessage.Split('|');
//        message = parts.Length >= 1?parts[0]:"";
//        claimedAddress = parts.Length >= 2?parts[1]:"";
//        signedMessage = parts.Length >= 3?parts[2]:"";
//    }

//    // Retrieve verification details from the clipboard message
//    public static bool IsVerifiedClipboardSignMessage(
//        string clipboardMessage,
//        out bool isVerified,
//        out string claimedAddress,
//        out string recoveredAddress)
//    {
//        string[] parts = clipboardMessage.Split('|');

//        if (parts.Length != 3)
//        {
//            isVerified = false;
//            claimedAddress = string.Empty;
//            recoveredAddress = string.Empty;
//            return false;
//        }

//        string message = parts[0];
//        claimedAddress = parts[1];
//        string signedMessage = parts[2];

//        isVerified = VerifySignedMessage(claimedAddress, signedMessage, message, out recoveredAddress);
//        return true;
//    }

//    // Generate a new Ethereum private key
//    public static string GeneratePrivateKey(IMaskCreateSignerBuiler builder)
//    {
//        IAssymentricMaskCreateSignVerify created= builder.BuildSigner();
//        created.CreatePrivateKey(out string privateKey);
//        return privateKey;

//    }// Generate a new Ethereum private key
//    public static void GeneratePrivateKey(IMaskCreateSignerBuiler builder,out string privateKey)
//    {
//        GeneratePrivateKey(builder,  out privateKey);
//    }


//    public static void OpenPageToSignMessage(string messageToSign)
//    {
//        UnityEngine.Application.OpenURL("https://eloistree.github.io/SignMetaMaskTextHere/index.html?q="+messageToSign);
//    }

//    public static void GeneratePrivateKeyFromBytes(byte[] bytes, out string privateKey)
//    {
//        // Step 1: Hash the input bytes using SHA-256 to ensure a 32-byte value
//        using (SHA256 sha256 = SHA256.Create())
//        {
//            byte[] hash = sha256.ComputeHash(bytes);

//            // Step 2: Convert the hash into a hexadecimal string
//            privateKey = BitConverter.ToString(hash).Replace("-", "").ToLower();

//            // Step 3: Validate the private key (ensure it is 32 bytes in length)
//            if (privateKey.Length != 64) // 64 hex characters = 32 bytes
//            {
//                throw new InvalidOperationException("Invalid private key length. Must be 32 bytes.");
//            }
//        }
//    }
//}



using System;

public static class MaskSignerUtility
{
    public static string m_defaultSignerJavascript = "https://eloistree.github.io/SignMetaMaskTextHere/index.html?q=";
    public static void OpenPageToSignMessageWithMetaMask(string messageToSignWithMetaMask)
    {
        UnityEngine.Application.OpenURL(m_defaultSignerJavascript + messageToSignWithMetaMask);
    }
    public static void OpenPageToSignMessageWithMetaMask(string messageToSignWithMetaMask, string urlQ)
    {
        UnityEngine.Application.OpenURL(urlQ + messageToSignWithMetaMask);
    }

    public static void MergeClipboard(
        string messageSigned,
        string publicAddress, 
        string signedMessage, 
        string masterMetaMaskAddress, 
        string signedMarqueLetterByMetaMask,
        out string mergeAsClipboard)
    {
        mergeAsClipboard = string.Join("|\n", messageSigned.Trim(), publicAddress.Trim(), signedMessage.Trim(), masterMetaMaskAddress.Trim(), signedMarqueLetterByMetaMask.Trim());
    }

    public static void MergeClipboard(
        string messageSigned,
        string publicAddress,
        string signedMessage,
        out string mergeAsClipboard)
    {
        mergeAsClipboard = string.Join("|\n", messageSigned.Trim(), publicAddress.Trim(), signedMessage.Trim());
    }


    internal static void SplitClipbard(string signedMessageAsClipboard, out string messageSigned, out string publicAddress, out string signedMessage)
    {
        string[] splits = signedMessageAsClipboard.Split('|');
        if (splits.Length >= 1)
            messageSigned = splits[0].Trim();
        else
            messageSigned = "";

        if (splits.Length >= 2)
            publicAddress = splits[1].Trim();
        else
            publicAddress = "";

        if (splits.Length >= 3)
            signedMessage = splits[2].Trim();
        else
            signedMessage = "";
    }

    public static void SplitClipboard(string clipboardText, 
        out string message,
        out string publicAddressCoaster,
        out string signedMessageCoaster,
        out string masterPublicAddress,
        out string coasterAddressSignedMessageByMaster)
    {

        string[] splitToken = clipboardText.Split('|');
        if (splitToken.Length >= 1)
            message = splitToken[0].Trim();
        else
            message = "";
        if (splitToken.Length >= 2)
            publicAddressCoaster = splitToken[1].Trim();
        else
            publicAddressCoaster = "";
        if (splitToken.Length >= 3)
            signedMessageCoaster = splitToken[2].Trim();
        else
            signedMessageCoaster = "";
        if (splitToken.Length >= 4)
            masterPublicAddress = splitToken[3].Trim();
        else
            masterPublicAddress = "";
        if (splitToken.Length >= 5)
            coasterAddressSignedMessageByMaster = splitToken[4].Trim();
        else
            coasterAddressSignedMessageByMaster = "";


    }
}