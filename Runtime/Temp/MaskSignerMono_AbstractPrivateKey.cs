using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;




public abstract class MaskSignerMono_AbstractPrivateKey : MonoBehaviour, IAsymmetricMaskPrivateKeyHolderGet
{
    public abstract string GetPrivateKeyInB58UrlFromat();
    public abstract string GetPublicAddressInB58UrlFormat();
    public abstract string GetPrivateKeyInOrignalFormat();
    public abstract string GetPublicAddressInOrignalFormat();

    public void GetPrivateKey(out string privateKey) { 
    
        privateKey = GetPrivateKeyInB58UrlFromat();
    }

    public void GetPublicAddress(out string publicAddress) { 
    
        publicAddress = GetPublicAddressInB58UrlFormat();
    }

    protected void OpenUrlToSignPublicAddress() { 
    
        MetaMaskSignerRsa4096Utility.OpenUrlToSignPublicAddress(GetPublicAddressInB58UrlFormat());
    }

    public void GetPrivateKeyInB58UrlFromat(out string b58UrlPrivateKey)
    {
        b58UrlPrivateKey = GetPrivateKeyInB58UrlFromat();
    }

    public void GetPublicAddressInB58UrlFormat(out string b58UrlPublicAddress)
    {
        b58UrlPublicAddress = GetPublicAddressInB58UrlFormat();
    }

    public void GetPrivateKeyInOrignalFormat(out string privateKey)
    {
        privateKey = GetPrivateKeyInOrignalFormat();
    }

    public void GetPublicAddressInOrignalFormat(out string pbulicAddress)
    {
            pbulicAddress = GetPublicAddressInOrignalFormat();
    }
}

