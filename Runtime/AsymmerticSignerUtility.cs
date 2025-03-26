



using System;

public static class AsymmerticSignerUtility
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