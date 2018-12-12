using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnDotNet
{
    public static class Guid
    {
        public static void Go()
        {

            System.Guid _guid = System.Guid.TryParse("7AF5D5D8-AEA8-482D-9BCC-6BFCB9A33153", out _guid) ? _guid : System.Guid.Empty;
            System.Guid _guid2 = new System.Guid();
            Console.WriteLine(_guid);
            Console.WriteLine(_guid2);
        }
    }
}
