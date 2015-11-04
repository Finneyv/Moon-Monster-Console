using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoonMonsterConsole
{

    class test
    {
        Monster dragonShep;
        Monster triceritops;
        Roster playerOne;
        Roster playerTwo;
        List<Move> moveList = new List<Move>();
        List<Monster> monsterDataBase = new List<Monster>();
        BattleGround firstFight;
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
            Move bite = new Move("bite",1, 5, "normal", 700, 200, 35, 25, 60, 15, 40,25,0, 0, 0,0,0,0);
            Move fireBreath = new Move("fire Breath",2, 0, "lava", 950, 450, 15, 50, 50, 20, 50, 30, 85, 0, 0, 0, 0, 0);
            Move photoBeam = new Move("photoBeam", 3, 6, "plant", 750, 200, 35, 40, 60, 25, 40, 25, 0, 0, 85, 0, 0, 0);
            moveList.Add(bite);
            moveList.Add(fireBreath);
            moveList.Add(photoBeam);
           

        

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

            Builder monsterBuilder = new Builder();
            Monster tempMonster=monsterBuilder.buildMonsterFromConsole(moveList);

            dragonShep = new Monster("Dragon Sheppard",1, 815, 400, 11, 85, 50,90,80, moveList,"lava");
            //List<Move> moveLister = dragonShep.getmoveList();
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
            monsterDataBase.Add(tempMonster);
         //   List<Move> moveListerT = dragonShep.getmoveList();
           // Move secondMove = moveListerT.ElementAt(0);
            
            /*
            Console.Write("triceritpos health= " + triceritops.gethealth() + "\n");
            Console.Write("max damage for bite is " + secondMove.getMaxDamage() + "\n");
            Console.Write("dragon shep health= " +dragonShep.gethealth() + "\n");
            Console.Write("max damage for bite is " + firstmove.getMaxDamage() + "\n");
            Console.ReadLine();
            */
        }
     
        public void printMoveList()
        {
            for (int b = 0; b < moveList.Count; b++)
            {
                Console.Write("Name: " + moveList.ElementAt(b).getName() + ", Id: " + moveList.ElementAt(b).getId() + ", Type: " + moveList.ElementAt(b).getType() + ", M Damage: " + moveList.ElementAt(b).getMaxDamage() + ", M Defense: " + moveList.ElementAt(b).getMaxDefense() + "\n");
            }
        }
        public void buildRoster()
        {
            List<Monster> player1temp = new List<Monster>();
            player1temp.Add(monsterDataBase.ElementAt(0));
            playerOne = new Roster(player1temp);

           
            playerOne.addMonster(dragonShep);
            playerOne.addMonster(dragonShep);
            playerOne.addMonster(dragonShep);
            playerOne.addMonster(triceritops);
            playerOne.addMonster(triceritops);

            List<Monster> player2Temp = new List<Monster>();
            player2Temp.Add(monsterDataBase.ElementAt(1));
            playerTwo = new Roster(player2Temp);
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
        }
        public void buildBattleGround()
        {
            // First battle, dragon shepard (DS) vs triceritops (T)
            firstFight = new BattleGround(playerOne, playerTwo,monsterDataBase);
           

        }
        public Move getMoveFromConsole(List<Move> moveList)
        {
            Console.Write("     Please pick a move"+"\n");
            for (int b = 0; b < moveList.Count; b++)
            {
                Console.Write("Name: " + moveList.ElementAt(b).getName() + ", Id: " + moveList.ElementAt(b).getId()+", Type: "+ moveList.ElementAt(b).getType() + ", M Damage: "+ moveList.ElementAt(b).getMaxDamage()+", M Defense: "+ moveList.ElementAt(b).getMaxDefense() + "\n");
            }
            string tempMove=Console.ReadLine();
            int tempMoveInt = Convert.ToInt32(tempMove);
            tempMoveInt = tempMoveInt - 1;
            Console.Write("Move chosen is: " +moveList.ElementAt(tempMoveInt).getName()+ "\n");
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
              testBattleManager(); //this is where we will input two rosters and then this will manage the roster interaction

           // testFirstFight(); //this runs a hard coded battle between Dragon and Triceritops
            //    Builder firstBuilider = new Builder(); //testing builderClass
            //  firstBuilider.buildMoveFromConsole();
            Console.ReadLine();

        }

        public Roster buildRosterFromConsole()
        {

            List<Monster> monsterList = new List<Monster>();
            Roster playerOneRoster = new Roster(monsterList);
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
                for (int b = 0; b < playerOneRoster.returnMonsterAt(i).getmoveList().Count; b++)
                {
                    Console.Write(playerOneRoster.returnMonsterAt(i).getName() + " move number " + b + " is named " + playerOneRoster.returnMonsterAt(i).getmoveList().ElementAt(b).getName() + "\n");
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

        
    }

}
