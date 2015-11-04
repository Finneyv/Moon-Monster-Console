using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoonMonsterConsole
{
    class Builder
    {
        List<Move> moveList = new List<Move>();
        List<Monster> monsterDataBase = new List<Monster>();

        public Builder() { }

        public Move getMoveFromConsole(List<Move> moveList)
        {
            Console.Write("     Please pick a move (ID#) " + "\n");
            for (int b = 0; b < moveList.Count; b++)
            {
                Console.Write("Name: " + moveList.ElementAt(b).getName() + ", Id: " + moveList.ElementAt(b).getId() + ", Type: " + moveList.ElementAt(b).getType() + ", M Damage: " + moveList.ElementAt(b).getMaxDamage() + ", M Defense: " + moveList.ElementAt(b).getMaxDefense() + "\n");
            }
            string tempMove = Console.ReadLine();

            int tempMoveInt = Convert.ToInt32(tempMove);
            tempMoveInt = tempMoveInt - 1;
            Console.Write("Move chosen is: " + moveList.ElementAt(tempMoveInt).getName() + "\n");
            Console.Write("\n");
            return moveList.ElementAt(tempMoveInt);

        }

        public Move buildMoveFromConsole()
        {

            String tempString;
            String moveName;
            Console.Write("Input the Name of the move then press enter" + "\n");
            moveName = Console.ReadLine();
            Console.Write("Input the Moves Id"+"\n");
            tempString = Console.ReadLine();
            int moveId = Convert.ToInt32(tempString);
            int staminaReq = 0;
            Console.Write("Input the Stamina Req"+"\n");
            tempString = Console.ReadLine();
            staminaReq = Convert.ToInt32(tempString);
            String attackType = "";
            Console.Write("Input the Attack Type (lava,water,light,rock,plant,ice,normal) "+"\n");
            attackType= Console.ReadLine();
            int maxDamage = 0;
            Console.Write("Input the Max Damage: "+"\n");
            tempString = Console.ReadLine();
            maxDamage = Convert.ToInt32(tempString);          
            int maxDefense = 0;
            Console.Write("Input the Max Defense: "+"\n");
            tempString = Console.ReadLine();
            maxDefense = Convert.ToInt32(tempString);
            int attackSize = 0;
            Console.Write("Input the Attack Size" + "\n");
            tempString = Console.ReadLine();
            attackSize = Convert.ToInt32(tempString);
            int attackSpeed = 0;
            Console.Write("Input the attackSpeed: " + "\n");
            tempString = Console.ReadLine();
            attackSpeed = Convert.ToInt32(tempString);
            int defenseSize = 0;
            Console.Write("Input the Defense Size: " + "\n");
            tempString = Console.ReadLine();
            defenseSize = Convert.ToInt32(tempString);
            int defenseSpeed = 0;
            Console.Write("Input the Defense Speed: " + "\n");
            tempString = Console.ReadLine();
            defenseSpeed = Convert.ToInt32(tempString);
            int attackStrength = 0;
            Console.Write("Input the AttackStrength : " + "\n");
            tempString = Console.ReadLine();
            attackStrength = Convert.ToInt32(tempString);
            int defenseStrength = 0;
            Console.Write("Input the Defense Strength: " + "\n");
            tempString = Console.ReadLine();
            defenseStrength = Convert.ToInt32(tempString);
            int fire = 0;
            Console.Write("Input Fire Mastery: " + "\n");
            tempString = Console.ReadLine();
            fire = Convert.ToInt32(tempString);
            int ice = 0;
            Console.Write("Input Ice Mastery: " + "\n");
            tempString = Console.ReadLine();
            ice = Convert.ToInt32(tempString);
            int plant = 0;
            Console.Write("Input plant Mastery: " + "\n");
            tempString = Console.ReadLine();
            plant = Convert.ToInt32(tempString);
            int water = 0;
            Console.Write("Input Water Mastery: " + "\n");
            tempString = Console.ReadLine();
            water = Convert.ToInt32(tempString);
            int rock = 0;
            Console.Write("Input Rock Mastery: " + "\n");
            tempString = Console.ReadLine();
            rock = Convert.ToInt32(tempString);
            int light = 0;
            Console.Write("Input lightening Mastery: " + "\n");
            tempString = Console.ReadLine();
            light = Convert.ToInt32(tempString);
            Move tempMove = new Move(moveName, moveId, staminaReq, attackType, maxDamage, maxDefense, attackSize, attackSpeed, defenseSize,
                defenseSpeed, attackStrength, defenseStrength, fire, ice, plant, water, rock, light);
            return tempMove;
        }


       public Monster buildMonsterFromConsole(List<Move> moveList)
        {

            List<Move> tempMoves = moveList;
            String tempString;
            String name;
            Console.Write("Input the Name of the monster then press enter" + "\n");
            name = Console.ReadLine();

            Console.Write("Input the Monster Id" + "\n");
            tempString = Console.ReadLine();
            int iD = Convert.ToInt32(tempString);
            int stamina = 0;

            Console.Write("Input the Max Stamina" + "\n");
            tempString = Console.ReadLine();
            stamina = Convert.ToInt32(tempString);
            String type = "";


            Console.Write("Input the Type (lava,water,light,rock,plant,ice,normal) " + "\n");
            type = Console.ReadLine();

            int health = 0;
            Console.Write("Input the Max Health: " + "\n");
            tempString = Console.ReadLine();
            health = Convert.ToInt32(tempString);
            
            int attackSize = 0;
            Console.Write("Input the Attack Size" + "\n");
            tempString = Console.ReadLine();
            attackSize = Convert.ToInt32(tempString);

            int attackSpeed = 0;
            Console.Write("Input the attackSpeed: " + "\n");
            tempString = Console.ReadLine();
            attackSpeed = Convert.ToInt32(tempString);

            int level = 0;
            Console.Write("Input the level: " + "\n");
            tempString = Console.ReadLine();
            level = Convert.ToInt32(tempString);

            int agility = 0;
            Console.Write("Input the agility: " + "\n");
            tempString = Console.ReadLine();
            agility = Convert.ToInt32(tempString);


            int attackStrength = 0;
            Console.Write("Input the attackStrength: " + "\n");
            tempString = Console.ReadLine();
            attackStrength = Convert.ToInt32(tempString);


            Monster tempMonster = new Monster(name, iD, health, stamina, level, attackSpeed, agility, attackStrength, attackSize, tempMoves,type);
            return tempMonster;
        }
        public Roster buildRosterFromConsole(List<Monster> monsterDataBase)
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
                    Console.Write(" Monster: " + monsterDataBase.ElementAt(b).getName() + ", Id: " + monsterDataBase.ElementAt(b).getId() + ", Level:  " + monsterDataBase.ElementAt(b).getLevel() + ", Type: " + monsterDataBase.ElementAt(b).getType() + ", Health: " + monsterDataBase.ElementAt(b).getHealth() + "\n");
                }
                string monsterOrderString = Console.ReadLine();
                int monsterOrder = Convert.ToInt32(monsterOrderString);
                monsterOrder = monsterOrder - 1;

                playerOneRoster.addMonster(monsterDataBase.ElementAt(monsterOrder));
            }
            for (int i = 0; i < playerOneRoster.count(); i++)
            {
                Console.Write("Player" + "\n");
                //Monster at:" + +i + " is called = " + playerOneRoster.returnMonsterAt(i).getName() + "\n");

                for (int b = 0; b < playerOneRoster.returnMonsterAt(i).getMoveList().Count; b++)
                {
                    Console.Write(playerOneRoster.returnMonsterAt(i).getName() + " move number " + b + " is named " + playerOneRoster.returnMonsterAt(i).getMoveList().ElementAt(b).getName() + "\n");
                }
            }
            Console.ReadLine();
            return playerOneRoster;
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
            Monster tempMonster = monsterBuilder.buildMonsterFromConsole(moveList);

            Monster dragonShep = new Monster("Dragon Sheppard", 1, 815, 400, 11, 85, 50, 90, 80, moveList, "lava");
            //List<Move> moveLister = dragonShep.getMoveList();
            //Move firstmove = moveLister.ElementAt(0);

            Monster triceritops = new Monster("Triceritops", 2, 800, 400, 13, 70, 50, 90, 80, moveList, "plant");
            Monster prettyMermaid = new Monster("Pretty Mermaid", 3, 875, 400, 13, 90, 90, 50, 40, moveList, "water");
            Monster snowDeamon = new Monster("Snow Deamon", 4, 850, 70, 13, 80, 65, 80, 70, moveList, "ice");
            Monster thunderCloud = new Monster("Thunder Cloud", 5, 900, 400, 14, 90, 90, 0, 30, moveList, "light");


            monsterDataBase.Add(dragonShep);
            monsterDataBase.Add(triceritops);
            monsterDataBase.Add(prettyMermaid);
            monsterDataBase.Add(snowDeamon);
            monsterDataBase.Add(thunderCloud);
            monsterDataBase.Add(tempMonster);
            //   List<Move> moveListerT = dragonShep.getMoveList();
            // Move secondMove = moveListerT.ElementAt(0);

            /*
            Console.Write("triceritpos health= " + triceritops.getHealth() + "\n");
            Console.Write("max damage for bite is " + secondMove.getMaxDamage() + "\n");
            Console.Write("dragon shep health= " +dragonShep.getHealth() + "\n");
            Console.Write("max damage for bite is " + firstmove.getMaxDamage() + "\n");
            Console.ReadLine();
            */
        }

        public List<Move> buildmoves()
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
            Move bite = new Move("bite", 1, 5, "normal", 700, 200, 35, 25, 60, 15, 40, 25, 0, 0, 0, 0, 0, 0);
            Move fireBreath = new Move("fire Breath", 2, 0, "lava", 950, 450, 15, 50, 50, 20, 50, 30, 85, 0, 0, 0, 0, 0);
            Move photoBeam = new Move("photoBeam", 3, 6, "plant", 750, 200, 35, 40, 60, 25, 40, 25, 0, 0, 85, 0, 0, 0);
            moveList.Add(bite);
            moveList.Add(fireBreath);
            moveList.Add(photoBeam);

            return moveList;


        }

    }

}
