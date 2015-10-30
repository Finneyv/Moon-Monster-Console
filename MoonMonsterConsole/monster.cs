using System;
using System.Collections.Generic;

public class monster
{

    // The first variable is a test
    int firstInt = 0;
    // the first set of variables are the ones that will change
    int id = 0;
    int health = 0;
    int stamina = 0;
    int level = 0;
    // the second list is variables that will remain constant unless an evolution/item is used. 
    int speed = 0;
    int agility = 0;
    int strenght = 0;

    // this will be a list of moves that are available to the creature
    List<int> moveList = new List<int>();


    // here I am attempting to intialize the monster and give it a test value, i then expect this function to assign the value and print firstInt
    public monster(int start)
    {
        firstInt = start;
        print();

    }
    
    
	void print()
    {
        Console.Write("first int= "+firstInt);
    }
	
}
