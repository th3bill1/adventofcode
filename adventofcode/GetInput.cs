using System;
using System.Net;

namespace adventofcode
{
    [Obsolete("Obsolete")]
    internal class GetInput
    {
        public static string ProblemText(int problemNumber, string cookie_value)
        {
            var request = (HttpWebRequest)WebRequest.Create($"https://adventofcode.com/2022/day/{problemNumber}/input");
            request.CookieContainer = new CookieContainer();
            Cookie cookie = new Cookie("session", cookie_value);
            cookie.Domain = ".adventofcode.com";
            request.CookieContainer.Add(cookie);
            var response = (HttpWebResponse)request.GetResponse();
            string text;
            using (var sr = new StreamReader(response.GetResponseStream()))
            {
                text = sr.ReadToEnd();
            }
            return text;
        }
    }
}
