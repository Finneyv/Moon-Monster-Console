using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace MoonMonsterConsole
{
   //if you are reading this you are a winner
    class Program
    {
        /* static void test() {
             Monster jack = new Monster(12);
             jack.print();
             Console.ReadLine();
         }*/
        /// <summary>
        /// test
        /// this is working
        /// </summary>
        /// <param name="args"></param>
        static void startUpConsole()
        {
            Console.Write("Welcome to Moon Monster, the Conquest of the Future" + "\n");
           // Console.Write("Today will be a two player gamee" + "\n");

        }

        static void Main(string[] args)
        {


            //test();
            startUpConsole();
            List<Move> moveList = new List<Move>();
            test firsttest = new test();
            firsttest.runtest();
        }
    }
}
