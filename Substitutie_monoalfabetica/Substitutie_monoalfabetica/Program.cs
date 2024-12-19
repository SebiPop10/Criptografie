using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substitutie_monoalfabetica
{
    internal class Program
    {
        private static Random random = new Random();

        
        public static string GenerateRandomKey()
        {
            const string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(alphabet.OrderBy(c => random.Next()).ToArray());
        }

        
        public static string Encrypt(string plaintext, string key)
        {
            const string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var cipherText = new StringBuilder();

            foreach (char c in plaintext.ToUpper())
            {
                if (alphabet.Contains(c))
                    cipherText.Append(key[alphabet.IndexOf(c)]);
                else
                    cipherText.Append(c); 
            }

            return cipherText.ToString();
        }

        
        public static string Decrypt(string cipherText, string key)
        {
            const string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var plaintext = new StringBuilder();

            foreach (char c in cipherText.ToUpper())
            {
                if (key.Contains(c))
                    plaintext.Append(alphabet[key.IndexOf(c)]);
                else
                    plaintext.Append(c); 
            }

            return plaintext.ToString();
        }

      
        public static string Cryptanalysis(string cipherText, Dictionary<char, double> languageFrequencies)
        {
            const string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            
            var cipherFrequencies = new Dictionary<char, double>();
            foreach (char c in alphabet)
                cipherFrequencies[c] = 0;

            int totalLetters = 0;
            foreach (char c in cipherText.ToUpper())
            {
                if (alphabet.Contains(c))
                {
                    cipherFrequencies[c]++;
                    totalLetters++;
                }
            }

            foreach (char c in alphabet)
                cipherFrequencies[c] = cipherFrequencies[c] / totalLetters;

            
            var sortedCipher = cipherFrequencies.OrderByDescending(kv => kv.Value).Select(kv => kv.Key).ToList();
            var sortedLanguage = languageFrequencies.OrderByDescending(kv => kv.Value).Select(kv => kv.Key).ToList();

            var decryptionKey = new char[alphabet.Length];
            for (int i = 0; i < alphabet.Length; i++)
            {
                decryptionKey[alphabet.IndexOf(sortedCipher[i])] = sortedLanguage[i];
            }

           
            return Decrypt(cipherText, new string(decryptionKey));
        }
        static void Main(string[] args)
        {
            // Exemplu de utilizare
            const string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            // Frecvențele literelor în limba engleză
            var englishFrequencies = new Dictionary<char, double>
        {
            {'A', 8.17}, {'B', 1.49}, {'C', 2.78}, {'D', 4.25}, {'E', 12.70}, {'F', 2.23},
            {'G', 2.02}, {'H', 6.09}, {'I', 6.97}, {'J', 0.15}, {'K', 0.77}, {'L', 4.03},
            {'M', 2.41}, {'N', 6.75}, {'O', 7.51}, {'P', 1.93}, {'Q', 0.10}, {'R', 5.99},
            {'S', 6.33}, {'T', 9.06}, {'U', 2.76}, {'V', 0.98}, {'W', 2.36}, {'X', 0.15},
            {'Y', 1.97}, {'Z', 0.07}
        };

            string key = GenerateRandomKey();
            Console.WriteLine($"Cheia de criptare: {key}");

            string plaintext = "CRIPTOGRAFIE";
            Console.WriteLine($"Textul original: {plaintext}");

            string cipherText = Encrypt(plaintext, key);
            Console.WriteLine($"Textul criptat: {cipherText}");

            string decryptedText = Decrypt(cipherText, key);
            Console.WriteLine($"Textul decriptat: {decryptedText}");

            string crackedText = Cryptanalysis(cipherText, englishFrequencies);
            Console.WriteLine($"Textul obtinut prin criptanaliză: {crackedText}");
        }
    }
}
