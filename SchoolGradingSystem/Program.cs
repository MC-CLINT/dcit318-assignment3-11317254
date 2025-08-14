namespace SchoolGradingSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputFilePath = "students.txt";

            string outputFilePath = "report.txt";

            var processor = new StudentResultProcessor();

            try
            {
                List<Student> students = processor.ReadStudentsFromFile(inputFilePath);

                processor.WriteReportToFile(students, outputFilePath);
            }
            catch (FileNotFoundException ex)
            { 
                Console.WriteLine("File Not Found"); 
            }
            catch (FormatException ex)
            {

            }

        }
    }
}
