// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using PlayfairCipher;

Console.WriteLine("Enter the key:");
string key = Console.ReadLine();

PlayFairCipher cipher=new PlayFairCipher(key);  

Console.WriteLine("Key Table:");
cipher.DisplayKeyTable();

Console.WriteLine("Enter the text to encrypt:");
string plaintext = Console.ReadLine();

string encryptedText = cipher.Encrypt(plaintext);
Console.WriteLine($"Encrypted Text: {encryptedText}");

string decryptedText = cipher.Decrypt(encryptedText);
Console.WriteLine($"Decrypted Text: {decryptedText}");
