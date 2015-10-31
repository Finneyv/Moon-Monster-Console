﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoonMonsterConsole
{
    public class monster
    {

        // The first variable is a test
        int firstInt = 0;
        // the first set of variables are the ones that will change
        int size = 0;
        int id = 0;
        int health = 0;
        int stamina = 0;
        int level = 0;
        // the second list is variables that will remain constant unless an evolution/item is used. 
        int speed = 0;
        int agility = 0;
        int strength = 0;
        Boolean isAlive = true;
        Boolean hasStamina = true;

        // this will be a list of moves that are available to the creature
        List<Move> moveList = new List<Move>();


       // here I am attempting to intialize the monster and give it a test value, i then expect this function to assign the value and print firstInt
        public monster(int firstid, int fhealth, int fstamina, int flevel, int fspeed, int fagility, int fstrength,int sizet, List<Move> fmoveList)
        {
            id = firstid;
            health = fhealth;
            stamina = fstamina;
            level = flevel;
            speed = fspeed;
            agility = fagility;
            strength = fstrength;
            moveList = fmoveList;
            size = sizet;

        }
        public monster(int firstid, int flevel)
        {
            //this function will generate monsters based on the parameters given
            int maxhealth;
            id = firstid;
            level = flevel;
            //health = maxhealth;
        }

        public void renderDamage(int damage)
        {
            health = health - damage;
            if (health < 1)
            {
                isAlive = false;
            }
        }

        public void useStamina(int staminaUsed)
        {
            stamina = stamina - staminaUsed;
            if(stamina < 1)
            {
                hasStamina = false;
            }
        }
        public int getSpeed()
        {
            return this.speed;
        }
        public Boolean currentlyLiving()
        {
            return isAlive;
        }

        public Boolean canStrike(int staminaRequired)
        {
            if(staminaRequired <= stamina)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void print()
        {
            Console.Write("first int= "+firstInt);
        }

        public int gethealth()
        {
            return health;
        }
        
        public int getSize()
        {
            return this.size;
        }
        public int getId()
        {
            return id;
        }

        public int getstamina()
        {
            return stamina;
        }

        public int getlevel()
        {
            return level;
        }

        public int getagility()
        {
            return agility;
        }

        public int getstrength()
        {
            return strength;
        }

        public List<Move> getmoveList()
        {
            return moveList;
        }
	}
}
