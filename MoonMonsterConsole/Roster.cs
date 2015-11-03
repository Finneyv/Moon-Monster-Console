using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoonMonsterConsole
{
    class Roster
    {
        List<Monster> monsterRoster = new List<Monster>();

        public int getSize()
        {
            return monsterRoster.Count();
        }

        public Roster(List<Monster> fmonsterRoster)
        {
            monsterRoster = fmonsterRoster;
        }
        public int count()
        {
            return monsterRoster.Count();

        }

        public Monster returnMonsterAt(int index)
        {
            Monster toBeReturned = monsterRoster.ElementAt(index);
            //monsterRoster.ElementAt(index).getmoveList().ElementAt(0).getMaxDamage();
            return toBeReturned;
        }
        public int testMaxdamageSpecailCase(int index)
        {
            int damage=monsterRoster.ElementAt(index).getmoveList().ElementAt(0).getMaxDamage();
            return damage;
        }
        public void addMonster(Monster newMonster)
        {
            monsterRoster.Add(newMonster);
        }

        public int getIndex(Monster currentMonster)
        {
            int index = monsterRoster.IndexOf(currentMonster);
            return index;
        }

        public void updateRoster(int startingIndex, int finalIndex)
        {
            Monster item = monsterRoster[startingIndex];
            monsterRoster.Remove(item);
            monsterRoster.Insert(finalIndex, item);
        }
        
        public void removeMonster(Monster unwantedMonster)
        {
            monsterRoster.Remove(unwantedMonster);
        }
    }
}
