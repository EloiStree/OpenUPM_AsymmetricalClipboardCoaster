//public class EthMaskCreateSignVerify :  IEthMaskCreateSignVerify
//{
//    public void CreatePrivateKey(out string privateKey)
//    {
//        MaskSignerUtility.GeneratePrivateKey(out privateKey);
//    }

//    public void CreatePrivateKey(out IEthMaskPrivateKeyHolderGet privateKeyHolder)
//    {
//        MaskSignerUtility.GeneratePrivateKey(out string privateKey);
//        STRUCT_AssymetricPrivateKey structEthMaskPrivateKey = new STRUCT_AssymetricPrivateKey()
//        {
//            m_privateKey = privateKey
//        };
//        privateKeyHolder = structEthMaskPrivateKey;
//    }

//    public void GetClipboardableAsSplitMessage(string clipboardableSignedMessage, out string messageGivenToSign, out string claimedAddress, out string signedMessage)
//    {
//        MaskSignerUtility.SplitClipboardMessage(clipboardableSignedMessage, out messageGivenToSign, out claimedAddress, out signedMessage);
//    }

//    public void GetPublicAddress(IEthMaskPrivateKeyHolderGet privateKeyHolder, out string publicAddress)
//    {
//        MaskSignerUtility.GetPublicAddressFromPrivateKey(privateKeyHolder.GetPrivateKey(), out publicAddress);
//    }

//    public void IsVerifiedClipboardSignMessage(string clipboardableSignedMessage, out bool isVerified)
//    {
//        MaskSignerUtility.IsVerifiedClipboardSignMessage(clipboardableSignedMessage, out isVerified, out _, out _);
//    }

//    public void IsVerifiedClipboardSignMessage(string clipboardableSignedMessage, out bool isVerified, out string claimedAddress, out string recoveredAddress)
//    {
//        MaskSignerUtility.IsVerifiedClipboardSignMessage(clipboardableSignedMessage, out isVerified, out claimedAddress, out recoveredAddress);
//    }

//    public void SignMessageAsClipboardable(IEthMaskPrivateKeyHolderGet privateKeyHolder, string message, out string clipboardableSignedMessage)
//    {
//        MaskSignerUtility.GenerateClipboardSignMessage(privateKeyHolder.GetPrivateKey(), message, out clipboardableSignedMessage);
//    }
//}