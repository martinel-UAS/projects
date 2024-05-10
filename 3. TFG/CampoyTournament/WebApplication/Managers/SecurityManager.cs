using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace WebApplication.Managers
{
    public class SecurityManager
    {
        // All methods are static, so this can be private
        private SecurityManager()
        { }

        public static string Encrypt(string plainText)
        {

            //Inicializo variables utilizadas en la encriptacion

            string passPhrase = "Pas5pr@se";        // cualquier string
            string saltValue = "s@1tValue";         // cualquier string
            string hashAlgorithm = "SHA1";          // puede ser "MD5"
            int passwordIterations = 2;             // cualquier int
            string initVector = "@1B2c3D4e5F6g7H8"; // debe ser 16 bytes
            int keySize = 256;                      // puede ser 192 or 128

            /*  
             * Convierte strings en array de bytes. Se asume que la cadena
             * string solo contiene codigo ASCII
            */
            byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
            byte[] saltValueBytes = Encoding.ASCII.GetBytes(saltValue);

            /*
             * Convierte texto plano en array de bytes. Se asume la utilizacion
             * de caracteres UTF8-encoded
             */
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            /*
             * Primero, se crea el password. Este password se genera desde 
             * las variables passphrase y salt value, usando un algoritmo
             * hash. El password puede ser creado en varias iteraciones.
             */
            PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase,
                                                                   saltValueBytes,
                                                                   hashAlgorithm,
                                                                   passwordIterations);

            byte[] keyBytes = password.GetBytes(keySize / 8);

            // Clase utilizada para la encriptacion - Metodo Rijndael
            RijndaelManaged symmetricKey = new RijndaelManaged();

            symmetricKey.Mode = CipherMode.CBC;

            //Genero el encriptador
            ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);

            MemoryStream memoryStream = new MemoryStream();

            CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);

            // Se comienza a encriptar.
            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);

            // Termina de encriptar.
            cryptoStream.FlushFinalBlock();

            byte[] cipherTextBytes = memoryStream.ToArray();

            // Cierro stream
            memoryStream.Close();
            cryptoStream.Close();

            //Convierto los datos encriptados a un string base64-encoded.
            string cipherText = Convert.ToBase64String(cipherTextBytes);

            return cipherText;
        }


        /*
         * Metodo para desencriptar contraseñas. Proceso analogo al de encriptar.
         */
        public static string Decrypt(string cipherText)
        {
            //Inicializo variables para la desencriptacion

            string passPhrase = "Pas5pr@se";        // cualquier string
            string saltValue = "s@1tValue";         // cualquier string
            string hashAlgorithm = "SHA1";          // puede ser "MD5"
            int passwordIterations = 2;          // cualquier int
            string initVector = "@1B2c3D4e5F6g7H8"; // debe ser 16 bytes
            int keySize = 256;                   // puede ser 192 or 128

            byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
            byte[] saltValueBytes = Encoding.ASCII.GetBytes(saltValue);
            byte[] cipherTextBytes = Convert.FromBase64String(cipherText);

            PasswordDeriveBytes password = new PasswordDeriveBytes(
                                                            passPhrase,
                                                            saltValueBytes,
                                                            hashAlgorithm,
                                                            passwordIterations);


            byte[] keyBytes = password.GetBytes(keySize / 8);

            RijndaelManaged symmetricKey = new RijndaelManaged();

            symmetricKey.Mode = CipherMode.CBC;

            ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);

            MemoryStream memoryStream = new MemoryStream(cipherTextBytes);

            CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);

            byte[] plainTextBytes = new byte[cipherTextBytes.Length];

            // Comienza a desencriptar
            int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);

            memoryStream.Close();
            cryptoStream.Close();

            //Se convierte los datos desencriptados a strings. Se asume que se utilizo UTF8-encoded
            string plainText = Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);

            return plainText;
        }
    }
}