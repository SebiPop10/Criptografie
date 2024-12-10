using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Criptografie_lab2
{
    public class VigenereCypher
    {
        private string key;

        public VigenereCypher(string key)
        {
            this.key = key.ToUpper(); 
        }

        
        public string Encrypt(string plaintext)
        {
            string ciphertext = "";
            plaintext = plaintext.ToUpper(); 
            int keyIndex = 0;

            for (int i = 0; i < plaintext.Length; i++)
            {
                char currentChar = plaintext[i];

                
                if (char.IsLetter(currentChar))
                {
                    int letterPosition = currentChar - 'A';
                    int keyPosition = key[keyIndex % key.Length] - 'A';

                    
                    char encryptedChar = (char)((letterPosition + keyPosition) % 26 + 'A');
                    ciphertext += encryptedChar;

                    keyIndex++; 
                }
                else
                {
                    
                    ciphertext += currentChar;
                }
            }

            return ciphertext;
        }

       
        public string Decrypt(string ciphertext)
        {
            string plaintext = "";
            ciphertext = ciphertext.ToUpper(); 
            int keyIndex = 0;

            for (int i = 0; i < ciphertext.Length; i++)
            {
                char currentChar = ciphertext[i];

                
                if (char.IsLetter(currentChar))
                {
                    int letterPosition = currentChar - 'A';
                    int keyPosition = key[keyIndex % key.Length] - 'A';

                    
                    char decryptedChar = (char)((letterPosition - keyPosition + 26) % 26 + 'A');
                    plaintext += decryptedChar;

                    keyIndex++; 
                }
                else
                {
                    
                    plaintext += currentChar;
                }
            }

            return plaintext;
        }
    }
}
