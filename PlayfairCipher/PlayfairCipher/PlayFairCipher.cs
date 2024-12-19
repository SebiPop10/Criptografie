using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayfairCipher
{
    internal class PlayFairCipher
    {
        private char[,] keyTable;

        public PlayFairCipher(string key)
        {
            keyTable = GenerateKeyTable(key);
        }

        private char[,] GenerateKeyTable(string key)
        {
            char[,] table = new char[5, 5];
            bool[] used = new bool[26];
            key = key.ToUpper().Replace("J", "I"); // Replace J with I as Playfair uses a 5x5 table

            int index = 0;
            foreach (char c in key)
            {
                if (char.IsLetter(c) && !used[c - 'A'])
                {
                    used[c - 'A'] = true;
                    table[index / 5, index % 5] = c;
                    index++;
                }
            }

            for (char c = 'A'; c <= 'Z'; c++)
            {
                if (c == 'J') continue;
                if (!used[c - 'A'])
                {
                    used[c - 'A'] = true;
                    table[index / 5, index % 5] = c;
                    index++;
                }
            }

            return table;
        }

        private (int, int) FindPosition(char c)
        {
            for (int row = 0; row < 5; row++)
            {
                for (int col = 0; col < 5; col++)
                {
                    if (keyTable[row, col] == c)
                    {
                        return (row, col);
                    }
                }
            }
            throw new Exception("Character not found in key table.");
        }

        private string ProcessText(string input, bool encrypt)
        {
            StringBuilder result = new StringBuilder();
            input = input.ToUpper().Replace("J", "I").Replace(" ", "");

            for (int i = 0; i < input.Length; i += 2)
            {
                char first = input[i];
                char second = (i + 1 < input.Length && input[i + 1] != first) ? input[i + 1] : 'X';

                if (i + 1 == input.Length || first == second)
                {
                    second = 'X';
                }

                (int row1, int col1) = FindPosition(first);
                (int row2, int col2) = FindPosition(second);

                if (row1 == row2) // Same row
                {
                    col1 = (col1 + (encrypt ? 1 : -1) + 5) % 5;
                    col2 = (col2 + (encrypt ? 1 : -1) + 5) % 5;
                }
                else if (col1 == col2) // Same column
                {
                    row1 = (row1 + (encrypt ? 1 : -1) + 5) % 5;
                    row2 = (row2 + (encrypt ? 1 : -1) + 5) % 5;
                }
                else // Rectangle swap
                {
                    int temp = col1;
                    col1 = col2;
                    col2 = temp;
                }

                result.Append(keyTable[row1, col1]);
                result.Append(keyTable[row2, col2]);
            }

            return result.ToString();
        }

        public string Encrypt(string plaintext)
        {
            return ProcessText(plaintext, true);
        }

        public string Decrypt(string ciphertext)
        {
            return ProcessText(ciphertext, false);
        }

        public void DisplayKeyTable()
        {
            for (int row = 0; row < 5; row++)
            {
                for (int col = 0; col < 5; col++)
                {
                    Console.Write(keyTable[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
