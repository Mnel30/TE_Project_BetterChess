using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public int health = 100;
    public int mana = 50; // Start with 5 mana

    public Text healthText;
    public Text manaText;

    private Color manaColor;
    private Color healthColor;

    void Update()
    {
        healthText.text = "Health: " + health;
        manaText.text = "Mana: " + mana;

        manaColor = manaText.color ;
        healthColor = healthText.color;
    }

    public void UseMana(int cost)
    {
        if (mana >= cost)
        {
            mana -= cost;

            manaText.color = Color.red;
            Invoke("RestoreOriginalColorMana", 0.5f);
            
        }
    }

    public void GainMana(int amount)
    {
        mana += amount;

        healthText.color = Color.red;
        Invoke("RestoreOriginalColorHealth", 0.5f);
        
    }

    void RestoreOriginalColorMana(){
        manaText.color = manaColor;
    }

    void RestoreOriginalColorHealth(){
        healthText.color = healthColor;    
    }
}

