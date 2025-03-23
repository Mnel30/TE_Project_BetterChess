using Unity.VisualScripting;
using UnityEngine;

public class CardBack : MonoBehaviour
{
    public GameObject cardBack;

    void Update(){
        if(DisplayCard.staticCardBack == true ){
            cardBack.SetActive(true);
        }else {
            cardBack.SetActive(false);
        }
    }
}
