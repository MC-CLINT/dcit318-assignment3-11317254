using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolGradingSystem
{
    public class StudentResultProcessor
    {
        public List<Student> ReadStudentsFromFile(string inputFilePath)
        {
            var students = new List<Student>();

            using (var reader = new StreamReader(inputFilePath))
            {
                String? line;
                int lineNumber = 0;

                while ((line = reader.ReadLine()) != null)
                {
                    lineNumber++;

                    try
                    {
                        var parts = line.Split(",");

                        if (parts.Length != 3)
                            throw new MissingFieldException($"Line {lineNumber}: Expected 3 fields, got {parts.Length}");

                        if (!int.TryParse(parts[0].Trim(), out int id))
                            throw new FormatException($"Line {lineNumber}: Invalid ID format");

                        string fullName = parts[1].Trim();

                        if (!int.TryParse(parts[2].Trim(), out int score))
                            throw new InvalidScoreFormatException($"Line {lineNumber}: Score must be an integer");

                        students.Add(new Student(id, fullName, score));

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error processing line {lineNumber}: {ex.Message}");
                    }
                }
                Console.WriteLine($"\n Valid students loaded: {students.Count}");
                return students;
            }



        }



        public void WriteReportToFile(List<Student> students, string outputFilePath)
        {
            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                writer.WriteLine("Student Report");

                foreach (var student in students)
                {
                    writer.WriteLine($"ID: {student.Id}, Name: {student.FullName}, Score: {student.Score}");
                }

               
            }

            Console.WriteLine($"Report successfully written to: {Path.GetFullPath(outputFilePath)}");
        }
    }

   

}


