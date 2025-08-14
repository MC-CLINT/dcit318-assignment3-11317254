using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SchoolGradingSystem
{
    public class Student
    {
        public int Id { get;}
        public string FullName { get;}
        public int Score { get;}


        public Student(int id, string fullName, int score)
        {
            Id = id;
            FullName = fullName;
            Score = score;
        }

        public string GetGrade()
        {
            if (Score >= 80 && Score <= 100)
            {
                return "A";
            }
            else if (Score >= 70)
            {
                return "B";
            }
            else if (Score >= 60)
            {
                return "C";
            }
            else if (Score >= 50)
            {
                return "D";
            }
            else
                return "F";

        }

            public override string ToString() 
        {
            return $"ID: {Id}, FullName: {FullName}, Score: {Score}, Grade: {GetGrade()}";
        }
        }
    }

