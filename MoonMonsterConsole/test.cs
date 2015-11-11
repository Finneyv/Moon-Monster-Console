using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MoonMonsterConsole
{

    public class test
    {
        
        Roster playerOne;
        Roster playerTwo;
        List<Move> moveList = new List<Move>();
        List<Monster> monsterDataBase = new List<Monster>();
        BattleGround firstFight;
        Builder Build = new Builder();
       public test()
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }

        public void buildmoves()
        {      
            List<Move> moves = new List<Move>();
            XmlSerializer serializer = new XmlSerializer(typeof(List<Move>));
            TextReader reader = new StreamReader("movelist.xml");
            moves = (List<Move>)serializer.Deserialize(reader);
            moveList = moves;
            reader.Close();
           // Console.Write("movelist ");
        }
  
        public void buildMonsters()
        {

           
            Monster dragonShep = new Monster("Dragon Sheppard",1, 815, 400, 11, 85, 50,90,80, moveList,"lava");
            Monster triceritops = new Monster("Triceritops", 2, 800, 400, 13, 70, 50, 90, 80, moveList, "plant");
            Monster prettyMermaid = new Monster("Pretty Mermaid", 3, 875, 400, 13, 90, 90, 50, 40, moveList, "water");                
            Monster snowDeamon = new Monster("Snow Deamon", 4, 850, 70, 13, 80, 65, 80, 70, moveList, "ice");
            Monster thunderCloud = new Monster("Thunder Cloud", 5, 900, 400, 14, 90, 90, 0, 30, moveList, "light");

           
            monsterDataBase.Add(dragonShep);
            monsterDataBase.Add(triceritops);
            monsterDataBase.Add(prettyMermaid);
            monsterDataBase.Add(snowDeamon);
            monsterDataBase.Add(thunderCloud);

            
                        XmlSerializer serializer = new XmlSerializer(typeof(List<Monster>));
                        TextWriter writer = new StreamWriter("monsterdatabase.xml");
                        serializer.Serialize(writer, monsterDataBase);
                        writer.Close();
            
            /*
            List<Monster> monsterDatabase = new List<Monster>();
            XmlSerializer serializer = new XmlSerializer(typeof(List<Monster>));
            TextReader reader = new StreamReader("monsterdatabase.xml");
            monsterDatabase = (List<Monster>)serializer.Deserialize(reader);
            monsterDataBase =monsterDatabase;
            reader.Close();
           */

        }    
        public void printMoveList(List<Move> moveList)
        {
            var moves=new List<Move>();
            moves = moveList;
            for (int b = 0; b < moves.Count; b++)
            {
                Console.Write(b + "\n");
                Console.Write("Name: " + moves.ElementAt(b).getName() + ", Id: " + moves.ElementAt(b).getId() + ", Type: " + moves.ElementAt(b).getType() + ", M Damage: " + moves.ElementAt(b).getMaxDamage() + ", M Defense: " + moves.ElementAt(b).getMaxDefense() + "\n");
            }
        }


        public void printMonsterList(List<Monster> monsterList)
        {
            List<Monster> monster = monsterList;

            for (int b = 0; b < monster.Count; b++)
            {
                Console.Write("Name: " + monster.ElementAt(b).getName() + ", Id: " + monster.ElementAt(b).getId() + ", Type: " + monster.ElementAt(b).getType() + "\n");
            }
        }

        public void buildRoster()
        {
            
            /*
            Console.Write("playerOne roster size is " + playerOne.count() + "\n");
            Console.Write("playerTwo roster size is " + playerTwo.count() + "\n");

            // Console.Write("player twos triceritops from his roster is level " + playerTwo.returnMonsterAt(0).getlevel() + "\n");
           // Console.Write("playerTwo roster size is " + playerTwo.count() + "\n");
            Console.ReadLine();
            */
          // XmlSerializer serializer = new XmlSerializer(typeof(List<Roster>));
           // TextWriter writer = new StreamWriter("roseterdatabase.xml");
            //serializer.Serialize(writer, monsterDataBase);
            // writer.Close();


        }

        public Move getMoveFromConsole(List<Move> moveList)
        {
            Console.Write("Seriializer closed test");

            Console.Write("     Please pick a move"+"\n");
            for (int b = 0; b < moveList.Count; b++)
            {
                Console.Write("Name: " + moveList.ElementAt(b).getName() + ", Id: " + moveList.ElementAt(b).getId()+", Type: "+ moveList.ElementAt(b).getType() + ", M Damage: "+ moveList.ElementAt(b).getMaxDamage()+", M Defense: "+ moveList.ElementAt(b).getMaxDefense() + "\n");
            }
            string tempMove=Console.ReadLine();
            int tempMoveInt = Convert.ToInt32(tempMove);
            tempMoveInt = tempMoveInt - 1;
            //Console.Write("Move chosen is: " +moveList.ElementAt(tempMoveInt).getName()+ "\n");
            printMoveList(moveList);
            Console.Write("\n");

            return moveList.ElementAt(tempMoveInt);

        }

        public void testFirstFight()
        {
            firstFight.printHealth(monsterDataBase.ElementAt(0), monsterDataBase.ElementAt(1));
            // (DS) casts bite         
            firstFight.castMove(monsterDataBase.ElementAt(0), moveList.ElementAt(0), monsterDataBase.ElementAt(1));
            firstFight.printHealth(monsterDataBase.ElementAt(0), monsterDataBase.ElementAt(1));
            // (T) casts Photo Beam            
            firstFight.castMove(monsterDataBase.ElementAt(1), moveList.ElementAt(2), monsterDataBase.ElementAt(0));
            firstFight.printHealth(monsterDataBase.ElementAt(0), monsterDataBase.ElementAt(1));
            //(DS) casts fire breath
            firstFight.castMove(monsterDataBase.ElementAt(0), moveList.ElementAt(1), monsterDataBase.ElementAt(1));
            firstFight.printHealth(monsterDataBase.ElementAt(0), monsterDataBase.ElementAt(1));
            // (T) casts Photo Beam            
            firstFight.castMove(monsterDataBase.ElementAt(1), moveList.ElementAt(2), monsterDataBase.ElementAt(0));
            firstFight.printHealth(monsterDataBase.ElementAt(0), monsterDataBase.ElementAt(1));
            // (DS) casts bite   and KOs triceritops      
            firstFight.castMove(monsterDataBase.ElementAt(0), moveList.ElementAt(0), monsterDataBase.ElementAt(1));
            firstFight.printHealth(monsterDataBase.ElementAt(0), monsterDataBase.ElementAt(1));
            Console.ReadLine();
        }
        public void runtest()
        {

            startUpConsole();

            Console.ReadLine();

        }
        static void startUpConsole()
        {

            Console.Write("Welcome to Moon Monster, the Conquest of the Future" + "\n");
            // Console.Write("Today will be a two player gamee" + "\n");
            test game= new test();
            game.buildmoves();
            game.buildMonsters();
            gameLoop(game);


        }
        public List<Monster> buildMonstersList()
        {
         
            Monster dragonShep = new Monster("Dragon Sheppard", 1, 815, 400, 11, 85, 50, 90, 80, moveList, "lava");
            Monster triceritops = new Monster("Triceritops", 2, 800, 400, 13, 70, 50, 90, 80, moveList, "plant");
            Monster prettyMermaid = new Monster("Pretty Mermaid", 3, 875, 400, 13, 90, 90, 50, 40, moveList, "water");
            Monster snowDeamon = new Monster("Snow Deamon", 4, 850, 70, 13, 80, 65, 80, 70, moveList, "ice");
            Monster thunderCloud = new Monster("Thunder Cloud", 5, 900, 400, 14, 90, 90, 0, 30, moveList, "light");

            monsterDataBase.Add(dragonShep);
            monsterDataBase.Add(triceritops);
            monsterDataBase.Add(prettyMermaid);
            monsterDataBase.Add(snowDeamon);
            monsterDataBase.Add(thunderCloud);
            return monsterDataBase;
         

        }
        static void gameLoop(test gameLoopTest)
        {

            Builder buildRoster = new Builder();
            test loopTest = gameLoopTest;
   
          //  Console.Write("database count at start: " + loopTest.monsterDataBase.Count() + "\n");
            Console.Write("What would you like to do today? Enter 1 to play, 2 to develop or 3 to exit " + "\n");
            string tempString = Console.ReadLine();
            int tempInt = Convert.ToInt32(tempString);
            if (tempInt == 1)
            {
                Console.Write("Player One please select your roster;"+"\n");
               
                Roster playerOne = buildRoster.buildRosterFromConsole(loopTest.getDataBase());
                Console.Write("Player Two please selecet your roster:"+"\n");
                Roster playerTwo= buildRoster.buildRosterFromConsole(loopTest.getDataBase());
                BattleGround firstLoop = new BattleGround(playerOne,playerTwo,loopTest.getDataBase());
                firstLoop.iterator(playerOne, playerTwo);
                gameLoop(loopTest);

            }
            if (tempInt == 2)
            {
                Console.Write("Welcome to Developer Mode: " + "\n");
                Console.Write("Please Select a number from the following list: " + "\n");
                Console.Write("1: View Monster DataBase: " + "\n");
                Console.Write("2: Create new Monster" + "\n");
                Console.Write("3: Create new Move" + "\n");
                Console.Write("4: Create new Roster"+"\n");
                Console.Write("5: View moveList " + "\n");
             
                string tempStringTwo=Console.ReadLine();
                int tempIntTwo = Convert.ToInt32(tempStringTwo);
                if (tempIntTwo == 1)
                {
                    loopTest.printMonsterList(loopTest.monsterDataBase);
                    Console.Write("Press enter to continue"+"\n");
                    Console.ReadLine();
                    gameLoop(loopTest);
                }
                if (tempIntTwo == 2)
                {
                    Monster newMonster = buildRoster.buildMonsterFromConsole(loopTest.moveList,loopTest.monsterDataBase.Count());
                    loopTest.monsterDataBase.Add(newMonster);

                    Console.Write("Press enter to continue"+ "\n");
                    Console.ReadLine();
                    gameLoop(loopTest);

                }

                if (tempIntTwo == 3)
                {
                    List<Move> listForBuilder = loopTest.moveList;
                    Move newMove = buildRoster.buildMoveFromConsole(listForBuilder);
                    loopTest.moveList.Add(newMove);

                    Console.Write("Press enter to continue"+"\n");
                    Console.ReadLine();
                    gameLoop(loopTest);
                }
                if (tempIntTwo == 4)
                {
                    Roster newRoster = buildRoster.buildRosterFromConsole(loopTest.getDataBase());
                    //roster has not been stored anywhere
                    Console.Write("Press enter to continue" + "\n");
                    Console.ReadLine();
                    gameLoop(loopTest);
                }
                if (tempIntTwo == 5)
                {
                    loopTest.printMoveList(loopTest.moveList);
                    Console.Write("Press enter to continue" + "\n");
                    Console.ReadLine();
                    gameLoop(loopTest);
                }

            }
            if (tempInt == 3)
            {
                Console.Write("Thanks for playing"+"\n");
            //saves moves
            XmlSerializer serializer = new XmlSerializer(typeof(List<Move>));
            TextWriter writer = new StreamWriter("movelist.xml");
            serializer.Serialize(writer, loopTest.moveList);
            writer.Close();

            }

            else
            {

            }

        }
        public Roster buildRosterFromConsole()
        {

            List<Monster> monsterList = new List<Monster>();
            Roster playerOneRoster = new Roster(monsterList,"Player One");
            Console.Write("How many Monsters does this roster need? (input an Integar)" + "\n");
            String p1NumberOfMonsterS = Console.ReadLine();

            int p1numMon = Convert.ToInt32(p1NumberOfMonsterS);
            for (int i = 0; i < p1numMon; i++)
            {
                Console.Write("Pick the Id of your first Monster" + "\n");
                for (int b = 0; b < monsterDataBase.Count; b++)
                {
                    Console.Write(" Monster: " + monsterDataBase.ElementAt(b).getName() + ", Id: " + monsterDataBase.ElementAt(b).getId() + "\n");
                }
                string monsterIdString = Console.ReadLine();
                int monsterId = Convert.ToInt32(monsterIdString);
                monsterId = monsterId - 1;
                playerOneRoster.addMonster(monsterDataBase.ElementAt(monsterId));

            }
            for (int i = 0; i < playerOneRoster.count(); i++)
            {
                Console.Write("Player 1 Monster at:" + +i + " is called = " + playerOneRoster.returnMonsterAt(i).getName() + "\n");
                for (int b = 0; b < playerOneRoster.returnMonsterAt(i).getMoveList().Count; b++)
                {
                    Console.Write(playerOneRoster.returnMonsterAt(i).getName() + " move number " + b + " is named " + playerOneRoster.returnMonsterAt(i).getMoveList().ElementAt(b).getName() + "\n");
                }
            }


            Console.ReadLine();
            return playerOneRoster;
        }
        public void simulatedMain()
        {
            Roster playerOneRoster = buildRosterFromConsole();
            Console.Write("Player Two" + "\n");
            Roster PlayerTwoRoster = buildRosterFromConsole();
            firstFight.battleManager(playerOneRoster, PlayerTwoRoster, monsterDataBase);
            Console.ReadLine();
        }
        public List<Monster> getDataBase()
        {
            return monsterDataBase;
        }
        
    }

}
