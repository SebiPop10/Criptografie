// See https://aka.ms/new-console-template for more information
//Cifrul Vigenere. Cifrul substitutie polialfabetica

//Console.WriteLine("Introduceti textul: ");
//Console.WriteLine("Introduceti cheia: ");
//Console.WriteLine("Textul criptat este: ");
//Console.WriteLine("Textul decriptat este: ");
// Exemplu de utilizare
using Criptografie_lab2;

VigenereCypher cipher = new VigenereCypher("oculorhinolaringology");

string textDeCriptat = "attacking tonight";
string criptat = cipher.Encrypt(textDeCriptat);
Console.WriteLine("Text criptat: " + criptat);

string decriptat = cipher.Decrypt(criptat);
Console.WriteLine("Text decriptat: " + decriptat);
