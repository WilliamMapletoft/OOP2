using System;

namespace OOP_DifferenceAssessment
{
    class Program
    {
        //Main obtains a file location and passes it to the Differences function, and handles output.
        static void Main(string[] args)
        {
            string File1 = GetFileLocation();
            string File2 = GetFileLocation();
            //If Differences returns true, the text turns red and outputs "Difference(s) found.", otherwise it turns green and outputs "No differences were found.".
            if (Differences(File1, File2) == true)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Difference(s) found.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("No differences were found.");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        //GetFileLocation prompts the user to input a file path and file name, and returns it to the main function. This function is used for both file 1 and file 2.
        static string GetFileLocation()
        {
            string file;
            Console.WriteLine("Please enter the file path and file name in full (C:\\<path>\\<filename>); (do not include .txt)");
            file = Console.ReadLine();
            return file;
        }
        //The Differences function checks every line of the two files input against one another, and if there are any differences, outputs both lines, and returns a boolean true value.
        static bool Differences(string File1, string File2)
        {
            string Line;
            string Line2;
            bool diffFound = false;
            bool complete = false;
            System.IO.StreamReader file = new System.IO.StreamReader($@"test.txt");
            System.IO.StreamReader file2 = new System.IO.StreamReader($@"test2.txt");
            //Catching any incorrect file locations to stop the program from exiting ungracefully.
            try
            {
                file = new System.IO.StreamReader($@"{File1}.txt");
                file2 = new System.IO.StreamReader($@"{File2}.txt");
            }
            catch
            {
                Console.WriteLine("Invalid file path entered, running with test files.");
            }
            
            //While there are lines left in both files, check both files against one another.
            while (complete == false)
            {
                Line = file.ReadLine();
                Line2 = file2.ReadLine();
                if (Line != null && Line2 != null)
                {
                    if (Line2 != Line)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($">{Line}");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($">{Line2}");
                        Console.ForegroundColor = ConsoleColor.White;
                        diffFound = true;
                    }
                }
                //Else, if both files are empty, the test is complete and no differences were found.
                else if (Line == null && Line2 == null)
                {
                    complete = true;
                }
                //Else, if one of the files is empty, print out the remainder of the other file as a difference.
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($">{Line}");

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($">{Line2}");
                    while ((Line = file.ReadLine()) != null)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($">{Line}");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($">");
                    }
                    while ((Line2 = file2.ReadLine()) != null)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($">");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($">{Line2}");
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                    diffFound = true;
                    complete = true;
                }
            }
            //Closing files.
            file.Close();
            file2.Close();
            return diffFound;
        }
    }
}
