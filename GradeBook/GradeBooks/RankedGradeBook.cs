using GradeBook.Enums;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {

            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked grading requires at least 5 students.");
            }

            int decile = (int)(Students.Count * 0.2);

            var orderedGradeStudentList = (from stu in Students orderby stu.AverageGrade descending select stu.AverageGrade).ToList();  //koncepcja porządkowania malejąco

            if (averageGrade >= orderedGradeStudentList[decile-1])
            {
                return 'A';
            }

            if (averageGrade >= orderedGradeStudentList[2*decile - 1])
            {
                return 'B';
            }

            if (averageGrade >= orderedGradeStudentList[3 * decile - 1])
            {
                return 'C';
            }
            
            if (averageGrade >= orderedGradeStudentList[4 * decile - 1])
            {
                return 'D';
            }
            
            return 'F'; //uzupełnić ciało metody
        }

        public override void CalculateStatistics()
        {
            if (Students.Count <5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
                return;
            }
            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
                return;
            }
            base.CalculateStudentStatistics(name);
        }
    }
}
