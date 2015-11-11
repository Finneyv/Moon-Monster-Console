using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoonMonsterConsole
{
	public class Monster
	{

		// The first variable is a test
		public int firstInt = 0;
		 // the first set of variables are the ones that will change
		public int size = 0;
		public int id = 0;
		public int health = 0;
		public int stamina = 0;
		public int level = 0;
		 // the second list is variables that will remain constant unless an evolution/item is used. 
		public int speed = 0;
		public int agility = 0;
		public int strength = 0;
		public Boolean isAlive = true;
		public Boolean hasStamina = true;
		public string name;
		 //list of types
		public string type = "0";

		// this will be a list of moves that are available to the creature

		List<Move> moveList = new List<Move>();

	   // here I am attempting to intialize the Monster and give it a test value, i then expect this function to assign the value and print firstInt
		public Monster(string nameT,int firstid, int fhealth, int fstamina, int flevel, int fspeed, int fagility, int fstrength,int sizet, List<Move> fmoveList,string mtype)
		{
			id = firstid;
			health = fhealth;
			stamina = fstamina;
			level = flevel;
			speed = fspeed;
			agility = fagility;
			strength = fstrength;
            moveList = fmoveList;
            type = mtype;
            List<Move> tempMoves= new List<Move>();


            for (int d = 0; d < moveList.Count(); d++)
            {
                if (level >= moveList.ElementAt(d).levelReq)
                {
                    //    Console.Write("loop + movelist.Count "+moveList.Count() + "\n");
                    if (type == moveList.ElementAt(d).getType())
                    {
                        // Console.Write("type"+"\n");
                        tempMoves.Add(moveList.ElementAt(d));
                    }
                    if (moveList.ElementAt(d).getType() == "normal")
                    {
                        //   Console.Write("noraml" + "\n");
                        tempMoves.Add(moveList.ElementAt(d));
                    }
                }
            }

            moveList = tempMoves;
            size = sizet;
			
			name = nameT;
			calculateMonster();
		}
        public Monster()
        {

        }
        public void changeSpeedTo(int newSpeed) {
            speed = newSpeed;
        }

		public string getName()
		{
			return name;
		}
		public Monster(int firstid, int flevel)
		{
			//this function will generate monsters based on the parameters given
			int maxhealth;
			id = firstid;
			level = flevel;
			//health = maxhealth;
		}
		public void calculateMonster()  {
			List<Move> moveListMonster = new List<Move>();
			float tempHealth;
			float tempLevel=(float) level;
			tempLevel = tempLevel / 100;

			tempHealth = health * tempLevel;
			health = Convert.ToInt32(tempHealth);
	   
		}
		public string getType()
		{
			return type;
		}
		public void renderDamage(int damage, Monster attackMonster, Monster defendingMonster, Move attackMove)
		{
           
			health = health - damage;
			if (health < 1)
			{
				isAlive = false;
			}
			if (defendingMonster.currentlyLiving() == false)
			{
				Console.Write(defendingMonster.getName() + " is dead" + "\n");
			}
		  
			useStamina(attackMove.getStamina(),attackMonster);
		}

		public void useStamina(int staminaUsed,Monster attackingMonster)
		{
			stamina = attackingMonster.stamina - staminaUsed;
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

		public int getHealth()
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

		public int getStamina()
		{
			return stamina;
		}

		public int getLevel()
		{
			return level;
		}

		public int getAgility()
		{
			return agility;
		}

		public int getStrength()
		{
			return strength;
		}

		public List<Move> getMoveList()
		{
			return moveList;
		}
	}
}
