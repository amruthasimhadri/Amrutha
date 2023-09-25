using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parent
{
    public delegate string del1();
    public class Class1
    {
        public del1 delvar { get; set; }
        public event del1 myevent;

        public string caller()
        {
            string r1= delvar();
            string r2 = myevent();
            return r1+" "+r2;
            //return delvar();
        }

        public string getname()
        {
            return "parent";
        }
    }
}
