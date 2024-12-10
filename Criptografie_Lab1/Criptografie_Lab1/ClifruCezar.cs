using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Criptografie_Lab1
{
    public class ClifruCezar
    {
        int key;
        string text;
        public ClifruCezar(string text, int key)
        {
            this.text = text;
            this.key = key;
        }
        public string Encrypt(string text)
        {
            string res = "";
            foreach (char c in text)
            {
                if (c >= 'a' && c <= 'z')
                    res += (char)((c - 'a' + key) % 26 + 'a');
                else
                    if (c >= 'A' && c <= 'Z')
                    res += (char)((c - 'A' + key) % 26 + 'A');
                else
                    res += c;
            }
            return res;
        }
        public string Decrypt(string text)
        {
            string res = "";
            foreach (char c in text)
            {
                if (c >= 'a' && c <= 'z')
                    res += (char)((c - 'a' - key) % 26 + 'a');
                else
                    if (c >= 'A' && c <= 'Z')
                    res += (char)((c - 'A' - key) % 26 + 'A');
                else
                    res += c;
            }
            return res;
        }
    }
}
