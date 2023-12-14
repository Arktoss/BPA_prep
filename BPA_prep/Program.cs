using System;
using System.IO;

namespace ReadingAndWritingToCSV
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string sourceFilePath = "C:\\Users\\User\\source\\repos\\ReadingAndWritingToCSV\\ReadingAndWritingToCSV\\Sample_Data_Age.csv";
            string destinationFilePath = "C:\\Users\\User\\source\\repos\\ReadingAndWritingToCSV\\ReadingAndWritingToCSV\\Numbers.csv";

            ProcessCsvFile(sourceFilePath, destinationFilePath);
        }

        private static void ProcessCsvFile(string sourceFilePath, string destinationFilePath)
        {
            try
            {
                string[] lines = File.ReadAllLines(sourceFilePath);

                foreach (string line in lines)
                {
                    string[] values = line.Split(',');

                    foreach (string value in values)
                    {
                        if (double.TryParse(value, out double numericValue) && numericValue > 65)
                        {
                            File.AppendAllText(destinationFilePath, line + Environment.NewLine);
                            break; // No need to continue processing this line once a match is found
                        }
                    }
                }

                Console.WriteLine("Processing completed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}