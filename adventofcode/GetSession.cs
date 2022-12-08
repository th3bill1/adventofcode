using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace adventofcode
{
    internal class GetSession
    {
        public static string Session(string user)
        {
            string session = "";
            if (user=="th3bill")  session = "53616c7465645f5f1abea0dcf3a3ae035b95d0e058366a8b60a4a28261ea4218a4337d38a3979bf0535dfa1f14a332a6f05d12ae8220352eb40a0b3a4687e3ce";
            return session;
        }
    }
}
