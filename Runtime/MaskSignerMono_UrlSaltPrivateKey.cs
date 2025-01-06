using System;
using System.Net;
using System.Text;
using UnityEngine;






public abstract class MaskSignerMono_PrivateKeyHolder<T>: MaskSignerMono_AbstractPrivateKey  where T:  IAssymentricMaskCreateSignVerify,new()
{
    public static T tool = new T();
    public STRUCT_AssymetricPrivateKey keyPair;
   
  
    protected void Build() {
        tool.CreatePrivateKey(out IAsymmetricMaskPrivateKeyHolderGet privateKeyHolder);
        keyPair.m_privateKeyB58 = (privateKeyHolder.GetPrivateKeyInB58UrlFromat());
        keyPair.m_publicKeyB58 = (privateKeyHolder.GetPublicAddressInB58UrlFormat());
        keyPair.m_publicAddressOriginal = privateKeyHolder.GetPublicAddressInOrignalFormat();
        keyPair.m_privateKeyOriginal = privateKeyHolder.GetPrivateKeyInOrignalFormat();
    }
    public override string GetPrivateKeyInB58UrlFromat()
    {
        return keyPair.m_privateKeyB58;
    }

    public override string GetPublicAddressInB58UrlFormat()
    {
        return keyPair.m_publicKeyB58;
    }

    public override string GetPublicAddressInOrignalFormat()
    {
        return keyPair.m_publicAddressOriginal;
    }

    public override string GetPrivateKeyInOrignalFormat()
    {
        return keyPair.m_privateKeyOriginal;
    }
}

