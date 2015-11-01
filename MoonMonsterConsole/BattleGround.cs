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
        public float principalAttackValue(monster attackMonster, Move attackMove)
        {
            float pAV = attackMove.getMaxDamage();


            float moveSize = attackMove.getSize();
            float moveSpeed = attackMove.getSpeed();
            float moveStrength = attackMove.getStrength();

            moveSize = moveSize / 100;
            moveSpeed = moveSpeed / 100;
            moveStrength = moveStrength / 100;

            int creatureSpeed = attackMonster.getSpeed();
            int creatureStrength = attackMonster.getstrength();
            int creatureSize = attackMonster.getSize();

            moveSize = moveSize * creatureSize;
            moveSpeed = moveSpeed * creatureSpeed;
            moveStrength = moveStrength * creatureStrength;
           // Console.Write("move size " + moveSize + "\n");
            //Console.Write("move speed " + moveSpeed + "\n");
            //Console.Write("move Strength " + moveStrength + "\n");

            float total = moveSize + moveSpeed + moveStrength;
            float effectivnessDecimal = total / 100;
            //Console.Write("move max damage @ 100% effecency " + pAV + "\n");
            //Console.Write("effectivness deceimal= " + effectivnessDecimal + "\n");
            pAV = pAV * effectivnessDecimal;
           // Console.Write("max damage after applied (defense still to be calculated) " + pAV + "\n");

            float levelMod = attackMonster.getlevel();
            levelMod = levelMod / 100;
           // Console.Write(" level mod attacker " + levelMod + "\n");
            pAV = pAV * levelMod;
            Console.Write(" final pAV w/ level consider " + pAV + "\n");
            Console.Write("\n");
            return pAV;
        }
        public float principalAttackValueFire(monster attackMonster, Move attackMove)
        {
            float pAV = attackMove.getMaxDamage();


            float moveSize = attackMove.getSize();
            float moveSpeed = attackMove.getSpeed();
            float moveStrength = attackMove.getStrength();

            moveSize = moveSize / 100;
            moveSpeed = moveSpeed / 100;
            moveStrength = moveStrength / 100;

            int creatureSpeed = attackMonster.getSpeed();
            int creatureStrength = attackMonster.getstrength();
            int creatureSize = attackMonster.getSize();

            moveSize = moveSize * creatureSize;
            moveSpeed = moveSpeed * creatureSpeed;
            moveStrength = moveStrength * creatureStrength;

            float total = moveSize + moveSpeed + moveStrength;


            float effectivnessDecimal = total / 100;
          //  Console.Write("move max damage @ 100% effecency " + pAV + "\n");

            pAV = pAV * effectivnessDecimal;
            //Console.Write("max damage after applied (defense still to be calculated) " + pAV + "\n");

            float levelMod = attackMonster.getlevel();
            levelMod = levelMod / 100;
        //    Console.Write(" level mod attacker " + levelMod + "\n");
            pAV = pAV * levelMod;
          //  Console.Write("pAV w/ level consider " + pAV + "\n");
            float fireMult = attackMove.getFire();
            fireMult = fireMult / 100;
           // Console.Write("fire mult " + fireMult + "\n");

            pAV = pAV * fireMult;
            Console.Write("pAV w/ fire " + pAV + "\n");
            Console.Write("\n");
            return pAV;
        }

        public float principalDefenseValue(monster defenseMonster, Move attackMove)
        {
            float pDV = attackMove.getMaxDefense();
          //  Console.Write("  max d =" + pDV + "\n");
            float dSpeed = attackMove.getDSpeed();
            float dSize = attackMove.getDSize();
            float dstrength = attackMove.getDStrength();
            //   Console.Write("dmove size after " + dSize + "\n");
            // Console.Write("dmove speed after " + dSpeed + "\n");
            // Console.Write("dmove strength after " + dstrength + "\n");
            // Console.Write(" " + "\n");

            dSpeed = dSpeed / 100;
            dSize = dSize / 100;
            dstrength = dstrength / 100;
            //Console.Write("dmove size after " + dSize + "\n");
            //Console.Write("dmove speed after " + dSpeed + "\n");
            //Console.Write("dmove strength after " + dstrength + "\n");
            //Console.Write(" " + "\n");

            int defenderSpeed = defenseMonster.getSpeed();
            int defenderSize = defenseMonster.getSize();
            int defenderStrengh = defenseMonster.getstrength();
            dSpeed = dSpeed * defenderSpeed;
            dSize = dSize * defenderSize;
            dstrength = dstrength * defenderStrengh;
            float total = dSpeed + dSize + dstrength;
            total = total / 100;
         //   Console.Write(" total % effective ness=  " + total + "\n");
            float levelMod = defenseMonster.getlevel();
            levelMod = levelMod / 100;
       //     Console.Write(" level mod " + levelMod + "\n");
            total = total * levelMod;
        //    Console.Write(" total=  " + total + "\n");
            pDV = pDV * total;
            Console.Write("principal defense value =" + pDV + "\n");
            Console.Write("\n");

           

            return pDV;
        }

        public float NetPrincipalDamage(float attack, float defense)
        {

            float damage = attack - defense;
            Console.Write(" net damage " + damage + "\n");
            return damage;
        }

        public float typeBonus(float bonusDecimal, float netPrincipalDamage)
        {
            netPrincipalDamage = netPrincipalDamage * bonusDecimal;
            Console.Write("damage after type bonus " + '\n');
            return netPrincipalDamage;
        }

        public float calcFireDamage(monster attackMonster, Move attackMove, monster defendingMonster)
        {
            float damage = 0;
            float netAttack;
            float netDefense;
            float fireTypeBonus = (float)1.75;
            netAttack = principalAttackValueFire(attackMonster, attackMove);
            netDefense = principalDefenseValue(defendingMonster, attackMove);
            damage = netAttack - netDefense;
            damage = typeBonus(fireTypeBonus, damage);
            return damage;
        }


        public Roster castMove(monster attackMonster, Move attackMove, monster defendingMonster)
        {


            int staminaRequired = attackMove.getStamina();
            int staminaPossessed = attackMonster.getstamina();
            // if (staminaRequired > staminaPossessed)
            //{
            //Console.Write("not enough stamina to function ERRRROR ERROR");
            //  return null;
            //}
            // else

            Console.Write("Move Name: " + attackMove.getName() + "\n");
            Console.Write("Attacker: " + attackMonster.getName() + " Level: " + attackMonster.getlevel() + "\n");
            Console.Write("Defender: " + defendingMonster.getName() + " Level: " + defendingMonster.getlevel() + "\n");
            float damage = 0;
            float netAttack;
            float netDefense;
            netAttack = principalAttackValue(attackMonster, attackMove);
            netDefense = principalDefenseValue(defendingMonster, attackMove);
            damage = netAttack - netDefense;

            int keepTrack = 0;  //keep track is for the if statement, since i am only buidling for one case right now
            if (attackMove.getType() == "normal")
            {
                Console.Write("check Normal " + "\n");
                keepTrack = 1;
            }
            if (attackMove.getType() == "lava")
            {
                if (defendingMonster.getType() == "plant")
                {
                    float fireTypeBonus = (float)1.75;
                    damage = typeBonus(fireTypeBonus, damage);
                    keepTrack = 1;
                    Console.Write("check lava on grass" + "\n");
                }
                if (defendingMonster.getType() == "ice")
                {
                    float fireTypeBonus = (float)2;
                    damage = typeBonus(fireTypeBonus, damage);
                    keepTrack = 1;
                    Console.Write("check lava on ice" + "\n");
                }
                if (defendingMonster.getType() == "rock")
                {
                    float fireTypeBonus = (float).60;
                    damage = typeBonus(fireTypeBonus, damage);
                    keepTrack = 1;
                    Console.Write("check lava on rock" + "\n");
                }
                if (defendingMonster.getType() == "water")
                {
                    float fireTypeBonus = (float).5;
                    damage = typeBonus(fireTypeBonus, damage);
                    keepTrack = 1;
                    Console.Write("check lava on water" + "\n");
                }

            }
            if (attackMove.getType() == "plant")
                Console.Write("check plant at first junction" + "\n");
            {
                if (defendingMonster.getType() == "rock")
                {
                    float fireTypeBonus = (float)2;
                    damage = typeBonus(fireTypeBonus, damage);
                    keepTrack = 1;
                    Console.Write("check plant on rock" + "\n");
                }
                if (defendingMonster.getType() == "lava")
                {
                    Console.Write("check plant on fire at step two" + "\n");
                    float fireTypeBonus = (float).7;
                    damage = typeBonus(fireTypeBonus, damage);
                    keepTrack = 1;
                    Console.Write("check plant on lava" + "\n");
                }
                if (defendingMonster.getType() == "ice")
                {
                    float fireTypeBonus = (float).6;
                    damage = typeBonus(fireTypeBonus, damage);
                    keepTrack = 1;
                    Console.Write("check plant on ice" + "\n");
                }
                if (defendingMonster.getType() == "water")
                {
                    float fireTypeBonus = (float)2;
                    damage = typeBonus(fireTypeBonus, damage);
                    keepTrack = 1;
                    Console.Write("check plant on water" + "\n");
                }




            }

            if (keepTrack == 0)
            {
                Console.Write("something went wrong with a specail move mult" + "\n");
            }

            int roundedD = (int)damage;
            Console.Write("rounded damage " + roundedD + "\n");
            Console.Write("health of defender before " + defendingMonster.gethealth() + "\n");

            // Before damage is rendered the random varible must be applied 
            //            the random effectiveness variable, it will be modeled as RE = (2 / 3 + E) + R where 2 / 3 represents 66 % 
            //effective all the time, then E = Level / 300, such that at level 100 a creature will be completely effective while
            //  a creature at 1 will be .661.Then another variable R will be created. R will be a number that is a random 
            //  number between the range of 0:X where x = 1 - (.2 / 3 + E), 

            defendingMonster.renderDamage(roundedD);
            Console.Write("health of defender after " + defendingMonster.gethealth() + "\n");
            Console.Write("\n");
            attackMonster.useStamina(attackMove.getStamina());
            List<monster> attackDefenderList = new List<monster>();
            attackDefenderList.Add(attackMonster);
            attackDefenderList.Add(defendingMonster);
            Roster attackDefense = new Roster(attackDefenderList);
            if (defendingMonster.currentlyLiving() == false)
            {
                Console.Write(defendingMonster.getName() + " is dead" + "\n");
            }

            return attackDefense;

        }

        public void printHealth(monster attacker, monster defender)
        {
            Console.Write(attacker.getName() + " health = " + attacker.gethealth() + "\n");
            Console.Write(defender.getName() + " health = " + defender.gethealth() + "\n");
            Console.Write("\n");

        }
    }
}

    


