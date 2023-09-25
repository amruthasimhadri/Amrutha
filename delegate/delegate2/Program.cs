// See https://aka.ms/new-console-template for more information
namespace ns
{
    public class c1
    {
        public delegate string del1();
        public del1 delvar { get; set; }
        public string fun1()
        {
            return "parent";
        }
    }
}
