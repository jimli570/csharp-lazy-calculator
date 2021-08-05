using System;
using System.IO;
using System.Collections.Generic;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string filepath = GetFilePath( args );

            try {
                // Read input from file
                fileReader.IReader<string> fileReader = new fileReader.FileReader();
                List<string> lines = fileReader.Read( filepath );

                ICalculator calculator = new Calculator();

                // Send each line of potential commands to calculator
                foreach (string commandline in lines) {
                    calculator.Command( commandline );
                }
                // Console.ReadLine();
            }
            catch (IOException ex) {
                Console.WriteLine(ex.ToString());
            }
            catch (OutOfMemoryException ex) {
                Console.WriteLine(ex.ToString());
            }
            catch (ArgumentOutOfRangeException ex) {
                Console.WriteLine(ex.ToString());
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            }
        }

        private static string GetFilePath(string[] args)
        {
            string filepath;

            // We only take one file as input for now
            if (args.Length == 1)  {
                filepath = args[0];
            } else {
                filepath = "math_data_3.txt"; // Default filePath, if none provided
            }

            return filepath;
        }
    }
}