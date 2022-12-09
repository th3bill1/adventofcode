using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            return max.ToString();
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
                for (int i = 0; i < 3; i++)
                {
                    if (temp > max[i])
                    {
                        for (int j = 2; j > i; j--)
                        {
                            max[j] = max[j - 1];
                        }
                        max[i] = temp;
                        break;
                    }
                }
                temp = 0;
            }
            for (int i = 0; i < 3; i++)
            {
                total += max[i];
            }
            return total.ToString();
        }
        public static string Problem3_1()
        {
            string[] rucksacks = problem.Split('\n');
            int total = 0;
            foreach(string rucksack in rucksacks)
            {
                string compartment1 = rucksack[..(rucksack.Length / 2)];
                string compartment2 = rucksack[(rucksack.Length / 2)..];
                foreach (char c in compartment1)
                {
                    if(compartment2.Contains(c))
                    {
                        if (c > 96) total += c - 96;
                        else total += c - 38;
                        break;
                    }
                }
            }
            return total.ToString();
        }
        public static string Problem3_2()
        {
            int k = 0, total = 0;
            string problemx = problem;
            for(int i = 0; i < problemx.Length; i++)
            {
                if (problemx[i] == '\n') k++;
                if (k == 3)
                {
                    problemx = problemx.Insert(i, "\n");
                    k = 0;
                    i++;
                } 
            }
            string[] groups = problemx.Split("\n\n");
            foreach (string group in groups)
            {
                string[] Elves = group.Split('\n');
                foreach (char c in Elves[0])
                {
                    if (Elves[1].Contains(c) && Elves[2].Contains(c))
                    {
                        if (c > 96) total += c - 96;
                        else total += c - 38;
                        break;
                    }
                }
            }
            return total.ToString();
        }
        public static string Problem4_1()
        {
            int total = 0;
            string[] pairs = problem.Split('\n');
            foreach (string pair in pairs)
            {
                if (pair.Length > 3)
                {
                    int n = 2;
                    int[] Elve1 = {Convert.ToInt32(pair.Substring(0,pair.IndexOf('-'))) ,
                    Convert.ToInt32((pair.Substring(pair.IndexOf('-') + 1, pair.IndexOf(',') - pair.IndexOf('-') - 1))) };
                    int[] Elve2 = { Convert.ToInt32(pair.Substring(pair.IndexOf(',')+1, pair.IndexOf('-', pair.IndexOf(','))- pair.IndexOf(',')-1)),
                    Convert.ToInt32(pair.Substring(pair.IndexOf('-', pair.IndexOf(','))+1)) };
                    if (((Elve1[0] <= Elve2[0]) && (Elve1[1] >= Elve2[1])) || ((Elve1[0] >= Elve2[0]) && (Elve1[1] <= Elve2[1]))) total += 1;
                }
            }
            return total.ToString();
        }
        public static string Problem4_2()
        {
            int total = 0;
            string[] pairs = problem.Split('\n');
            foreach (string pair in pairs)
            {
                if (pair.Length > 3)
                {
                    int n = 2;
                    int[] Elve1 = {Convert.ToInt32(pair.Substring(0,pair.IndexOf('-'))) ,
                    Convert.ToInt32((pair.Substring(pair.IndexOf('-') + 1, pair.IndexOf(',') - pair.IndexOf('-') - 1))) };
                    int[] Elve2 = { Convert.ToInt32(pair.Substring(pair.IndexOf(',')+1, pair.IndexOf('-', pair.IndexOf(','))- pair.IndexOf(',')-1)),
                    Convert.ToInt32(pair.Substring(pair.IndexOf('-', pair.IndexOf(','))+1)) };
                    if (((Elve1[0] <= Elve2[0])&&(Elve1[1] >= Elve2[0]))|| ((Elve2[0] <= Elve1[0]) && (Elve2[1] >= Elve1[0]))) total += 1;
                }
            }
            return total.ToString();
        }
    }
}
