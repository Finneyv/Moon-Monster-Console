using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoonMonsterConsole
{

    class test
    {

        List<Move> moveList = new List<Move>();
        public void buildmoves()
        {
            /*magic bite 
            max damage = 700
            max defense = 200
            size = 35
            strength = 40
            speed = 25
            type = normal
            dsize = 60
            dstrength = 25
            dspeed = 15
            fire = 0;
            ice = 0
            plant = 0
            water = 0
            rock = 0
            lightning = 0
            moveid=1
            stamina=45
               */
            Move bite = new Move(1, 45, "normal", 700, 200, 35, 25, 60, 15, 0, 0, 0,0,0,0);
            moveList.Add(bite);

            /*
            Dragon Shep
            id=2
            type=fire
            health=815
            size=80
            strength=80
            speed=85
            agility=50
            fire=85
            ice=0
            plant=0
            rock=0
            lighting=0
            stamina=100
            level=56
           
            */
            monster dragonShep = new monster(2, 815, 100, 56, 85, 50, 80, moveList);
        }

    }
}
