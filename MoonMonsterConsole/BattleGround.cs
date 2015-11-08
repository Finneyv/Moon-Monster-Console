using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoonMonsterConsole
{
   public class BattleGround
    {
        Builder Build = new Builder();
        Roster playerOneRoster;
        Roster playerTwoRoster;
        List<Monster> monsterDataBase;
        public BattleGround(Roster playerOneTemp, Roster playerTwoTemp, List<Monster> monsterDataBaseFeed)
        {
            playerOneRoster = playerOneTemp;
            playerTwoRoster = playerTwoTemp;
            monsterDataBase = monsterDataBaseFeed;
        }
        public float principalAttackValue(Monster attackMonster, Move attackMove)
        {
            float pAV = attackMove.getMaxDamage();


            float moveSize = attackMove.getSizeAttacker();
            float moveSpeed = attackMove.getSpeed();
            float moveStrength = attackMove.getStrength();

            moveSize = moveSize / 100;
            moveSpeed = moveSpeed / 100;
            moveStrength = moveStrength / 100;

            int creatureSpeed = attackMonster.getSpeed();
            int creatureStrength = attackMonster.getStrength();
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
          //  Console.Write("effectivness deceimal= " + effectivnessDecimal + "\n");
            pAV = pAV * effectivnessDecimal;
            // Console.Write("max damage after applied (defense still to be calculated) " + pAV + "\n");

            float levelMod = attackMonster.getLevel();
            levelMod = levelMod / 100;
           // Console.Write(" level mod attacker " + levelMod + "\n");
            pAV = pAV * levelMod;
        //    Console.Write(" final pAV w/ level consider " + pAV + "\n");
      //      Console.Write("\n");
            return pAV;
        }
 /*       public float principalAttackValueFire(Monster attackMonster, Move attackMove)
        {
            float pAV = attackMove.getMaxDamage();


            float moveSize = attackMove.getSizeAttacker();
            float moveSpeed = attackMove.getSpeed();
            float moveStrength = attackMove.getStrength();

            moveSize = moveSize / 100;
            moveSpeed = moveSpeed / 100;
            moveStrength = moveStrength / 100;

            int creatureSpeed = attackMonster.getSpeed();
            int creatureStrength = attackMonster.getStrength();
            int creatureSize = attackMonster.getSize();

            moveSize = moveSize * creatureSize;
            moveSpeed = moveSpeed * creatureSpeed;
            moveStrength = moveStrength * creatureStrength;

            float total = moveSize + moveSpeed + moveStrength;


            float effectivnessDecimal = total / 100;
          //  Console.Write("move max damage @ 100% effecency " + pAV + "\n");

            pAV = pAV * effectivnessDecimal;
            //Console.Write("max damage after applied (defense still to be calculated) " + pAV + "\n");

            float levelMod = attackMonster.getLevel();
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
        */
        public float principalDefenseValue(Monster defenseMonster, Move attackMove)
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


            int defenderSpeed = defenseMonster.getSpeed();
            int defenderSize = defenseMonster.getSize();
            int defenderStrengh = defenseMonster.getStrength();
            dSpeed = dSpeed * defenderSpeed;
            dSize = dSize * defenderSize;
            dstrength = dstrength * defenderStrengh;
            float total = dSpeed + dSize + dstrength;
            total = total / 100;
       
            float levelMod = defenseMonster.getLevel();
            levelMod = levelMod / 100;
    
            total = total * levelMod;
      
            pDV = pDV * total;


           

            return pDV;
        }

        public Move getMoveFromConsole(List<Move> moveList,Monster attackMonster)
        {
            
            for (int b = 0; b < moveList.Count; b++)
            {
                Move moveChoice = new Move();
                moveChoice = moveList.ElementAt(b);
                float pAv= principalAttackValue(attackMonster, moveChoice);
                pAv = pAv / attackMonster.getLevel();
                int a = b;
                a += 1;
                Console.Write("Name: " + moveList.ElementAt(b).getName() + ", Choice: " + a + ", Type: " + moveList.ElementAt(b).getType() +", Perfect Hit: "+pAv + "\n");
            }
            string tempMove = Console.ReadLine();
            
            int tempMoveInt = Convert.ToInt32(tempMove);
            tempMoveInt = tempMoveInt - 1;
            Console.Write("Move chosen is: " + moveList.ElementAt(tempMoveInt).getName() + "\n");
            Console.Write("\n");
            return moveList.ElementAt(tempMoveInt);

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

        public float specailAttack(Monster defendingMonster, Move attackMove, float damage)
        {
            int keepTrack = 0;
            if (attackMove.getType() == "lava")
            {
                if (defendingMonster.getType() == "plant")
                {
                    float fireTypeBonus = (float)1.75;
                    damage = typeBonus(fireTypeBonus, damage);
                    keepTrack = 1;
                    Console.Write("check lava on grass" + "\n");
                    return damage;
                }
                if (defendingMonster.getType() == "ice")
                {
                    float fireTypeBonus = (float)2;
                    damage = typeBonus(fireTypeBonus, damage);
                    keepTrack = 1;
                    Console.Write("check lava on ice" + "\n");
                    return damage;
                }
                if (defendingMonster.getType() == "rock")
                {
                    float fireTypeBonus = (float).60;
                    damage = typeBonus(fireTypeBonus, damage);
                    keepTrack = 1;
                    Console.Write("check lava on rock" + "\n");
                    return damage;
                }
                if (defendingMonster.getType() == "water")
                {
                    float fireTypeBonus = (float).5;
                    damage = typeBonus(fireTypeBonus, damage);
                    keepTrack = 1;
                    Console.Write("check lava on water" + "\n");
                    return damage;
                }
                if (defendingMonster.getType() == "lava")
                {

                    damage = 1;
                    keepTrack = 1;
                    Console.Write("check lava on lava" + "\n");
                    return damage;
                }

            }


            if (attackMove.getType() == "plant")
                Console.Write("check plant on first" + "\n");
            {
                if (defendingMonster.getType() == "rock")
                {
                    float fireTypeBonus = (float)2;
                    damage = typeBonus(fireTypeBonus, damage);
                    keepTrack = 1;
                    Console.Write("check plant on rock" + "\n");
                    return damage;
                }
                if (defendingMonster.getType() == "lava")
                {
                    Console.Write("check plant on fire " + "\n");
                    float fireTypeBonus = (float).7;
                    damage = typeBonus(fireTypeBonus, damage);
                    keepTrack = 1;
                    Console.Write("check plant on lava" + "\n");
                    return damage;
                }
                if (defendingMonster.getType() == "ice")
                {
                    float fireTypeBonus = (float).6;
                    damage = typeBonus(fireTypeBonus, damage);
                    keepTrack = 1;
                    Console.Write("check plant on ice" + "\n");
                    return damage;
                }
                if (defendingMonster.getType() == "water")
                {
                    float fireTypeBonus = (float)2;
                    damage = typeBonus(fireTypeBonus, damage);
                    keepTrack = 1;
                    Console.Write("check plant on water" + "\n");
                    return damage;
                }
                if (defendingMonster.getType() == "plant")
                {
                    Console.Write("check plant on fire " + "\n");
                    float fireTypeBonus = (float)1;
                    damage = typeBonus(fireTypeBonus, damage);
                    keepTrack = 1;
                    return damage;
                }
            }

            if (attackMove.getType() == "ice")

            {
                if (defendingMonster.getType() == "rock")
                {
                    float fireTypeBonus = (float)2;
                    damage = typeBonus(fireTypeBonus, damage);
                    keepTrack = 1;
                    Console.Write("check ice on rock" + "\n");
                    return damage;
                }
                if (defendingMonster.getType() == "lava")
                {
                    Console.Write("check plant on fire " + "\n");
                    float fireTypeBonus = (float).7;
                    damage = typeBonus(fireTypeBonus, damage);
                    keepTrack = 1;
                    Console.Write("check ice on lava" + "\n");
                    return damage;
                }
                if (defendingMonster.getType() == "ice")
                {
                    float fireTypeBonus = (float)1;
                    damage = typeBonus(fireTypeBonus, damage);
                    keepTrack = 1;
                    Console.Write("check ice on ice" + "\n");
                    return damage;
                }
                if (defendingMonster.getType() == "water")
                {
                    float fireTypeBonus = (float)1.2;
                    damage = typeBonus(fireTypeBonus, damage);
                    keepTrack = 1;
                    Console.Write("check ice on water" + "\n");
                    return damage;
                }
                if (defendingMonster.getType() == "plant")
                {
                    Console.Write("check ice on fire " + "\n");
                    float fireTypeBonus = (float)2;
                    damage = typeBonus(fireTypeBonus, damage);
                    keepTrack = 1;
                    return damage;
                }

            }



                if (attackMove.getType() == "rock")

                {
                    if (defendingMonster.getType() == "rock")
                    {
                        float fireTypeBonus = (float)2;
                        damage = typeBonus(fireTypeBonus, damage);
                        keepTrack = 1;
                        Console.Write("check rock on rock" + "\n");
                        return damage;
                    }
                    if (defendingMonster.getType() == "lava")
                    {
                        Console.Write("check plant on fire " + "\n");
                        float fireTypeBonus = (float)1.8;
                        damage = typeBonus(fireTypeBonus, damage);
                        keepTrack = 1;
                        Console.Write("check rock on lava" + "\n");
                        return damage;
                    }
                    if (defendingMonster.getType() == "ice")
                    {
                        float fireTypeBonus = (float)1;
                        damage = typeBonus(fireTypeBonus, damage);
                        keepTrack = 1;
                        Console.Write("check rock on ice" + "\n");
                        return damage;
                    }
                    if (defendingMonster.getType() == "water")
                    {
                        float fireTypeBonus = (float).5;
                        damage = typeBonus(fireTypeBonus, damage);
                        keepTrack = 1;
                        Console.Write("check rock on water" + "\n");
                        return damage;
                    }
                    if (defendingMonster.getType() == "plant")
                    {
                        Console.Write("check rock on plant " + "\n");
                        float fireTypeBonus = (float)2;
                        damage = typeBonus(fireTypeBonus, damage);
                        keepTrack = 1;
                        return damage;
                    }


                }


            if (attackMove.getType() == "light")

            {
                if (defendingMonster.getType() == "rock")
                {
                    float fireTypeBonus = (float).5;
                    damage = typeBonus(fireTypeBonus, damage);
                    keepTrack = 1;
                    Console.Write("check rock on light" + "\n");
                    return damage;
                }
                if (defendingMonster.getType() == "lava")
                {
                    Console.Write("check plant on fire " + "\n");
                    float fireTypeBonus = (float)1.8;
                    damage = typeBonus(fireTypeBonus, damage);
                    keepTrack = 1;
                    Console.Write("check light on lava" + "\n");
                    return damage;
                }
                if (defendingMonster.getType() == "ice")
                {
                    float fireTypeBonus = (float)1.8;
                    damage = typeBonus(fireTypeBonus, damage);
                    keepTrack = 1;
                    Console.Write("check light on ice" + "\n");
                    return damage;
                }
                if (defendingMonster.getType() == "water")
                {
                    float fireTypeBonus = (float)2;
                    damage = typeBonus(fireTypeBonus, damage);
                    keepTrack = 1;
                    Console.Write("check light on water" + "\n");
                    return damage;
                }
                if (defendingMonster.getType() == "plant")
                {
                    Console.Write("check light on plant " + "\n");
                    float fireTypeBonus = (float)1;
                    damage = typeBonus(fireTypeBonus, damage);
                    keepTrack = 1;
                    return damage;
                }


            }

            if (attackMove.getType() == "water")

            {
                if (defendingMonster.getType() == "rock")
                {
                    float fireTypeBonus = (float)2;
                    damage = typeBonus(fireTypeBonus, damage);
                    keepTrack = 1;
                    Console.Write("check water on rock" + "\n");
                    return damage;
                }
                if (defendingMonster.getType() == "lava")
                {
                    Console.Write("check plant on fire " + "\n");
                    float fireTypeBonus = (float)1.8;
                    damage = typeBonus(fireTypeBonus, damage);
                    keepTrack = 1;
                    Console.Write("check water on lava" + "\n");
                    return damage;
                }
                if (defendingMonster.getType() == "ice")
                {
                    float fireTypeBonus = (float)1;
                    damage = typeBonus(fireTypeBonus, damage);
                    keepTrack = 1;
                    Console.Write("check rock on ice" + "\n");
                    return damage;
                }
                if (defendingMonster.getType() == "water")
                {
                    float fireTypeBonus = (float)1;
                    damage = typeBonus(fireTypeBonus, damage);
                    keepTrack = 1;
                    Console.Write("check water on water" + "\n");
                    return damage;
                }
                if (defendingMonster.getType() == "plant")
                {
                    Console.Write("check water on plant " + "\n");
                    float fireTypeBonus = (float).5;
                    damage = typeBonus(fireTypeBonus, damage);
                    keepTrack = 1;
                    return damage;
                }


            }



            if (keepTrack == 0)
                {
                    Console.Write("something went wrong with a specail move mult" + "\n");
                    return damage;
                }
                else
                {
                    Console.Write("something else went wrong with a specail move mult" + "\n");
                    return damage;
                }
            }
                
        public List<Monster> castMove(Monster attackMonster, Move attackMove, Monster defendingMonster)
        {

            List<Monster> attackDefenderList = new List<Monster>();
            int staminaRequired = attackMove.getStamina();
            int staminaPossessed = attackMonster.getStamina();
            if (staminaRequired > staminaPossessed)
            {
                attackDefenderList.Add(attackMonster);
                attackDefenderList.Add(defendingMonster);
                Console.Write("Error Not enough Stamina"+"\n");
                return attackDefenderList;
                
            }

            float damage = 0;
            float netAttack;
            float netDefense;

                Console.Write("Move Name: " + attackMove.getName() +", Stamina required: "+attackMove.getStamina()+"\n");
                Console.Write("Attacker: " + attackMonster.getName() + ", Level: " + attackMonster.getLevel()+" Health: "+attackMonster.getHealth()+", Stamina: " + attackMonster.getStamina() + "\n");
                Console.Write("Defender: " + defendingMonster.getName() + ", Level: " + defendingMonster.getLevel()+" Health: "+defendingMonster.getHealth() + ", Stamina: "+defendingMonster.getStamina() +"\n");

            netAttack = principalAttackValue(attackMonster, attackMove);
            netDefense = principalDefenseValue(defendingMonster, attackMove);
            damage = netAttack - netDefense;

            if (attackMove.getType() != "normal")
            {
                damage = specailAttack(defendingMonster, attackMove, damage);
            }
            else
            {
               
            
            }

            // Before damage is rendered the random varible must be applied 
            //            the random effectiveness variable, it will be modeled as RE = (2 / 3 + E) + R where 2 / 3 represents 66 % 
            //effective all the time, then E = Level / 300, such that at level 100 a creature will be completely effective while
            //  a creature at 1 will be .661.Then another variable R will be created. R will be a number that is a random 
            //  number between the range of 0:X where x = 1 - (.2 / 3 + E), 
           

            int level=attackMonster.getLevel();
            float tempLevel = (float)level;
            tempLevel = tempLevel / 100;
            damage = damage * tempLevel;
            int roundedDamage = (int)damage;
            defendingMonster.renderDamage(roundedDamage,attackMonster, defendingMonster,attackMove);      
                attackDefenderList.Add(attackMonster);
                attackDefenderList.Add(defendingMonster);

            return attackDefenderList;

        }
    
        public void iterator(Roster playerOneRoster, Roster playerTwoRoster)
        {

            for(int i = 0; i < playerOneRoster.count(); i++)
            {
                if (playerOneRoster.returnMonsterAt(i).currentlyLiving() == true)
                {
                    for(int a = 0; a < playerTwoRoster.count(); a++)
                    {
                        if (playerTwoRoster.returnMonsterAt(a).currentlyLiving() == true)
                        {
                            if (playerOneRoster.returnMonsterAt(i).getSpeed() > playerTwoRoster.returnMonsterAt(a).getSpeed())
                            {
                                fightTwo(playerOneRoster.returnMonsterAt(i), playerTwoRoster.returnMonsterAt(a));

                            }
                            else
                            {
                                fightTwo(playerTwoRoster.returnMonsterAt(a), playerOneRoster.returnMonsterAt(i));
                            }
                        }
                        else
                        {
                            Console.Write("Player Loses");
                        }
                    }
                }
            }
        }
  

        public void battleManager(Roster feedPlayerOne, Roster feedPlayerTwo, List<Monster> monsterDataBase)
        {
            Console.Write("Player One" + "\n");
            playerOneRoster = Build.buildRosterFromConsole(monsterDataBase);
            Console.Write("Player Two" + "\n");
            playerTwoRoster = Build.buildRosterFromConsole(monsterDataBase);

         
            iterator(playerOneRoster, playerTwoRoster);
            Console.ReadLine();




        }

        public void fightTwo(Monster attackMonster, Monster defendingMonster)
        {
            Console.Write("\n");
            Console.Write("Attacker: " + attackMonster.getName() + ", Level: " + attackMonster.getLevel() + " Health: " + attackMonster.getHealth() + ", Stamina: " + attackMonster.getStamina()+", Type: "+attackMonster.getType() + "\n");
            Console.Write("Defender: " + defendingMonster.getName() + ", Level: " + defendingMonster.getLevel() + " Health: " + defendingMonster.getHealth() + ", Stamina: " + defendingMonster.getStamina()+ ", Type: "+defendingMonster.getType() + "\n");

            Move toBecastMove = getMoveFromConsole(attackMonster.getMoveList(),attackMonster);

            castMove(attackMonster, toBecastMove, defendingMonster);
            if (defendingMonster.currentlyLiving() == true)
            {

                fightTwo(defendingMonster, attackMonster);
                
            }
            else
            {
                Console.Write("Monster has died" + "\n");

            }

        }
        public void printHealth(Monster attacker, Monster defender)
        {
            Console.Write(attacker.getName() + " health = " + attacker.getHealth() + "\n");
            Console.Write(defender.getName() + " health = " + defender.getHealth() + "\n");
            Console.Write("\n");

        }
    } 
}

    


