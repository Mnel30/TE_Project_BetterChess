using System;
using System.Collections.Generic;
using UnityEngine;

        //TODO : add champions

public class CardDatabase : MonoBehaviour {
    public static List<Card> cardlist = new List<Card>();

    void Awake()
    {
        cardlist.Add(new (0,"M","iron guard",1,5,"",2,6));
        cardlist.Add(new (1,"M","stone warden",2,10,"",2,12));
        cardlist.Add(new (2,"M","diamond turtle",3,10,"",0,25));
        cardlist.Add(new (3,"M","lord the mirror realm",5,1,"",0,40));
        cardlist.Add(new (4,"M","raging bear",1,5,"",4,4));
        cardlist.Add(new (5,"M","fire wolf",2,10,"",8,2));
        cardlist.Add(new (6,"M","striking hawk",3,10,"",15,0));
        cardlist.Add(new (7,"M","berserker",4,15,"",10,10));
        cardlist.Add(new (8,"M","kamikaze",5,5,"",0,100));
        cardlist.Add(new (0,"M","iron guard",1,5,"",2,6));
        cardlist.Add(new (1,"M","stone warden",2,10,"",2,12));
        cardlist.Add(new (2,"M","diamond turtle",3,10,"",0,25));
        cardlist.Add(new (3,"M","lord the mirror realm",5,1,"",0,40));
        cardlist.Add(new (4,"M","raging bear",1,5,"",4,4));
        cardlist.Add(new (5,"M","fire wolf",2,10,"",8,2));
        cardlist.Add(new (6,"M","striking hawk",3,10,"",15,0));
        cardlist.Add(new (7,"M","berserker",4,15,"",10,10));
        cardlist.Add(new (8,"M","kamikaze",5,5,"",0,100));
        cardlist.Add(new (9,"S","fire wolf",2,10,"+3 attack",3,0));
        cardlist.Add(new (10,"S","meteor strike",2,10,"+5 attack",5,0));
        cardlist.Add(new (11,"S","snake bit",2,10,"+8 attack",8,0));
        cardlist.Add(new (12,"S","morale",1,5,"+3 defense",0,3));
        cardlist.Add(new (13,"S","cleansing breath",2,5,"+5 defense",0,5));
        cardlist.Add(new (14,"S","second wind ",2,10,"+5 attack +5 defense",5,5));
        cardlist.Add(new (15,"S","war cry",2,5,"+15 attack -5 attack",15,-5));
        cardlist.Add(new (16,"S","hold the line",2,5,"+15 defense -10 attack",-10,15));
        cardlist.Add(new (17,"S","zeal",3,10,"+10 attack +10 defense",10,10));
        cardlist.Add(new (18,"S","pheonix blood",4,15,"target beast will be revived if killed",0,0));
        cardlist.Add(new (19,"S","analysis paralysis",4,10,"target can't move for 1 turn",0,0));
        cardlist.Add(new (20,"S","wisdom of the sage",4,10,"target can attack two times",0,0));
        cardlist.Add(new (21,"S","unfetered",4,10,"target will ignore first attack",0,0));
        cardlist.Add(new (22,"S","stealth",2,10,"target can directly attack enemy bypassing beasts",0,0));
    }
}