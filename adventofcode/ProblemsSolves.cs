using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace adventofcode
{
    public class ProblemsSolves
    {
        public static string Problem1_1(string input)
        {
            string[] calories = input.Split("\n");
            int max = 0, temp = 0;
            foreach (string calorie in calories)
            {
                if (calorie == "")
                {
                    if (temp > max) max = temp;
                    temp = 0;
                }
                else temp += Convert.ToInt32(calorie);
            }
            return max.ToString();
        }
        public static string Problem1_2(string input)
        {
            string[] calories = input.Split("\n");
            int temp = 0;
            int[] max = { 0, 0, 0 };
            int total = 0;
            foreach (string calorie in calories)
            {
                if (calorie == "")
                {
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
                else temp += Convert.ToInt32(calorie);
            }
            for (int i = 0; i < 3; i++)
            {
                total += max[i];
            }
            return total.ToString();
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
        public static string Problem3_1(string input)
        {
            string[] rucksacks = input.Split('\n');
            int total = 0;
            foreach (string rucksack in rucksacks)
            {
                string compartment1 = rucksack[..(rucksack.Length / 2)];
                string compartment2 = rucksack[(rucksack.Length / 2)..];
                foreach (char c in compartment1)
                {
                    if (compartment2.Contains(c))
                    {
                        if (c > 96) total += c - 96;
                        else total += c - 38;
                        break;
                    }
                }
            }
            return total.ToString();
        }
        public static string Problem3_2(string input)
        {
            int total = 0;
            string[] rucksacks = input.Split('\n');
            for (int i = 0; i<rucksacks.Length; i++)
            {
                foreach (char c in rucksacks[i])
                {
                    if (rucksacks[i+1].Contains(c) && rucksacks[i+2].Contains(c))
                    {
                        if (c > 96) total += c - 96;
                        else total += c - 38;
                        i += 2;
                        break;
                    }
                }
            }
            return total.ToString();
        }
    public static string Problem4_1(string input)
        {
            int total = 0;
            string[] pairs = input.Split('\n');
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
        public static string Problem4_2(string input)
        {
            int total = 0;
            string[] pairs = input.Split('\n');
            foreach (string pair in pairs)
            {
                if (pair.Length > 3)
                {
                    int n = 2;
                    int[] Elve1 = {Convert.ToInt32(pair.Substring(0,pair.IndexOf('-'))) ,
                    Convert.ToInt32((pair.Substring(pair.IndexOf('-') + 1, pair.IndexOf(',') - pair.IndexOf('-') - 1))) };
                    int[] Elve2 = { Convert.ToInt32(pair.Substring(pair.IndexOf(',')+1, pair.IndexOf('-', pair.IndexOf(','))- pair.IndexOf(',')-1)),
                    Convert.ToInt32(pair.Substring(pair.IndexOf('-', pair.IndexOf(','))+1)) };
                    if (((Elve1[0] <= Elve2[0]) && (Elve1[1] >= Elve2[0])) || ((Elve2[0] <= Elve1[0]) && (Elve2[1] >= Elve1[0]))) total += 1;
                }
            }
            return total.ToString();
        }

        public static string Problem5_1(string input)
        {
            string[] text = input.Split('\n');
            string message = "";
            int crates_number = 0, rows = 0, boxes_number = 0;
            foreach (string small_text in text)
            {
                if (!small_text.Contains('['))
                {
                    foreach(char c in small_text)
                    {
                        if (Char.IsLetterOrDigit(c)) crates_number++;
                    }
                    break;
                }
                rows++;
            }
            char[,] crates = new char[crates_number,rows*crates_number+1];
            for (int i = 0; i < crates_number; i++)
            {
                for (int j = 0; j<rows*crates_number+1; j++)
                {
                    crates[i, j] = ' ';
                }
            }
            int k = 0;
            foreach (string text1 in text)
            {
                for(int i = 0; i<text1.Length; i++)
                {
                    if (text1[i] == '[')
                    {
                        crates[(i + 1) / 4, k] = text1[i + 1];
                        boxes_number++;
                    }
                }
                k++;
            }
            for (int i = 0; i<crates_number; i++)
            {
                for (int j = 0; j<rows/2; j++)
                {
                    char temp = crates[i,j];
                    crates[i, j] = crates[i, rows - j - 1];
                    crates[i, rows - j - 1] = temp;
                }
            }
            foreach (string command in text)
            {
                if(command.StartsWith('m'))
                {
                    int howMany = Convert.ToInt32(command.Substring(command.IndexOf(' '), command.IndexOf("from") - command.IndexOf(' ')));
                    int from = Convert.ToInt32(command.Substring(command.IndexOf("from")+5, command.IndexOf("to") - command.IndexOf("from")-6));
                    int to = Convert.ToInt32(command.Substring(command.IndexOf("to")+2));
                    int a = 0;
                    for(int i = boxes_number; i>=0; i--)
                    {
                        if (a == howMany) break;
                        if (crates[from-1,i]!=' ')
                        {
                            for (int j = boxes_number; j>=0; j--)
                            {
                                if (crates[to-1,j]!=' ')
                                {
                                    crates[to-1, j + 1] = crates[from-1, i];
                                    crates[from-1, i] = ' ';
                                    a++;
                                    break;
                                }
                                else if (j==0)
                                {
                                    crates[to - 1, j] = crates[from - 1, i];
                                    crates[from - 1, i] = ' ';
                                    a++;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            for(int i = 0; i<crates_number; i++)
            {
                for(int j = boxes_number; j>=0; j--)
                {
                    if (crates[i,j]!=' ')
                    {
                        message += crates[i, j];
                        break;
                    }
                }
            }
            return message;
        }

        public static string Problem5_2(string input)
        {
            string[] text = input.Split('\n');
            string message = "";
            int crates_number = 0, rows = 0, boxes_number = 0;
            foreach (string small_text in text)
            {
                if (!small_text.Contains('['))
                {
                    foreach (char c in small_text)
                    {
                        if (Char.IsLetterOrDigit(c)) crates_number++;
                    }
                    break;
                }
                rows++;
            }
            char[,] crates = new char[crates_number, rows * crates_number + 1];
            for (int i = 0; i < crates_number; i++)
            {
                for (int j = 0; j < rows * crates_number + 1; j++)
                {
                    crates[i, j] = ' ';
                }
            }
            int x = 0;
            foreach (string text1 in text)
            {
                for (int i = 0; i < text1.Length; i++)
                {
                    if (text1[i] == '[')
                    {
                        crates[(i + 1) / 4, x] = text1[i + 1];
                        boxes_number++;
                    }
                }
                x++;
            }
            for (int i = 0; i < crates_number; i++)
            {
                for (int j = 0; j < rows / 2; j++)
                {
                    char temp = crates[i, j];
                    crates[i, j] = crates[i, rows - j - 1];
                    crates[i, rows - j - 1] = temp;
                }
            }
            foreach (string command in text)
            {
                if (command.StartsWith('m'))
                {
                    int howMany = Convert.ToInt32(command.Substring(command.IndexOf(' '), command.IndexOf("from") - command.IndexOf(' ')));
                    int from = Convert.ToInt32(command.Substring(command.IndexOf("from") + 5, command.IndexOf("to") - command.IndexOf("from") - 6));
                    int to = Convert.ToInt32(command.Substring(command.IndexOf("to") + 2));
                    for (int i = boxes_number; i >= 0; i--)
                    {
                        if (crates[from - 1, i] != ' ')
                        {
                            for (int j = howMany-1; j>=0; j--)
                            {
                                for (int k = boxes_number; k >= 0; k--)
                                {
                                    if (crates[to - 1, k] != ' ')
                                    {
                                        crates[to - 1, k + 1] = crates[from - 1, i-j];
                                        crates[from - 1, i-j] = ' ';
                                        break;
                                    }
                                    else if (k == 0)
                                    {
                                        crates[to - 1, k] = crates[from - 1, i-j];
                                        crates[from - 1, i-j] = ' ';
                                        break;
                                    }
                                }
                            }
                            break;
                        }
                    }
                }
            }
            for (int i = 0; i < crates_number; i++)
            {
                for (int j = boxes_number; j >= 0; j--)
                {
                    if (crates[i, j] != ' ')
                    {
                        message += crates[i, j];
                        break;
                    }
                }
            }
            return message;
        }
        public static string Problem6_1(string input)
        {
            int value = 0;
            for (int i = 0; i<input.Length-3; i++)
            {
                if ((input[i+1] == input[i + 2])) i += 1;
                else
                {
                    if ((input[i + 1] == input[i + 3])) i += 1;
                    else
                    {
                        if ((input[i + 2] == input[i + 3])) i += 2;
                        else
                        {
                            if ((input[i] != input[i + 1]) && (input[i] != input[i + 2]) && (input[i] != input[i + 3]))
                            {
                                value = i;
                                break;
                            }
                        }
                    }
                }
            }

            return (value+4).ToString();
        }
        public static string Problem6_2(string input)
        {
            int value = 0, cons_char_num = 14;
            for (int i = 0; i<input.Length-13; i++)
            {
                bool temp = true, isActive = true;
                int j = 0;
                while (isActive)
                {
                    if (j == 14) break;
                    for (int k = 1; j+k<cons_char_num; k++)
                    {
                        if (input[i + j] == input[i+j+k])
                        {
                            temp = false;
                            i += j;
                            isActive = false;
                        }
                    }
                    j++;
                }
                if(temp==true)
                {
                    value = i;
                    break;
                }
            }
            return (value+cons_char_num).ToString();
        }
        struct File
        {
            public string name;
            public int size;
        }
        struct Directory
        {
            public string name;
            public File[] files;
            public Directory[] dirs; //dirs[0] = outter dir 
        }
        public static string Problem7_1(string input)
        {
            string[] commands = input.Split('\n');
            Directory outter = new()
            {
                name = "/",
                dirs = new Directory[40],
                files = new File[40]
            };
            Directory current_dir = outter;
            foreach (string command in commands)
            {
                if (command.Length > 2)
                {
                    if (command.StartsWith('$'))
                    {
                        if (command.Substring(2,2)=="cd" && (command.Substring(command.IndexOf("cd") + 3) == ".."))
                        {
                            current_dir = current_dir.dirs[0];
                        }
                        else if (command.Substring(2, 2) == "cd" && (command.Substring(command.IndexOf("cd") + 3) == "/"))
                        {
                            current_dir = outter;
                        }
                        else if (command.Substring(2, 2) == "cd")
                        {
                            string name = command.Substring(command.IndexOf("cd") + 3);
                            foreach (Directory dir in current_dir.dirs)
                            {
                                if (dir.name == name)
                                {
                                    current_dir = dir;
                                    break;
                                }
                            }
                        }
                    }
                    else if (command.StartsWith("dir"))
                    {
                        string name = command.Substring(4);
                        Directory directory = new()
                        {
                            name = name,
                            dirs = new Directory[40],
                            files = new File[40]
                        };
                        directory.dirs[0] = current_dir;
                        for (int i = 0; i < 40; i++)
                        {
                            if (current_dir.dirs[i].name == null)
                            {
                                current_dir.dirs[i] = directory;
                                break;
                            }
                        }
                    }
                    else
                    {
                        File file = new()
                        {
                            name = command.Substring(command.IndexOf(' ')),
                            size = Convert.ToInt32(command.Substring(0, command.IndexOf(' ')))
                        };
                        for (int i = 0; i < 40; i++)
                        {
                            if (current_dir.files[i].name == null)
                            {
                                current_dir.files[i] = file;
                                break;
                            }
                        }
                    }
                }
            }
            static int DirectorySize(Directory x)
            {
                int size = 0;
                if(x.name=="/")
                {
                    for (int i = 0; i < 40; i++)
                    {
                        if (x.dirs[i].name == null) break;
                        size += DirectorySize(x.dirs[i]);
                    }
                }
                else for (int i = 1; i < 40; i++)
                {
                    if (x.dirs[i].name == null) break;
                    size += DirectorySize(x.dirs[i]);
                }
                for (int i = 0; i<40; i++)
                {
                    if (x.files[i].name == null) break;
                    size += x.files[i].size;
                }
                return size;
            }

            static int FindSumOfSmall(Directory outter)
            {
                int sum = 0;
                int temp = DirectorySize(outter);
                if (temp < 100000) sum += temp;
                if (outter.name == "/")
                {
                    for (int i = 0; i < 40; i++)
                    {
                        if (outter.dirs[i].name == null) break;
                        sum += FindSumOfSmall(outter.dirs[i]);
                    }
                }
                else
                {
                    for (int i = 1; i < 40; i++)
                    {
                        if (outter.dirs[i].name == null) break;
                        sum += FindSumOfSmall(outter.dirs[i]);
                    }
                }
                return sum;
            }


            return FindSumOfSmall(outter).ToString();
        }

    }
}
