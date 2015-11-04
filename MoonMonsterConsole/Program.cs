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
       

        Builder Build = new Builder();
        test test = new test();
        List<Move> allMoves = new List<Move>();
        List<Monster> monsterDataBase = new List<Monster>();
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
        static void gameLoop()
        {
            Console.Write("What would you like to do today? Enter 1 to play, or 2 to develop "+"\n");
            string tempString = Console.ReadLine();
            int tempInt = Convert.ToInt32(tempString);
            if (tempInt == 1)
            {
                
            }
            if (tempInt == 2)
            {

            }
            else
            {

            }

        }

        static void Main(string[] args)
        {


            //test();
            
           
           // startUpConsole();
            List<Move> moveList = new List<Move>();
            test firsttest = new test();
            firsttest.runtest();
        }
    }
}
