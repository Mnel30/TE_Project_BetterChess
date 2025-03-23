using System.Collections.Generic;
using UnityEngine;

public class PlayerDeck : MonoBehaviour
{
    public List<Card> deck = new();
    public int x;

    void Start()
    {
        GenerateDeck();
    }

    // Fills the deck with 40 random cards from the database
    public void GenerateDeck()
    {
        deck.Clear(); // Clear the deck before refilling

        for (int i = 0; i < 40; i++)
        {
            x = Random.Range(0, CardDatabase.cardlist.Count); // Get a random card
            deck.Add(CardDatabase.cardlist[x]); // Add to deck
        }
    }

    // Call this when drawing a card
    public Card DrawCard()
    {
        if (deck.Count == 0)
        {
            Debug.Log("Deck is empty!");
        }

        if (deck.Count > 0)
        {
            Card drawnCard = deck[0]; // Take the top card
            deck.RemoveAt(0); // Remove it from deck
            return drawnCard;
        }
        return null; // In case something goes wrong
    }
}



