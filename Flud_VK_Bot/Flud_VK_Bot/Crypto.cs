using System;
using System.Security.Cryptography;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Flud_VK_Bot
{
    class Crypto
    {
        private byte[] key = new byte[16];

        public void Gocrypt(string InputMessage)
        {
         try
         {
            FileStream myStream = new FileStream("myMessage.txt", FileMode.OpenOrCreate);

            Aes aes = Aes.Create();
            aes.GenerateKey();
            key = aes.Key;

            byte[] iv = aes.IV;
            myStream.Write(iv, 0, iv.Length);

            CryptoStream cryptStream = new CryptoStream(
                myStream,
                aes.CreateEncryptor(),
                CryptoStreamMode.Write);

            StreamWriter sWriter = new StreamWriter(cryptStream);
            sWriter.WriteLine(InputMessage);
            sWriter.Close();
            myStream.Close();

         }
            catch
            {
                Console.WriteLine("The encryption failed.");
                throw;
            }
        }

        public void GoEnrypt()
        {
            try
            {
                FileStream myStream = new FileStream("myMessage.txt", FileMode.Open);
                Aes aes = Aes.Create();

                byte[] iv = new byte[aes.IV.Length];
                myStream.Read(iv, 0, iv.Length);

                CryptoStream cryptStream = new CryptoStream(
                   myStream,
                   aes.CreateDecryptor(key, iv),
                   CryptoStreamMode.Read);


                StreamReader sReader = new StreamReader(cryptStream);
                Console.WriteLine("Друг -"+ sReader.ReadToEnd());
                sReader.Close();


                File.WriteAllText("myMessage.txt", String.Empty);
            }
            catch
            {
                Console.WriteLine("The decryption failed.");
                throw;
            }
        }
    }
}
