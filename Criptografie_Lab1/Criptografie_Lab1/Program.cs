// See https://aka.ms/new-console-template for more information
//Oper de criptare/decriptare/criptanaliza. Cifrul lui Cezar, Cifrul +n
using Criptografie_Lab1;

Console.WriteLine("Introduceti textul: ");
string line = Console.ReadLine();
Console.WriteLine("Introduceti cheia: ");
int n = int.Parse(Console.ReadLine());

ClifruCezar c = new ClifruCezar(line, n);
Console.WriteLine("Textul criptat este: ");
string ctext = c.Encrypt(line);
Console.WriteLine(ctext);
Console.WriteLine("Textul decriptat este: ");
string dtext = c.Decrypt(ctext);
Console.WriteLine(dtext);

