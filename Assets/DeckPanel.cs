using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DeckPanel : MonoBehaviour, IPointerClickHandler
{

    public PlayerDeck playerDeck;
    public Hand playerHand;
    public Text remainingCardsText ;

    public PlayerStats player ;
    void Start()
    {
        remainingCardsText.text = "Cards : "+playerDeck.deck.Count;
    }

    void Update()
    {
        remainingCardsText.text = "Cards : "+playerDeck.deck.Count;
    }

    // Called when the deck panel is clicked
    public void OnPointerClick(PointerEventData eventData)
    {
        
        if(playerHand.DrawCard(playerDeck)){
            player.GetComponent<PlayerStats>().UseMana(5) ;
        }
    }
}
