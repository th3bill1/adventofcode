using adventofcode;
namespace adventofcode
{
    internal static class AdventOfCode
    {
        [Obsolete]
        private static void Main()
        {
            for (int k = 0; k < 10; k++)
            {
                for (int i = 0; i < 100; i++)
                {
                    Random rnd = new Random();
                    int a = rnd.Next();
                    if (a % 7 == 0) Console.Write("*");
                    else Console.Write(" ");
                }
                Console.Write('\n');
            }
            while (true)
            {
                Console.WriteLine("Please input the problem number: (put 0 to leave)");
                int problem_number = Convert.ToInt32(Console.ReadLine());
                if (problem_number == 0) break;
                Console.WriteLine("Please input the part of problem: ");
                int part = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Answer: " + GetAnswer.CallMethod(problem_number, part));
            }
        }
    }   
}