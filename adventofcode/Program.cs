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
            Console.WriteLine("Please input the problem number:");
            int problem_number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please input the part of problem: ");
            int part = Convert.ToInt32(Console.ReadLine());
            
            Console.WriteLine("Answer: "+GetAnswer.CallMethod(problem_number, part));
        }
    }   
}