namespace SchoolGradingSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputFilePath = "F:\\DCIT 318-ASSIGNMENTS\\dcit318-assignment3-11317254\\SchoolGradingSystem\\student.txt";

            string outputFilePath = "F:\\DCIT 318-ASSIGNMENTS\\dcit318-assignment3-11317254\\SchoolGradingSystem\\report.txt";

            var processor = new StudentResultProcessor();

            try
            {
                List<Student> students = processor.ReadStudentsFromFile(inputFilePath);

                processor.WriteReportToFile(students, outputFilePath);
            }
            catch (FileNotFoundException ex)
            { 
                Console.WriteLine($"File Not Found: { ex.Message}"); 
            }
            catch (InvalidScoreFormatException ex)
            {
                  Console.WriteLine($"Invalid Score Format: {ex.Message}");
            }
            catch (MissingFieldException ex)
            {
                Console.WriteLine($"Missing Field in Record: {ex.Message}");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Unexpected Error: {ex.Message}");
            }

        }
    }
}
