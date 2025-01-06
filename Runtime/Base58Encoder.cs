using System;
using System.Linq;
using System.Numerics;
using System.Text;

public class Base58Encoder
{
    // Base58 Alphabet used by Bitcoin
    private static readonly string Base58Alphabet = "123456789ABCDEFGHJKLMNPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz";


    public static byte[] Base58Decode(string encoded)
    {
        BigInteger num = 0;
        for (int i = 0; i < encoded.Length; i++)
        {
            int charValue = Base58Alphabet.IndexOf(encoded[i]);
            if (charValue == -1)
            {
                throw new ArgumentException("Invalid Base58 character.");
            }
            num = num * 58 + charValue;
        }

        return num.ToByteArray().Reverse().ToArray();
    }
    public static string Base58DecodeFromUTF8(string encoded)
    {
        byte[] data = Base58Decode(encoded);
        return Encoding.UTF8.GetString(data);
    }

    public static string Base58EncodeToUTF8(string data)
    {
        byte[] bytes = Encoding.UTF8.GetBytes(data);
        return Base58Encode(bytes);
    }
    public static string Base58Encode(byte[] data)
    {
        // Convert the byte array to an integer
        BigInteger num = new BigInteger(data.Reverse().ToArray());
        StringBuilder encoded = new StringBuilder();

        // Encode the integer into Base58
        while (num > 0)
        {
            int remainder = (int)(num % 58);
            encoded.Insert(0, Base58Alphabet[remainder]);
            num /= 58;
        }

        // Handle leading zeros in the input byte array
        foreach (byte b in data)
        {
            if (b == 0)
            {
                encoded.Insert(0, Base58Alphabet[0]);
            }
            else
            {
                break;
            }
        }

        return encoded.ToString();
    }
}


