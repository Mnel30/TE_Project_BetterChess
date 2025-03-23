using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public List<Card> handCards = new List<Card>(); // Cards currently in hand
    public Transform handPanel; // Reference to the UI panel where cards will be displayed
    public GameObject cardPrefab; // Prefab for displaying the card in the UI

    // Draws a card from the deck if hand has less than 5 cards
    public bool DrawCard(PlayerDeck deck)
{
    if (handCards.Count < 5)
    {
        Card drawnCard = deck.DrawCard();
        if (drawnCard != null)
        {
            handCards.Add(drawnCard);
            DisplayCardInHand(drawnCard);
            return true;
        }
    }
    return false;
}

    //removes the removed card
    public void RemoveCard(int id){
        handCards.RemoveAll(item => item.id == id);
    }
    // Displays the drawn card in the handPanel
    private void DisplayCardInHand(Card card)
    {
        GameObject newCard = Instantiate(cardPrefab, handPanel);
        DisplayCard displayCard = newCard.GetComponent<DisplayCard>();

        if (displayCard != null)
        {
            displayCard.displayId = card.id;
        }
    }
}
