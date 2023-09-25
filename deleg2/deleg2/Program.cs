using parent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deleg2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Class1 c1 = new Class1();
            c1.delvar = fun;
            c1.myevent += C1_myevent;
            string result = c1.caller();
            Console.WriteLine(result);
            Console.ReadLine();

        }

        private static string C1_myevent()
        {
            return "eventt";
        }

        private static string fun()
        {
            return "child";
        }
    }
}
