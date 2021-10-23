//Created by and copyright of Nicholas Edward Bailey 10/08/2021
//
//Simple encription class
//
//Encryption requires a unique identifier / passphrase provided during encryption and required to decrypt.
//Dont lose the identifier or you'll never get the data back.
//
//Pass data as a string by calling encrypt(data, identifier), returns a string of hexadecimal.
//Get data back by passing the encrypted hexstring through decrypt(hexstring, identifier), returns the data as a string.

using System;
using System.Text;
using System.Security.Cryptography;

    class encryption
    {
    /*
    static void Main(string[] args)
    {
    Start:
        Console.Clear();
        Console.WriteLine("=================");
        Console.WriteLine("Simple Encryption");
        Console.WriteLine("=================");
        Console.WriteLine("");
        Console.WriteLine("Select:");
        Console.WriteLine("-----------------");
        Console.WriteLine("    1. Encrypt");
        Console.WriteLine("    2. Decrypt");
        Console.WriteLine("    3. Generate SHA512 Hash string");
        Console.WriteLine("    4. Exit");
        Console.WriteLine("-----------------");
        Console.WriteLine("");
        Console.Write(">");
        int selection = Convert.ToInt32(Console.ReadLine());
        if (selection == 1)
        {
            enc();
        }
        else if (selection == 2)
        {
            dec();
        }
        else if (selection == 3)
        {
            hash();
        }
        else if (selection == 4)
        {
            goto Finish;
        }
        Console.WriteLine("");
        Console.WriteLine("Press any key to return to menu...");
        string close = Console.ReadLine();
        goto Start;
    Finish:
        return;
    }

    private static void enc()
    {
        Console.Clear();
        Console.WriteLine("Input a unique identifier/password/passphrase (Dont forget this as it is needed to decrypt)");
        Console.Write(">");
        string ident = Console.ReadLine();
        Console.Clear();
        Console.WriteLine("Input string to be encrypted");
        Console.Write(">");
        string str = encrypt(Console.ReadLine(), ident);
        Console.Clear();
        Console.WriteLine("================");
        Console.WriteLine("Encrypted String");
        Console.WriteLine("================");
        Console.WriteLine("");
        Console.WriteLine(str);
    }

    private static void dec()
    {
        Console.Clear();
        Console.WriteLine("Input unique identifier/password/passphrase that was used during encryption");
        Console.Write(">");
        string ident = Console.ReadLine();
        Console.Clear();
        Console.WriteLine("Input string to be decoded:");
        Console.Write(">");
        string str = decrypt(Console.ReadLine(), ident);
        Console.Clear();
        Console.WriteLine("==============");
        Console.WriteLine("Decoded String");
        Console.WriteLine("==============");
        Console.WriteLine("");
        Console.WriteLine(str);
    }


    private static void hash()
    {
        Console.Clear();
        Console.WriteLine("Input data to turn into SHA512 hash string");
        Console.Write(">");
        string str = computeHash512(Console.ReadLine());
        Console.Clear();
        Console.WriteLine("==============");
        Console.WriteLine("Hashed String");
        Console.WriteLine("==============");
        Console.WriteLine("");
        Console.WriteLine(str);
    }
    */
    public static string encrypt(string input, string ident)
        {
            ident = computeHash512(ident);
            return encryptAlg(input, ident);
        }

        public static string decrypt(string input, string ident)
        {
            ident = computeHash512(ident);
            return decryptAlg(input, ident);
        }

        public static string computeHash512(string message)
        {
            byte[] sourceBytes = Encoding.Default.GetBytes(message);
            byte[] hashBytes = null;

            hashBytes = SHA512Managed.Create().ComputeHash(sourceBytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.AppendFormat("{0:x2}", hashBytes[i]);
            }
            return sb.ToString();
        }

        private static string encryptAlg(string input, string ident)
        {
            string hexed = ToHexString(input);
            StringBuilder sb = new StringBuilder();
            for (int i = hexed.Length; i > 0; i--)
            {
                sb.Append(hexed.Substring(i - 1, 1));
            }
            sb.Append(ident);
            hexed = ToHexString(sb.ToString());
            sb.Clear();
            for (int i = hexed.Length; i > 0; i--)
            {
                sb.Append(hexed.Substring(i - 1, 1));
            }
            return sb.ToString();
        }

        private static string decryptAlg(string input, string ident)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                for (int i = input.Length; i > 0; i--)
                {
                    sb.Append(input.Substring(i - 1, 1));
                }

                input = FromHexString(sb.ToString());
                string check = input.Substring(input.Length - ident.Length, ident.Length);
                if (check != ident)
                {
                    return "!!!  *** *** Stop#Hacking *** *** !!!";
                }
                else
                {
                    input = input.Substring(0, input.Length - ident.Length);
                }
                sb.Clear();

                for (int i = input.Length; i > 0; i--)
                {
                    sb.Append(input.Substring(i - 1, 1));
                }
                input = FromHexString(sb.ToString());
                return input;
            }
            catch
            {
                return "!!!  *** *** Stop#Hacking *** *** !!!";
            }
        }

        private static string ToHexString(string str)
        {
            var sb = new StringBuilder();

            var bytes = Encoding.Unicode.GetBytes(str);
            foreach (var t in bytes)
            {
                sb.Append(t.ToString("X2"));
            }

            return sb.ToString();
        }

        private static string FromHexString(string hexString)
        {
            var bytes = new byte[hexString.Length / 2];
            for (var i = 0; i < bytes.Length; i++)
            {
                bytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            }

            return Encoding.Unicode.GetString(bytes);
        }
    }
