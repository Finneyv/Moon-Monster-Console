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
        List<monster> monsterDataBase;
        public BattleGround(Roster playerOneTemp, Roster playerTwoTemp, List<monster> monsterDataBaseFeed)
        {
            playerOneRoster = playerOneTemp;
            playerTwoRoster = playerTwoTemp;
            monsterDataBase = monsterDataBaseFeed;
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

        public Move getMoveFromConsole(List<Move> moveList)
        {
            Console.Write("     Please pick a move" + "\n");
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

        public float specailAttack(monster defendingMonster, Move attackMove, float damage)
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
        public List<monster> castMove(monster attackMonster, Move attackMove, monster defendingMonster)
        {

            List<monster> attackDefenderList = new List<monster>();
            int staminaRequired = attackMove.getStamina();
            int staminaPossessed = attackMonster.getstamina();
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
                Console.Write("Attacker: " + attackMonster.getName() + ", Level: " + attackMonster.getlevel()+", Stamina: " + attackMonster.getstamina() + "\n");
                Console.Write("Defender: " + defendingMonster.getName() + ", Level: " + defendingMonster.getlevel() + ", Stamina: "+defendingMonster.getstamina() +"\n");

            netAttack = principalAttackValue(attackMonster, attackMove);
            netDefense = principalDefenseValue(defendingMonster, attackMove);
            damage = netAttack - netDefense;

            if (attackMove.getType() == "normal")
            {
                Console.Write("check Normal " + "\n");
            }
            else
            {
                damage = specailAttack(defendingMonster, attackMove, damage);
            }

            // Before damage is rendered the random varible must be applied 
            //            the random effectiveness variable, it will be modeled as RE = (2 / 3 + E) + R where 2 / 3 represents 66 % 
            //effective all the time, then E = Level / 300, such that at level 100 a creature will be completely effective while
            //  a creature at 1 will be .661.Then another variable R will be created. R will be a number that is a random 
            //  number between the range of 0:X where x = 1 - (.2 / 3 + E), 

            int roundedDamage = (int)damage;
                Console.Write("rounded damage " + roundedDamage + "\n");
                Console.Write("health of defender before " + defendingMonster.gethealth() + "\n");

            defendingMonster.renderDamage(roundedDamage,attackMonster, defendingMonster,attackMove);
          //  attackMonster.useStamina(attackMove.getStamina());

           
                attackDefenderList.Add(attackMonster);
                attackDefenderList.Add(defendingMonster);

            return attackDefenderList;

        }
    
        public void iterator(Roster playerOneRoster, Roster playerTwoRoster)
        {
            for (int a = 0; a < playerOneRoster.count(); a++)
            {
                if (playerOneRoster.returnMonsterAt(a).currentlyLiving() == true)
                {
                    
                    for(int b = 0; b < playerTwoRoster.count(); b++)
                    {
                        if (playerTwoRoster.returnMonsterAt(b).currentlyLiving() == true)
                        {
                            Move moveCast = getMoveFromConsole(playerOneRoster.returnMonsterAt(a).getmoveList());
                            castMove(playerOneRoster.returnMonsterAt(a), moveCast, playerTwoRoster.returnMonsterAt(b));
                            iterator(playerTwoRoster, playerOneRoster);
                        }
                        else
                        {
                            Console.Write("player 2s " + playerTwoRoster.returnMonsterAt(b).getName() + " is dead "+"\n");
                        }
                    }           

                }
                else
                {
                    //
                    Console.Write("Player 1's: " +playerOneRoster.returnMonsterAt(a) + " is Dead");
                }
            }
        }

        public Roster buildRosterFromConsole()
        {

            List<monster> monsterList = new List<monster>();
            Roster playerOneRoster = new Roster(monsterList);
            Console.Write("How many Monsters does this roster need? (input an Integar)" + "\n");
            String p1NumberOfMonsterS = Console.ReadLine();
  
            int p1numMon = Convert.ToInt32(p1NumberOfMonsterS);
            for (int i = 0; i < p1numMon; i++)
            {
                Console.Write("Pick the Id of your first monster" + "\n");
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
                Console.Write("Player" + "\n");
                    //Monster at:" + +i + " is called = " + playerOneRoster.returnMonsterAt(i).getName() + "\n");

                for (int b = 0; b < playerOneRoster.returnMonsterAt(i).getmoveList().Count; b++)
                {
                    Console.Write(playerOneRoster.returnMonsterAt(i).getName() + " move number " + b + " is named " + playerOneRoster.returnMonsterAt(i).getmoveList().ElementAt(b).getName() + "\n");
                }
            }
            Console.ReadLine();
            return playerOneRoster;
        }

        public void battleManager(Roster feedPlayerOne, Roster feedPlayerTwo,List<monster> monsterDataBase)
        {
            playerOneRoster = buildRosterFromConsole(); 
            playerTwoRoster = buildRosterFromConsole();


            /*    for (int i = 0; i < playerOneRoster.count(); i++){
                    Console.Write("Player 1 Monster at ="+i+" is called ="+playerOneRoster.returnMonsterAt(i).getName()+"\n");
                    for (int b = 0; b< playerOneRoster.returnMonsterAt(i).getmoveList().Count; b++)
                    {
                        Console.Write(playerOneRoster.returnMonsterAt(i).getName() + " move number " + b+1 + " is named " + playerOneRoster.returnMonsterAt(i).getmoveList().ElementAt(b).getName()+"\n");
                    }
                }
                for (int i = 0; i < playerTwoRoster.count(); i++)
                {
                    Console.Write("Player 2 Monster at =" + i + " is called =" + playerTwoRoster.returnMonsterAt(i).getName() + "\n");
                    for (int b = 0; b < playerTwoRoster.returnMonsterAt(i).getmoveList().Count; b++)
                    {
                        Console.Write(playerTwoRoster.returnMonsterAt(i).getName() + " move number " + b+1 + " is named " + playerTwoRoster.returnMonsterAt(i).getmoveList().ElementAt(b).getName() + "\n");
                    }

                }
                */
            if (playerOneRoster.returnMonsterAt(0).getSpeed()> playerTwoRoster.returnMonsterAt(0).getSpeed())
            {
                Console.Write("Player 1 moves first, please enter the int of the move you wish to cast");
                fightTwo(playerOneRoster.returnMonsterAt(0), playerTwoRoster.returnMonsterAt(0));

            }
            else
            {
                Console.Write("Player 2 moves first, please enter the int of the move you wish to cast"+"\n");
                fightTwo(playerTwoRoster.returnMonsterAt(0), playerOneRoster.returnMonsterAt(0));




            }

               


              
          



        }

        public void fightTwo(monster attackMonster, monster defendingMonster)
        {
            Move toBecastMove = getMoveFromConsole(attackMonster.getmoveList());
            castMove(attackMonster, toBecastMove, defendingMonster);
            if (defendingMonster.currentlyLiving() == true)
            {
                fightTwo(defendingMonster, attackMonster);
                Console.Write("other player's turn " + "\n");
            }
            else
            {
                Console.Write("monster has died" + "\n");
            }

        }
        public void printHealth(monster attacker, monster defender)
        {
            Console.Write(attacker.getName() + " health = " + attacker.gethealth() + "\n");
            Console.Write(defender.getName() + " health = " + defender.gethealth() + "\n");
            Console.Write("\n");

        }
    }
}

    


