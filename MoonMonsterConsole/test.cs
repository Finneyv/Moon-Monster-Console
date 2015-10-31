using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoonMonsterConsole
{

    class test
    {
        monster dragonShep;
        monster triceritops;
        Roster playerOne;
        Roster playerTwo;
        List<Move> moveList = new List<Move>();
        List<monster> monsterDataBase = new List<monster>();
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
            Move bite = new Move(1, 45, "normal", 700, 200, 35, 25, 60, 15, 40,90,0, 0, 0,0,0,0);
            moveList.Add(bite);
           
        

    }
        public void buildmonsters()
        {
            /*
          Dragon Shep
          id=2
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

            dragonShep = new monster(2, 815, 100, 56, 85, 50,90,80, moveList);
            List<Move> moveLister = dragonShep.getmoveList();
            Move firstmove = moveLister.ElementAt(0);
            monsterDataBase.Add(dragonShep);
            triceritops = new monster(5, 900, 100, 57, 90, 50, 90,80, moveList);
            List<Move> moveListerT = dragonShep.getmoveList();
            Move secondMove = moveListerT.ElementAt(0);
            monsterDataBase.Add(triceritops);
            /*
            Console.Write("triceritpos health= " + triceritops.gethealth() + "\n");
            Console.Write("max damage for bite is " + secondMove.getMaxDamage() + "\n");
            Console.Write("dragon shep health= " +dragonShep.gethealth() + "\n");
            Console.Write("max damage for bite is " + firstmove.getMaxDamage() + "\n");
            Console.ReadLine();
            */
        }
        public void buildRoster()
        {
            List<monster> player1temp = new List<monster>();
            player1temp.Add(monsterDataBase.ElementAt(0));
            playerOne = new Roster(player1temp);

            List<monster> player2Temp = new List<monster>();
            player2Temp.Add(monsterDataBase.ElementAt(1));
            playerTwo = new Roster(player2Temp);


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
            BattleGround firstFight = new BattleGround(playerOne, playerTwo);
            int damage=firstFight.maxDamageSpec();
            Console.Write("bite battle damage max is " + damage + "\n");
            firstFight.applieddamage();
            Console.ReadLine();
        }
        public void runtest()
        {
            buildmoves();
            buildmonsters();
            buildRoster();
            buildBattleGround();
        }

    }
}
