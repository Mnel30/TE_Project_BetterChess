using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class DisplayCard : MonoBehaviour
{
    public List<Card> displayCard = new();
    public int displayId;

    public int id;
    public string type;
    public string naame;
    public int level;
    public int cost;
    public string description;

    public int attack;
    public int defense;

    public Text typetext;
    public Text nametext;
    public Text leveltext;
    public Text costtext;
    public Text descriptiontext;

    public bool CardBack;
    public static bool staticCardBack;
    void Start()
    {
        displayCard.Add(CardDatabase.cardlist[displayId]); // Initialize the list
        UpdateCardUI();
        staticCardBack = CardBack;
    }

    void UpdateCardUI()
    {
        id = displayCard[0].id;
        type = displayCard[0].type;
        naame = displayCard[0].name;
        level = displayCard[0].level;
        cost = displayCard[0].cost; // Now correctly references cost
        description = displayCard[0].description;
        attack = displayCard[0].attack;
        defense = displayCard[0].defense;

        typetext.text = type;
        nametext.text = naame;
        leveltext.text = level.ToString();
        costtext.text = cost.ToString(); // Ensure cost is displayed
        descriptiontext.text = description;
    }
}
