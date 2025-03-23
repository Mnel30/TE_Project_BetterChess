using UnityEngine;
using UnityEngine.EventSystems;

public class SacrificeZone : MonoBehaviour, IDropHandler
{
    public PlayerStats player;
    public Hand hand;

    public void OnDrop(PointerEventData eventData)
    {
        //TODO : reduce player hand count if card is destoryed
        if (eventData.pointerDrag != null)
        {
            DraggableCard draggedCard = eventData.pointerDrag.GetComponent<DraggableCard>();
            if (draggedCard != null)
            {
                // Increase player's mana by the card's cost
                DisplayCard card = draggedCard.GetComponent<DisplayCard>();  // Assuming the card has a Card script
                if (card != null)
                {
                    player.GetComponent<PlayerStats>().GainMana(card.cost) ;
                }

                // Optionally, you can destroy the card after sacrifice:
                hand.RemoveCard(card.id);
                Destroy(draggedCard.gameObject);  // Destroy card after sacrificing
            }
        }
    }
}
