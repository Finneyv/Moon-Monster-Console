using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoonMonsterConsole
{
    public class Move
    {
        //global attributes all moves have
        public int moveId;
        public int staminaReq;
        public string type;
        public int maxDamage;
        public int maxDefense;
        public int asize;
        public int aspeed;
        public int dsize;
        public int dspeed;
        public int fire;
        public int ice;
        public int plant;
        public int water;
        public int rock;
        public int lightning;
        public int dstrength;
        public int astrength;
        public string name;
        public int levelReq;
        //initializing Move as an object f stands for first
        public Move(string tname,int fmoveId, int fstaminaReq, string ftype, int fmaxDamage, int fmaxDefense, int fasize, int faspeed, int fdsize, int fdspeed,int taStrength, int tdStrength, int ffire, int fice, int fplant, int fwater, int frock, int flightning, int levReq)
        {
            dstrength = tdStrength;
            astrength = taStrength;
            moveId = fmoveId;
            staminaReq = fstaminaReq;
            type = ftype;
            maxDamage = fmaxDamage;
            maxDefense = fmaxDefense;
            asize = fasize;
            aspeed = faspeed;
            dsize = fdsize;
            dspeed = fdspeed;
            fire = ffire;
            ice = fice;
            name = tname;
            plant = fplant;
            water = fwater;
            rock = frock;
            lightning = flightning;
            levelReq = levReq;
        }
        public Move()
        {

        }
        public int getFire()
        {
            return fire;
        }
        public int getDStrength()
        {
            return dstrength;
        }
        public int getDSize()
        {
            return dsize;
        }
        public int getDSpeed()
        {
            return dspeed;
        }
        public int getMaxDefense()
        {
            return maxDefense;
        }
        public int getMaxDamage()
        {
            return maxDamage;
        }
        public int getSpeed()
        {
            return this.aspeed;
        }
        public int getStrength()
        {
            return this.astrength;
        }
        public int getSizeAttacker()
        {
            return this.asize;
        }
        public int getStamina()
        {
            return staminaReq;
        }
        public string getName()
        {
            return name;
        }
        public string getType()
        {
            return type;
        }
        public int getId()
        {
            return moveId;
        }
        public int getLevelReq()
        {
            return levelReq;
        }
    }
}
