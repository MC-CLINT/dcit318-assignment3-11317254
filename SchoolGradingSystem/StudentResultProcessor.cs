using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolGradingSystem
{
    public class StudentResultProcessor
    {
        public List<student> ReadStudentsFromFile(string inputFilePath)
        {
            var students = new List<Student>();

            using(var reader = new StreamReader(inputFilePath))
            {
                String? line;
                int lineNumber = 0;

                while((line = reader.ReadLine()) != null)
                {
                    lineNumber ++;

                    try
                    {
                        var parts = line.Split(",");

                        if (parts.Length != 3)
                            throw new MissingFieldException($"Line {lineNumber}: Expected 3 fields, got {parts.Length}");

                        if (!int.TryParse(parts[0].Trim(), out int Id))
                            throw new FormatException($"Line {lineNumber}: Invalid ID format");

                        string fullName = parts[1].Trim();

                        if (!int.TryParse(parts[2].Trim(), out int score))
                            throw new InvalidScoreFormatException($"Line {lineNumber}: Score must be an integer");
                    
                    }
                }
            }
        }
    }
}
