using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cilindrul_Jefferson
{
    internal class Program
    {
        static Random random = new Random();
        static void Main(string[] args)
        {
            Console.Write("Introduceti numărul de discuri: ");
            int n = int.Parse(Console.ReadLine());

            // Generăm discurile și cheia de criptare
            char[][] discs = GenerateDiscs(n);
            int[] key = GenerateKey(n);

            Console.WriteLine("\nDiscuri generate:");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Disc {i + 1}: {new string(discs[i])}");
            }

            Console.WriteLine("\nCheia de criptare: " + string.Join(", ", key));

            Console.Write("\nIntroduceti textul pentru criptare (doar litere, fără spatii): ");
            string plaintext = Console.ReadLine().ToUpper();

            string encrypted = Encrypt(plaintext, discs, key);
            Console.WriteLine($"\nText criptat: {encrypted}");

            string decrypted = Decrypt(encrypted, discs, key);
            Console.WriteLine($"Text decriptat: {decrypted}");
        }
        static char[][] GenerateDiscs(int n)
        {
            char[][] discs = new char[n][];
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            for (int i = 0; i < n; i++)
            {
                discs[i] = alphabet.OrderBy(_ => random.Next()).ToArray();
            }

            return discs;
        }

        static int[] GenerateKey(int n)
        {
            return Enumerable.Range(1, n).OrderBy(_ => random.Next()).ToArray();
        }

        static string Encrypt(string plaintext, char[][] discs, int[] key)
        {
            char[] encrypted = new char[plaintext.Length];

            for (int i = 0; i < plaintext.Length; i++)
            {
                int discIndex = key[i % key.Length] - 1;
                char[] disc = discs[discIndex];

                int position = Array.IndexOf(disc, plaintext[i]);
                encrypted[i] = disc[(position + 1) % 26];
            }

            return new string(encrypted);
        }

        static string Decrypt(string ciphertext, char[][] discs, int[] key)
        {
            char[] decrypted = new char[ciphertext.Length];

            for (int i = 0; i < ciphertext.Length; i++)
            {
                int discIndex = key[i % key.Length] - 1;
                char[] disc = discs[discIndex];

                int position = Array.IndexOf(disc, ciphertext[i]);
                decrypted[i] = disc[(position - 1 + 26) % 26];
            }

            return new string(decrypted);
        }
    }
}
