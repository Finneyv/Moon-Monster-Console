using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoonMonsterConsole
{
    class Roster
    {
        List<monster> monsterRoster = new List<monster>();


        public Roster(List<monster> fmonsterRoster)
        {
            monsterRoster = fmonsterRoster;
        }
        public int count()
        {
            return monsterRoster.Count();

        }

        public monster returnMonsterAt(int index)
        {
            monster toBeReturned = monsterRoster.ElementAt(index);
            //monsterRoster.ElementAt(index).getmoveList().ElementAt(0).getMaxDamage();
            return toBeReturned;
        }
        public int testMaxdamageSpecailCase(int index)
        {
            int damage=monsterRoster.ElementAt(index).getmoveList().ElementAt(0).getMaxDamage();
            return damage;
        }
        public void addMonster(monster newMonster)
        {
            monsterRoster.Add(newMonster);
        }

        public int getIndex(monster currentMonster)
        {
            int index = monsterRoster.IndexOf(currentMonster);
            return index;
        }

        public void updateRoster(int startingIndex, int finalIndex)
        {
            monster item = monsterRoster[startingIndex];
            monsterRoster.Remove(item);
            monsterRoster.Insert(finalIndex, item);
        }
        
        public void removeMonster(monster unwantedMonster)
        {
            monsterRoster.Remove(unwantedMonster);
        }
    }
}
