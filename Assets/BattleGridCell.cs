using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class BattleGrid : MonoBehaviour, IDropHandler , IPointerClickHandler
{
    public GameObject player;
    public Hand hand; 
    public int attack;
    public int defense; 

    public bool canDrop = true;
    public bool attackOrder=false;
    public bool defenseOrder =false;

    public bool hasCard = false;
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null && canDrop)
        {
            DraggableCard draggedCard = eventData.pointerDrag.GetComponent<DraggableCard>();
            if (draggedCard != null)
            
            {
                // Reduce player's mana by the card's cost
                DisplayCard card = draggedCard.GetComponent<DisplayCard>(); // Assuming the card has a Card script
                if (card != null && player.GetComponent<PlayerStats>().mana >= card.cost)
                {
                    if(card.type == "M" && !hasCard){
                        //lose mana
                        player.GetComponent<PlayerStats>().UseMana(card.cost) ;
                        //cell is full
                        hasCard = true;
                        //transform card parent
                        draggedCard.originalParent = this.transform;
                        //reduce player hand deck count if card is dropped here
                        hand.RemoveCard(card.id); 
                        //update cell ability :
                        attack = card.attack ;
                        defense = card.defense;
                    } else if(hasCard) {
                        // lose mana
                        player.GetComponent<PlayerStats>().UseMana(card.cost) ;
                        // get monster stat boost
                        attack += card.attack;
                        defense += card.defense ;
                        //destory card 
                        hand.RemoveCard(card.id);
                        Destroy(draggedCard.gameObject);
                    }
                    
                }
                else
                {
                    Debug.Log("Not enough mana to deploy card or cell already has card.");
                }

                // Optionally, you can deploy the card here, for example, add it to the BattleGrid:
                //draggedCard.transform.SetParent(this.transform);  // Add the card to the BattleGrid
                //draggedCard.transform.localPosition = Vector3.zero;  // Reset position
            }
        }
    }
    public void OnPointerClick(PointerEventData eventData){
        Debug.Log("has been clicked");
    }
}
