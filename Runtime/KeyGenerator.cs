using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

public class KeyGenerator : MonoBehaviour
{
    [TextArea(0, 16)]
    public string pemPrivate;
    [TextArea(0, 16)]
    public string pemPublic;

    [ContextMenu("Create Pem")]
    public void CreatePem()
    {
        using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(2048)) // 2048-bit RSA
        {
            // Export private key in PEM format
            pemPrivate = ExportPrivateKeyToPem(rsa);
            // Export public key in PEM format
            pemPublic = ExportPublicKeyToPem(rsa);
        }
    }

    public static string ExportPrivateKeyToPem(RSA rsa)
    {
        // Export the private key in PKCS#8 format
        var privateKeyBytes = rsa.ExportPkcs8PrivateKey();

        StringBuilder sb = new StringBuilder();
        sb.AppendLine("-----BEGIN PRIVATE KEY-----");
        sb.AppendLine(Convert.ToBase64String(privateKeyBytes, Base64FormattingOptions.InsertLineBreaks));
        sb.AppendLine("-----END PRIVATE KEY-----");

        return sb.ToString();
    }

    public static string ExportPublicKeyToPem(RSA rsa)
    {
        // Export the public key in SubjectPublicKeyInfo (X.509) format
        var publicKeyBytes = rsa.ExportSubjectPublicKeyInfo();

        StringBuilder sb = new StringBuilder();
        sb.AppendLine("-----BEGIN PUBLIC KEY-----");
        sb.AppendLine(Convert.ToBase64String(publicKeyBytes, Base64FormattingOptions.InsertLineBreaks));
        sb.AppendLine("-----END PUBLIC KEY-----");

        return sb.ToString();
    }
}
