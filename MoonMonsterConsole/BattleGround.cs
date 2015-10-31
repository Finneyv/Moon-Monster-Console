using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoonMonsterConsole
{
    class BattleGround
    {
        Roster playerOne;
        Roster playerTwo;
        public BattleGround(Roster playerOneTemp, Roster playerTwoTemp)
        {
            playerOne = playerOneTemp;
            playerTwo = playerTwoTemp;
        }

       public int maxDamageSpec()
        {
            monster tem=playerOne.returnMonsterAt(0);
            int damage=tem.getmoveList().ElementAt(0).getMaxDamage();

            return damage;


        }
        public float applieddamage() {
            float damage;
            monster tem = playerOne.returnMonsterAt(0);
            damage = tem.getmoveList().ElementAt(0).getMaxDamage();
            float moveSize = tem.getmoveList().ElementAt(0).getSize();
            float moveSpeed = tem.getmoveList().ElementAt(0).getSpeed();
            float moveStrength = tem.getmoveList().ElementAt(0).getStrength();
            Console.Write("move size first " + moveSize+"\n");
            moveSize = moveSize / 100;
            moveSpeed = moveSpeed / 100;
            moveStrength = moveStrength / 100;
            Console.Write("move size after " + moveSize+"\n");
            int creatureSpeed=playerOne.returnMonsterAt(0).getSpeed();
            int creatureStrength = playerOne.returnMonsterAt(0).getstrength();
            int creatureSize = playerOne.returnMonsterAt(0).getSize();
            Console.Write("creature size is " + creatureSize + "\n");

            moveSize = creatureSize * moveSize;
            moveSpeed = creatureSpeed * moveSpeed;
            moveStrength = creatureStrength * moveStrength;
            float total = moveSize + moveSpeed + moveStrength;

            Console.Write("final move speed " + moveSpeed + " final moveSize " + moveSize + " movestrength " + moveStrength+" total "+ total+ "\n");
            Console.ReadLine();
            return damage;
        }


    }
}
