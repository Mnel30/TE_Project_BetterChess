using System;
using UnityEngine;


public class Card 
{
    public int id;
    public string type;
    public string name;
    public int level ;
    public int cost ;
    public string description ;
    public int attack ;
    public int defense ;

    public Card(){

    }




    public Card(int Id, string Type, string Name, int Level, int Cost, string Description, int Attack, int Defense)
{
    id = Id;
    type = Type;
    name = Name;
    level = Level;
    cost = Cost;
    attack = Attack;
    defense = Defense;

    // If type is "M", format the description
    if (type == "M")
    {
        this.description = $"{Description}\nAttack: {attack}\nDefense: {defense}";
    }
    else
    {
        this.description = Description; // Keep original description for non-monster cards
    }
}

}
