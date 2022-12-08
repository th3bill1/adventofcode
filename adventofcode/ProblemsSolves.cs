using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode
{
    public class ProblemsSolves
    {
        public static int ChosenProblemNumber;
        public static int ChosenProblemPart;
        public static string problem = "";
        public static string ChosenProblem(int chosenProblemNumber, int part)
        {
            
            var chosenProblemName = "Problem" + Convert.ToString(chosenProblemNumber) +"_"+part;

            var type = typeof(ProblemsSolves);
            var info = type.GetMethod(chosenProblemName);
            if (info != null)
            {
                ChosenProblemNumber = chosenProblemNumber;
                ChosenProblemPart = part;
                problem = GetInput.ProblemText(ChosenProblemNumber, GetSession.Session("th3bill"));
                string answer = "";
                answer = Convert.ToString(info.Invoke(null, null));
                return answer;
            }
            return null;
        }
        public static string Problem1_1()
        {

            string[] elves = problem.Split("\n\n");
            string[] calories;
            int temp = 0, max = 0, number = 0;
            foreach (string elve in elves)
            {
                calories = elve.Split("\n");
                foreach(string calorie in calories)
                {
                    number = 0;
                    int.TryParse(calorie, out number);
                    temp += number;

                }
                if(temp > max) max = temp;
                temp = 0;
            }
            return Convert.ToString(max);
        }
        public static string Problem1_2()
        {

            string[] elves = problem.Split("\n\n");
            string[] calories;
            int temp = 0, number = 0;
            int[] max = { 0, 0, 0 };
            int total = 0;
            foreach (string elve in elves)
            {
                calories = elve.Split("\n");
                foreach (string calorie in calories)
                {
                    number = 0;
                    int.TryParse(calorie, out number);
                    temp += number;

                }
                for(int i = 0; i<3; i++)
                {
                    if (temp > max[i])
                    {
                        for(int j = 2; j > i; j--)
                        {
                            max[j] = max[j - 1];
                        }
                        max[i] = temp;
                        break;
                    }
                }
                temp = 0;
            }
            for(int i = 0; i<3; i++)
            {
                total += max[i];
            }
            return Convert.ToString(total);
        }
    }
}
