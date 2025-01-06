//public class MaskSignerMono_PrivateKeyAtAbsolutePath : MaskSignerMono_AbstractPrivateKey
//{

//    public string m_absolutePathPrivateKey = "";
//    public override string GetPrivateKey()
//    {
//        if (string.IsNullOrEmpty(m_absolutePathPrivateKey))
//            return "";
//        if (!System.IO.File.Exists(m_absolutePathPrivateKey))
//            return "";
//        return System.IO.File.ReadAllText(m_absolutePathPrivateKey);
//    }

//    public override string GetPublicAddress()
//    {
//        throw new System.NotImplementedException();
//    }
//}
