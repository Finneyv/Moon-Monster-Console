using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoonMonsterConsole
{
    class Builder
    {


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

    }

}
