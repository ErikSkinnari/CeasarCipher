using System;

namespace _002_encryption
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                MainMenu();
            }
        }

        private static void MainMenu()
        {
            PrintHeader();
            PrintMenu();

            switch(UserSelection())
            {
                case 1:
                    PrintHeader();
                    System.Console.WriteLine($"Your encrypted string is: {Encrypt()}");
                    System.Console.WriteLine("Press ENTER to go to main menu.");
                    Console.ReadLine();
                    break;
                case 2:
                    PrintHeader();
                    string result = Decrypt();
                    System.Console.WriteLine($"Your decrypted string is: {result}");
                    System.Console.WriteLine("Press ENTER to go to main menu.");
                    Console.ReadLine();
                    break;
                case 3:
                    Environment.Exit(-1);
                    break;
                default:
                    MainMenu();
                    return;
            }
        }

        private static int UserSelection()
        {
            string input = Console.ReadLine();
            int output = 0;
            bool success = false;

            while (!success)
            {
                try
                {
                    output = Convert.ToInt32(input);
                    success = true;
                }
                catch (System.Exception)
                {
                    PrintHeader();
                    PrintMenu();
                    Console.ForegroundColor = ConsoleColor.Red;
                    System.Console.WriteLine("Enter valid selection (1/2/3)!!");
                    input = Console.ReadLine();
                }
            }

            return output;
        }

        private static void PrintHeader()
        {
            System.Console.Clear();
            System.Console.WriteLine("***************************");
            System.Console.WriteLine("*    Welcome to EnCrpt    *");
            System.Console.WriteLine("***************************");
        }

        private static void PrintMenu()
        {
            System.Console.WriteLine("[1] Encrypt String         ");
            System.Console.WriteLine("[2] Decrypt String         ");
            System.Console.WriteLine("[3] Exit application       ");
        }

        private static int GetEncryptionKey()
        {
            int output = 0;
            string input;
            System.Console.Write("Enter encryption key: ");
            input = Console.ReadLine();

            foreach (char c in input)
            {
                output += Convert.ToInt32(c);
            }

            return output;
        }
        private static string Encrypt()
        {
            string output = "";

            System.Console.Write("Enter text to encrypt: ");            
            string stringToEncrypt = Console.ReadLine();
            
            int key = GetEncryptionKey();

            for (int i = 0; i < stringToEncrypt.Length; i++)
            {

                //Convert char to numeric value
                int c = stringToEncrypt[i];
                //Decrypt the char
                c = c + key;
                //Add decrypted char to output
                output += c + "|";
                //Change key
                key++;
            }

            return output;
        }

        private static string Decrypt()
        {
            string output = "";

            System.Console.Write("Enter text to decrypt: ");            
            string encryptedString = Console.ReadLine();
            
            // If string ends with whitespace and/or |, remove it. 
            encryptedString.Trim();
            if(encryptedString.LastIndexOf('|') == encryptedString.Length - 1)
            {
                encryptedString = encryptedString.Remove(encryptedString.LastIndexOf('|'));
            }
            
            int key = GetEncryptionKey();

            // Take input string and split it at |
            string[] charInts = encryptedString.Split('|');
            foreach (string number in charInts)
            {
                int n = 0;

                try
                {
                    n = Convert.ToInt32(number);
                    n = n - key;
                }
                catch
                {
                    PrintHeader();
                    System.Console.WriteLine("Something went wrong. Press enter to go to main menu.");
                    Console.ReadLine();
                    MainMenu();
                }

                output = output + (char)n;
                key++;
            }

            PrintHeader();
            System.Console.WriteLine($"Din dekrypterade textsträng är: {output}");

            return output;
        }
    }
}
