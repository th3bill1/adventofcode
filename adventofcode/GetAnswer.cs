using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode
{
    internal class GetAnswer
    {
        [Obsolete]
        public static string? CallMethod(int chosenProblemNumber, int part)
        {

            var chosenProblemName = "Problem" + Convert.ToString(chosenProblemNumber) + "_" + part;

            var type = typeof(ProblemsSolves);
            var info = type.GetMethod(chosenProblemName);
            if (info != null)
            {
                string input = GetInput.ProblemText(chosenProblemNumber, GetSession.Session());
                string? answer = null;
                answer = Convert.ToString(info.Invoke(null, new object[] {input}));
                return answer;
            }
            return null;
        }
    }
}
