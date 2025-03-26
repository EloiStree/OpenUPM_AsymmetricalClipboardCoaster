
using System;
using System.Security.Cryptography;
using System.Text;

/// <summary>
/// Assymentric tool to create a key pair, sign a message and verify a signed message
/// </summary>
public interface IAssymentricCreateSignVerify
{
    #region CREATE
    public void CreatePrivateKey(out IAsymmetricPrivateKeyHolderGet privateKeyHolder);
    #endregion

    #region SIGN
    public void SignMessageAsClipboardable(IAsymmetricPrivateKeyHolderGet privateKeyHolder, string message, out string clipboardableSignedMessage);
    #endregion




    #region VERIFY
    public void IsVerifiedClipboardSignMessage(string clipboardableSignedMessage, out bool isVerified);
    public void IsVerifiedClipboardSignMessage(string clipboardableSignedMessage, out bool isVerified, out string claimedAddress, out string recoveredAddress);
    #endregion

    #region UTILITY
    public void GetClipboardableAsSplitMessage(string clipboardableSignedMessage, out string messageGivenToSign, out string claimedAddress, out string signedMessage);
    #endregion
}
