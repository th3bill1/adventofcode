﻿using adventofcode;
namespace adventofcode
{
    internal static class AdventOfCode
    {
        [Obsolete]
        private static void Main()
        {
            Console.WriteLine("Please input the problem number:");
            int problem_number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please input the part of problem: ");
            int part = Convert.ToInt32(Console.ReadLine());
            string answer = "";
            answer =  GetInput.ProblemText(problem_number, GetSession.Session());
            Console.WriteLine("Answer: "+GetAnswer.CallMethod(problem_number, part));
        }
    }   
}