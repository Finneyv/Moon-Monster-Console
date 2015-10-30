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
            fmonsterRoster = monsterRoster;
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
