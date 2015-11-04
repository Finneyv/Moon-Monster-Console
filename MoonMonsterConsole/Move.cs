﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoonMonsterConsole
{
    public class Move
    {
        //global attributes all moves have
        int moveId;
        int staminaReq;
        string type;
        int maxDamage;
        int maxDefense;
        int asize;
        int aspeed;
        int dsize;
        int dspeed;
        int fire;
        int ice;
        int plant;
        int water;
        int rock;
        int lightning;

        //initializing Move as an object f stands for first
        public Move(int fmoveId, int fstaminaReq, string ftype, int fmaxDamage, int fmaxDefense, int fasize, int faspeed, int fdsize, int fdspeed, int ffire, int fice, int fplant, int fwater, int frock, int flightning)
        {
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
            plant = fplant;
            water = fwater;
            rock = frock;
            lightning = flightning;
        }
        
    }
}
