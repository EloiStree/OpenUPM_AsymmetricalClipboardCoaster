using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

public class SleepyTest_PrivateKeyRsaToPublic : MonoBehaviour
{
    [TextArea(0,6)]
    public string m_privateKeyXmlAtStart;
    [TextArea(0, 6)]
    public string m_shoulddBePublicKeyXml;

    [TextArea(0, 6)]
    public string m_privateXml;
    [TextArea(0,6)]
    public string m_foundPublicKeyXml;
    public bool areEqual;

    [TextArea(0, 6)]
    public string m_pkcs8;


    public string m_message="Hello World!";
    public string m_signeMessage;



    [ContextMenu("Process")]
    public void Process()
    {
        try
        {
            RSA rsa = RSA.Create();
            rsa.FromXmlString(m_privateXml);
            rsa.KeySize = 2048;
            m_foundPublicKeyXml = rsa.ToXmlString(false);

            areEqual = m_shoulddBePublicKeyXml == m_foundPublicKeyXml;

           
            byte[] data = System.Text.Encoding.UTF8.GetBytes(m_message);
            byte[] signature = rsa.SignData(data, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
            m_signeMessage = Convert.ToBase64String(signature);
        }
        catch (Exception ex)
        {
            Debug.LogError($"An error occurred: {ex.Message}");
        }
    }




}
