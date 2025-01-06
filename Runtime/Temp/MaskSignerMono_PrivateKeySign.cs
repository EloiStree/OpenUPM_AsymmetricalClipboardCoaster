//using UnityEngine;

//public class MaskSignerMono_PrivateKeySign: MaskSignerMono_AbstractClipboardSigner
//{
//    public MaskSignerMono_AbstractPrivateKey m_privateKeyHolder;
//    public override void GetClipboardSignedMessage(string message, out string clipboardableSignedMessage)
//    {
//        if (m_privateKeyHolder == null)
//        {
//            clipboardableSignedMessage = "";
//            return;
//        }
//        string privateKey = ((IEthMaskPrivateKeyHolderGet)m_privateKeyHolder).GetPrivateKey();
//        MaskSignerUtility.GenerateClipboardSignMessage(privateKey, message, out clipboardableSignedMessage);
//    }
//}
