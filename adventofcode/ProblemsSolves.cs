namespace adventofcode
{
    public class ProblemsSolves
    {
        public static string Problem1_1(string input)
        {

            string[] elves = input.Split("\n\n");
            string[] calories;
            int temp = 0, max = 0;
            foreach (string elve in elves)
            {
                calories = elve.Split("\n");
                foreach(string calorie in calories)
                {
                    _ = int.TryParse(calorie, out int number);
                    temp += number;

                }
                if(temp > max) max = temp;
                temp = 0;
            }
            return Convert.ToString(max);
        }
        public static string Problem1_2(string input)
        {

            string[] elves = input.Split("\n\n");
            string[] calories;
            int temp = 0;
            int[] max = { 0, 0, 0 };
            int total = 0;
            foreach (string elve in elves)
            {
                calories = elve.Split("\n");
                foreach (string calorie in calories)
                {
                    _ = int.TryParse(calorie, out int number);
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
        public static string Problem2_1(string input)
        {
            int total_score = 0;
            string[] rounds = input.Split('\n');
            foreach (string round in rounds)
            {
                if (round.Length > 2)
                {
                    total_score += Score(round) + ShapeScore(round[2]);
                }
            }
            static int Score(string s)
            {
                if (s.Length < 3) return 0;
                if (s[0]+23 == s[2]) return 3;
                else if (s[0] == 'A')
                {
                    if (s[2] == 'Y') return 6;
                    else return 0;
                }
                else if (s[0] == 'B')
                {
                    if (s[2] == 'Z') return 6;
                    else return 0;
                }
                else if (s[2] == 'X') return 6;
                return 0;
            }
            static int ShapeScore(char c)
            {
                if (c == 'X') return 1;
                if (c == 'Y') return 2;
                return 3;
            }
            return Convert.ToString(total_score);
        }
        public static string Problem2_2(string input)
        {
            int total_score = 0;
            string[] rounds = input.Split('\n');
            foreach(string round in rounds)
            { 
                if (round.Length > 2)
                {
                    total_score += PointsForRound(round[0], round[2]);
                }
            }
            static int PointsForRound(char oponent, char result)
            {
                if (result == 'X') return WhatLoses(oponent);
                if (result == 'Y') return 3 + oponent - 64;
                return 6 + WhatWins(oponent);
                static int WhatWins(char oponent)
                {
                    if (oponent == 'A') return 2;
                    if (oponent == 'B') return 3;
                    return 1;
                }
                static int WhatLoses(char oponent)
                {
                    if (oponent == 'A') return 3;
                    if (oponent == 'B') return 1;
                    return 2;
                }
            }
            return Convert.ToString(total_score);
        }
    }
}
