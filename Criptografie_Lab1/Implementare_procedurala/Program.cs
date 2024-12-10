using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Implementare_procedurala
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Introduceti textul: ");
            string text = Console.ReadLine();
            int key = int.Parse(Console.ReadLine());
            string ctext=CypherCezar(text, key);
            Console.WriteLine($"Textul criptat este: {ctext}");
            string dtext = DCypherCezar(ctext, key);
            Console.WriteLine($"Textul decriptat este: {dtext}");
        }

        private static string DCypherCezar(string ctext, int key)
        {
            string res = "";
            foreach (char c in ctext)
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

        private static string CypherCezar(string text, int key)
        {
            string res = "";
            foreach(char c in text)
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
        
    }
}
