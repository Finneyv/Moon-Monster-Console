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
        Monster dragonShep;
        Monster triceritops;
        Roster playerOne;
        Roster playerTwo;
        List<Move> moveList = new List<Move>();
        List<Monster> monsterDataBase = new List<Monster>();
        BattleGround firstFight;
        Builder Build = new Builder();
       
        public void buildmoves()
        {
            /*magic bite 
            max damage = 700
            max defense = 200
            size = 35
            strength = 40
            speed = 25
            type = normal
            dsize = 60
            dstrength = 25
            dspeed = 15
            fire = 0;
            ice = 0
            plant = 0
            water = 0
            rock = 0
            lightning = 0
            moveid=1
            stamina=45
               */
           // Builder moveBuilder = new Builder();
          //  Move tempMove = moveBuilder.buildMoveFromConsole();
            //moveList.Add(tempMove);
            Move bite = new Move("bite",1, 5, "normal", 2000, 200, 35, 25, 60, 15, 40,25,0, 0, 0,0,0,0,1);
            Move fireBreath = new Move("fire Breath",2, 0, "lava", 2150, 450, 15, 50, 50, 20, 50, 30, 85, 0, 0, 0, 0, 0,1);
            Move photoBeam = new Move("photoBeam", 3, 6, "plant", 1750, 200, 35, 40, 60, 25, 40, 25, 0, 0, 85, 0, 0, 0,1);
            moveList.Add(bite);
            moveList.Add(fireBreath);
            moveList.Add(photoBeam);

            XmlSerializer serializer = new XmlSerializer(typeof(List<Move>));
            TextWriter writer = new StreamWriter("movelist.xml");
            serializer.Serialize(writer, moveList);
            writer.Close();



        }
        public test()
        {
            this.monsterDataBase = new List<Monster>();
        }
        public void buildMonsters()
        {
            /*
          Dragon Shep
          id=1
          type=fire
          health=815
          size=80
          strength=80
          speed=85
          agility=50
          fire=85
          ice=0
          plant=0
          rock=0
          lighting=0
          stamina=100
          level=56

          */

          //  Builder monsterBuilder = new Builder();
           // Monster tempMonster=monsterBuilder.buildMonsterFromConsole(moveList);

            dragonShep = new Monster("Dragon Sheppard",1, 815, 400, 11, 85, 50,90,80, moveList,"lava");
            //List<Move> moveLister = dragonShep.getMoveList();
            //Move firstmove = moveLister.ElementAt(0);
          
            triceritops = new Monster("Triceritops", 2, 800, 400, 13, 70, 50, 90, 80, moveList, "plant");
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

            //  Builder monsterBuilder = new Builder();
            // Monster tempMonster=monsterBuilder.buildMonsterFromConsole(moveList);
            // monsterDataBase.Add(tempMonster);

        }    
        public void printMoveList()
        {
            var moves = new List<Move>();

            XmlSerializer serializer = new XmlSerializer(typeof(List<Move>));
            TextReader reader = new StreamReader("movelist.xml");
            moves = (List<Move>)serializer.Deserialize(reader);
            reader.Close();
            Console.Write("movelist ");
            for (int b = 0; b < moves.Count; b++)
            {
                Console.Write("Name: " + moves.ElementAt(b).getName() + ", Id: " + moves.ElementAt(b).getId() + ", Type: " + moves.ElementAt(b).getType() + ", M Damage: " + moves.ElementAt(b).getMaxDamage() + ", M Defense: " + moves.ElementAt(b).getMaxDefense() + "\n");
            }
        }

        public void printMonsterList()
        {
            var monster = new List<Monster>();

            XmlSerializer serializer = new XmlSerializer(typeof(List<Move>));
            TextReader reader = new StreamReader("monsterdatabase.xml");
            monster = (List<Monster>)serializer.Deserialize(reader);
            reader.Close();

            for (int b = 0; b < monster.Count; b++)
            {
                Console.Write("Name: " + monster.ElementAt(b).getName() + ", Id: " + monster.ElementAt(b).getId() + ", Type: " + monster.ElementAt(b).getType() + "\n");
            }
        }




        public void buildRoster()
        {
            List<Monster> player1temp = new List<Monster>();
            player1temp.Add(monsterDataBase.ElementAt(0));
            playerOne = new Roster(player1temp,"PLayer One");

           
            playerOne.addMonster(dragonShep);
            playerOne.addMonster(dragonShep);
            playerOne.addMonster(dragonShep);
            playerOne.addMonster(triceritops);
            playerOne.addMonster(triceritops);

            List<Monster> player2Temp = new List<Monster>();
            player2Temp.Add(monsterDataBase.ElementAt(1));
            playerTwo = new Roster(player2Temp, "Player Two");
            playerTwo.addMonster(triceritops);
            playerTwo.addMonster(triceritops);
            playerTwo.addMonster(triceritops);
            playerTwo.addMonster(dragonShep);
            playerTwo.addMonster(dragonShep);
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
        public void buildBattleGround()
        {
            // First battle, dragon shepard (DS) vs triceritops (T)
            firstFight = new BattleGround(playerOne, playerTwo,monsterDataBase);
           

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
            printMoveList();
            Console.Write("\n");

            return moveList.ElementAt(tempMoveInt);

        }
        public void testBattleManager()
        {

            firstFight.battleManager(playerOne,playerTwo,monsterDataBase);
            Console.ReadLine();
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
            buildmoves();
            buildMonsters();
            buildRoster();
            buildBattleGround();
            // printMoveList();


            //simulatedMain();
            // buildRosterFromConsole(); //this wil build the rosters from console that will be fed to battle ground
            //    testBattleManager(); //this is where we will input two rosters and then this will manage the roster interaction

            // testFirstFight(); //this runs a hard coded battle between Dragon and Triceritops
            //    Builder firstBuilider = new Builder(); //testing builderClass
            //  firstBuilider.buildMoveFromConsole();
            startUpConsole();

            Console.ReadLine();

        }
        static void startUpConsole()
        {

            Console.Write("Welcome to Moon Monster, the Conquest of the Future" + "\n");
            // Console.Write("Today will be a two player gamee" + "\n");
            gameLoop();


        }
        public List<Monster> buildMonstersList()
        {
            /*
          Dragon Shep
          id=1
          type=fire
          health=815
          size=80
          strength=80
          speed=85
          agility=50
          fire=85
          ice=0
          plant=0
          rock=0
          lighting=0
          stamina=100
          level=56

          */

            //  Builder monsterBuilder = new Builder();
            // Monster tempMonster=monsterBuilder.buildMonsterFromConsole(moveList);

            dragonShep = new Monster("Dragon Sheppard", 1, 815, 400, 11, 85, 50, 90, 80, moveList, "lava");
            //List<Move> moveLister = dragonShep.getMoveList();
            //Move firstmove = moveLister.ElementAt(0);

            triceritops = new Monster("Triceritops", 2, 800, 400, 13, 70, 50, 90, 80, moveList, "plant");
            Monster prettyMermaid = new Monster("Pretty Mermaid", 3, 875, 400, 13, 90, 90, 50, 40, moveList, "water");
            Monster snowDeamon = new Monster("Snow Deamon", 4, 850, 70, 13, 80, 65, 80, 70, moveList, "ice");
            Monster thunderCloud = new Monster("Thunder Cloud", 5, 900, 400, 14, 90, 90, 0, 30, moveList, "light");


            monsterDataBase.Add(dragonShep);
            monsterDataBase.Add(triceritops);
            monsterDataBase.Add(prettyMermaid);
            monsterDataBase.Add(snowDeamon);
            monsterDataBase.Add(thunderCloud);
            return monsterDataBase;
            //  Builder monsterBuilder = new Builder();
            // Monster tempMonster=monsterBuilder.buildMonsterFromConsole(moveList);
            // monsterDataBase.Add(tempMonster);

        }
        static void gameLoop()
        {

            Builder buildRoster = new Builder();
            test secondTest = new test();
            secondTest.buildmoves();
            secondTest.buildMonsters();
           Console.Write("database count at start: " + secondTest.monsterDataBase.Count() + "\n");
            Console.Write("What would you like to do today? Enter 1 to play, 2 to develop or 3 to exit " + "\n");
            string tempString = Console.ReadLine();
            int tempInt = Convert.ToInt32(tempString);
            if (tempInt == 1)
            {
                Console.Write("Player One please select your roster;"+"\n");
               
                Roster playerOne = buildRoster.buildRosterFromConsole(secondTest.getDataBase());
                Console.Write("Player Two please selecet your roster:"+"\n");
                Roster playerTwo= buildRoster.buildRosterFromConsole(secondTest.getDataBase());
                BattleGround firstLoop = new BattleGround(playerOne,playerTwo,secondTest.getDataBase());
                firstLoop.iterator(playerOne, playerTwo);
                gameLoop();

            }
            if (tempInt == 2)
            {
                Console.Write("Welcome to Developer Mode: " + "\n");
                Console.Write("Please Select a number from the following list: " + "\n");
                Console.Write("1: View Monster DataBase: " + "\n");
                Console.Write("2: Create Nwe Monster" + "\n");
                Console.Write("3: Create new Move" + "\n");
                Console.Write("4: Create new Roster"+"\n");
                Console.Write("5: view move List " + "\n");
                Console.Write("6: view Monster Database"+"\n");
                string tempStringTwo=Console.ReadLine();
                int tempIntTwo = Convert.ToInt32(tempStringTwo);
                if (tempIntTwo == 1)
                {
                    for(int i = 0; i < secondTest.getDataBase().Count(); i++)
                    {
                        Console.Write(" Monster: " + secondTest.getDataBase().ElementAt(i).getName() + ", Id: " + secondTest.getDataBase().ElementAt(i).getId() + ", Level:  " + secondTest.getDataBase().ElementAt(i).getLevel() + ", Type: " + secondTest.getDataBase().ElementAt(i).getType() + ", Health: " + secondTest.getDataBase().ElementAt(i).getHealth() + "\n");
                        
                        
                    }
                    Console.Write("Press enter to continue"+"\n");
                    Console.ReadLine();
                    gameLoop();
                }
                if (tempIntTwo == 2)
                {
                    Monster newMonster = buildRoster.buildMonsterFromConsole(secondTest.moveList);
                    secondTest.monsterDataBase.Add(newMonster);

                    Console.Write("Press enter to continue");
                    Console.ReadLine();
                    gameLoop();

                }

                if (tempIntTwo == 3)
                {
                    Move newMove = buildRoster.buildMoveFromConsole();
                    secondTest.moveList.Add(newMove);
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Move>));
                    TextWriter writer = new StreamWriter("movelist.xml");
                    serializer.Serialize(writer, newMove);
                    writer.Close();
                    Console.Write("Seriializer closed");

                    Console.Write("Press enter to continue");
                    Console.ReadLine();
                    gameLoop();
                }
                if (tempIntTwo == 4)
                {

                    Roster newRoster = buildRoster.buildRosterFromConsole(secondTest.getDataBase());
                    //roster has not been stored anywhere

                    Console.Write("Press enter to continue");
                    Console.ReadLine();
                    gameLoop();

                }
                if (tempIntTwo == 5)
                {
                    secondTest.printMoveList();
                    Console.Write("Press enter to continue");
                    Console.ReadLine();
                    gameLoop();
                }
                if (tempIntTwo == 6)
                {
                    secondTest.printMoveList();
                    Console.Write("Press enter to continue");
                    Console.ReadLine();
                    gameLoop();
                }

            }
            if (tempInt == 3)
            {
                Console.Write(" Thank for playing ");
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
