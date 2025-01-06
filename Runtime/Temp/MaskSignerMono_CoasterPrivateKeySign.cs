using UnityEngine;

public class MaskSignerMono_CoasterPrivateKeySign : MaskSignerMono_AbstractClipboardSigner
{
    public MaskSignerMono_AbstractClipboardSigner m_privateKeySigner;
    public string m_marqueLetterCliboardText;
    public STRUCT_MetaMaskCoasterLetterMarque m_markLetter;
    public string m_masterToCoasterId;

    private void OnValidate()
    {
        if (m_marqueLetterCliboardText!="")
        {
            string[] splitToken = m_marqueLetterCliboardText.Split('|');
            if (splitToken.Length>=1)
            m_markLetter.m_coasterAddress = splitToken[0];
            if (splitToken.Length>=2)
            m_markLetter.m_masterAddress = splitToken[1];
            if (splitToken.Length>=3)
            m_markLetter.m_signedMarqueLetter = splitToken[2];
            m_masterToCoasterId = m_markLetter.m_masterAddress + ">"+ m_markLetter.m_coasterAddress;
            m_marqueLetterCliboardText= "";
        }
    }

    public override void GetClipboardSignedMessage(string message, out string coasterSignedMessage)
    {
        m_privateKeySigner.GetClipboardSignedMessage(message, out coasterSignedMessage);

        int signLenght = coasterSignedMessage.Split('|').Length;

        if ( signLenght== 5) {

            return;
        }
        if (signLenght == 3)
        {
            MaskSignerUtility.SplitClipbard(coasterSignedMessage,
             out string messageToSigned,
             out string publicAddress,
             out string signedMessage);
            MaskSignerUtility.MergeClipboard( 
                messageToSigned,
                publicAddress ,
                signedMessage,
                m_markLetter.m_masterAddress,
                m_markLetter.m_signedMarqueLetter,
                out coasterSignedMessage);               
                return;
        }
    }

    [ContextMenu("Create letter marque")]
    public void OpenUrlToCreateLetterMarque()
    {
        m_privateKeySigner.GetClipboardSignedMessage("Hello", out string message);
        MaskSignerUtility.SplitClipbard(message,
         out string messageToSigned,
         out string publicAddress,
         out string signedMessage);
        MaskSignerUtility.OpenPageToSignMessageWithMetaMask(publicAddress);
    }
}
