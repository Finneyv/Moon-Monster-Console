using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoonMonsterConsole
{
    class BattleGround
    {
        Roster playerOneRoster;
        Roster playerTwoRoster;
        public BattleGround(Roster playerOneTemp, Roster playerTwoTemp)
        {
            playerOneRoster = playerOneTemp;
            playerTwoRoster = playerTwoTemp;
        }
        public float principalAttackValue(monster attackMonster,Move attackMove)
        {
            float pAV = attackMove.getMaxDamage();
           
            
            float moveSize =  attackMove.getSize();
            float moveSpeed = attackMove.getSpeed();
            float moveStrength = attackMove.getStrength();
         //   Console.Write("move size first " + moveSize + "\n");
            moveSize = moveSize / 100;
            moveSpeed = moveSpeed / 100;
            moveStrength = moveStrength / 100;
           // Console.Write("move size after " + moveSize + "\n");
           // Console.Write("move speed after " + moveSpeed + "\n");
            //Console.Write("move strength after " + moveStrength + "\n");
            int creatureSpeed = attackMonster.getSpeed();
            int creatureStrength = attackMonster.getstrength();
            int creatureSize = attackMonster.getSize();

            //Console.Write("creature size is " + creatureSize + "\n");
            //Console.Write("creature strength is " + creatureStrength + "\n");
            //Console.Write("creature speed is " + creatureSpeed + "\n");
            moveSize = moveSize * creatureSize;
            moveSpeed = moveSpeed * creatureSpeed;
            moveStrength = moveStrength * creatureStrength;
         //   Console.Write(" " + "\n");
           // Console.Write("after wieghts assigned for dragonShep " + "\n");
            //Console.Write("move size after " + moveSize + "\n");
            //Console.Write("move speed after " + moveSpeed + "\n");
            //Console.Write("move strength after " + moveStrength + "\n");
           // Console.Write(" " + "\n");
            float total = moveSize + moveSpeed + moveStrength;
            //Console.Write("overall effectiveness " + total + "\n");
            //Console.Write("max damage " + pAV + "\n");

            float effectivnessDecimal = total / 100;
            pAV = pAV * effectivnessDecimal;
            Console.Write("max damage after applied (defense still to be calculated) " + pAV + "\n");
            //   Console.Write("final move speed " + moveSpeed + " final moveSize " + moveSize + " movestrength " + moveStrength+" total "+ total+ "\n");
            Console.ReadLine();


            float levelMod = attackMonster.getlevel();
            levelMod = levelMod / 100;
            Console.Write(" level mod " + levelMod + "\n");
            pAV = pAV * levelMod;
            Console.Write(" final pAV w/ level consider " + pAV + "\n");
            return pAV;
        }

        public float principalDefenseValue(monster defenseMonster,Move attackMove)
        {
            float pDV = attackMove.getMaxDefense();
            Console.Write("  max d =" +pDV+ "\n");
            float dSpeed = attackMove.getDSpeed();
            float dSize = attackMove.getDSize();
            float dstrength = attackMove.getDStrength();
            Console.Write("dmove size after " + dSize + "\n");
            Console.Write("dmove speed after " + dSpeed + "\n");
            Console.Write("dmove strength after " + dstrength + "\n");
            Console.Write(" " + "\n");

            dSpeed = dSpeed / 100;
            dSize = dSize / 100;
            dstrength = dstrength / 100;
            Console.Write("dmove size after " + dSize + "\n");
            Console.Write("dmove speed after " + dSpeed + "\n");
            Console.Write("dmove strength after " + dstrength + "\n");
            Console.Write(" " + "\n");

            int defenderSpeed=defenseMonster.getSpeed();
            int defenderSize=defenseMonster.getSize();
            int defenderStrengh=defenseMonster.getstrength();
            dSpeed = dSpeed * defenderSpeed;
            dSize = dSize * defenderSize;
            dstrength = dstrength * defenderStrengh;
            float total = dSpeed + dSize + dstrength;
            Console.Write(" total % effective ness=  " +total+ "\n");
            //Console.Write("dmove size after " + dSize + "\n");
            //Console.Write("dmove speed after " + dSpeed + "\n");
            //Console.Write("dmove strength after " + dstrength + "\n");
            Console.Write(" " + "\n");

            float levelMod = defenseMonster.getlevel();
            levelMod = levelMod / 100;
            Console.Write(" level mod " +levelMod+ "\n");
            total = total * levelMod;
            Console.Write(" total=  " + total + "\n");




            return pDV;
        }
        
        public float returnNetPrincipalDamage(float attack, float defense)
        {

            float damage = attack-defense;
            Console.Write(" net damage "+damage + "\n");
            return damage;
        }
     
      


    }
}
