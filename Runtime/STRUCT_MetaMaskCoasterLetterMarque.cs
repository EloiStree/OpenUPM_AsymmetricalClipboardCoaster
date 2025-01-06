
//using Codice.CM.Common.Tree.Partial;
//using Nethereum.Signer;
//using System;
//using System.Security.Cryptography;




[System.Serializable]
public struct STRUCT_MetaMaskCoasterLetterMarque : IMetaMaskCoasterLetterMarqueGet
{

    /// <summary>
    ///  What is the master flag address of the privateer
    /// </summary>
    public string m_masterAddress;
    /// <summary>
    /// What public address the privateer is using and signed in the past
    /// <\summary>
    public string m_coasterAddress;
    /// <summary>
    /// Message using privateer address signed in the past by the master private key
    /// At least once in the past the master private key signed a message with the privateer address
    /// Giving him the authority to sign message on his behalf
    /// </summary>
    public string m_signedMarqueLetter;

    public void GetCoasterAddress(out string coasterAddress)
    {
        coasterAddress = m_coasterAddress;
    }

    public void GetMasterAddress(out string masterAddress)
    {
        masterAddress = m_masterAddress;
    }

    public void GetSignedMarqueLetter(out string signedMarqueLetter)
    {
        signedMarqueLetter = m_signedMarqueLetter;
    }
}
