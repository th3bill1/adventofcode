using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode
{
    internal class AllTasks
    {
        [Obsolete]
        public static void PrintAll()
        {
            for(int problem_num = 1; problem_num <6; problem_num++)
            {
                for (int part_num = 1; part_num <3; part_num++)
                {
                    Console.WriteLine("Task: " + problem_num + " Part: " + part_num);
                    Console.WriteLine("Answer: " + GetAnswer.CallMethod(problem_num, part_num));
                    Console.WriteLine();
                }
            }
        }
    }
}
