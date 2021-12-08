using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HellowWorld
{
    class Program
    {
        private static List<string> nacionalities;
        private static void InitList()
        {
            nacionalities = new List<string>()
             {

             "Italiano",      
             "Australian",
             "Mongolian",
             "Russian",
             "Austrian",
             "Brazilian"
             };
        }
        static void Main(string[] args)
        {
            InitList();
            nacionalities.Sort();
            foreach (string nacionality in nacionalities)
            {
                Console.WriteLine(nacionality);
            }
        }
    }
}
