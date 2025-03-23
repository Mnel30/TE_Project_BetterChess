using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using UnityEditor.PackageManager;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerStats Player1;
    public PlayerStats Player2;

    public TMP_Text playerturn;

    public DeckPanel deck;

    public SacrificeZone sacrificeZone;
    public Transform Grid;
    public Transform handPanel;

    public List<BattleGrid> player1cells = new();
    public List<BattleGrid> player2cells = new();

    public bool player1Trun = true;
    void Start()
    {
        //establish each player's battleCells
        Transform[] rows = new Transform[Grid.childCount];
        for (int i = 0; i < Grid.childCount; i++)
        {
            rows[i] = Grid.GetChild(i);
        }

        for (int i = 0; i < 2; i++)
        {
            Transform row = rows[i];
            BattleGrid[] rowCells = row.GetComponentsInChildren<BattleGrid>();
            player1cells.AddRange(rowCells); 
        }

        for (int i = 2; i < 4; i++) 
        {
            Transform row = rows[i];
            BattleGrid[] rowCells = row.GetComponentsInChildren<BattleGrid>();
            player2cells.AddRange(rowCells); 
        }

        playerturn.text = "Player 1 turn";
        //start game
        StartTurn();

    }

    public void StartTurn(){
        //initialize deck and game state 
        deck.playerDeck.GenerateDeck();
        foreach (Transform child in handPanel)
        {
            Destroy(child.gameObject);  
        }
        deck.playerHand.handCards.Clear();
        //start gameFlow
        if(player1Trun){
            playerturn.text = "Player 1 turn";
            deck.player = Player1 ;
            sacrificeZone.player = Player1;
            resolveCombat();
            player1Trun = false;
            StartPlayer1Turn();
        }else {
            deck.player = Player2 ;
            sacrificeZone.player = Player2;
            playerturn.text = "Player 2 turn";
            player1Trun = true;
            StartPlayer2Turn();
        }
    }

    void StartPlayer1Turn(){
        //disable other player cells
        for(int i=0; i<player2cells.Count; i++){
            player2cells[i].canDrop = false;
        }

        //enable current playercells 
        for(int i=0; i<player1cells.Count; i++){
            player1cells[i].canDrop = true;
        }
    }


    void StartPlayer2Turn(){
        //disable other player cells
        for(int i=0; i<player1cells.Count; i++){
            player1cells[i].canDrop = false;
        }

        //enable current playercells 
        for(int i=0; i<player2cells.Count; i++){
            player2cells[i].canDrop = true;
        }
    }



    void resolveCombat(){
        bool hasmonster = false;
        for(int i=0; i<player1cells.Count; i++){
            hasmonster = false;
            if(player1cells[i].hasCard){
                for(int j=0; j<player2cells.Count; j++){
                    if(player2cells[j].hasCard){
                        hasmonster = true;
                        if(player1cells[i].attack > player2cells[j].defense){
                            Destroy(player2cells[j].transform.GetChild(0).gameObject);
                            player2cells[j].hasCard = false;
                            player2cells[j].attack = 0;
                            player2cells[j].defense = 0;
                            break;
                        }else{
                            Destroy(player1cells[i].transform.GetChild(0).gameObject);
                            player1cells[i].hasCard = false;
                            player1cells[i].attack = 0;
                            player1cells[i].defense = 0;
                            break;
                        }
                    }
                }
                if(!hasmonster){
                    Player2.health -= player1cells[i].attack;
                    if(Player2.health <= 0){
                        PlayerPrefs.SetInt("victory",1);
                        SceneManager.LoadScene("HomeMenu");
                    }
                }
            }
        }

        for(int i=0; i<player2cells.Count; i++){
            hasmonster = false;
            if(player2cells[i].hasCard){
                for(int j=0; j<player1cells.Count; j++){
                    if(player1cells[j].hasCard){
                        hasmonster = true;
                        if(player2cells[i].attack > player1cells[j].defense){
                            Destroy(player1cells[j].transform.GetChild(0).gameObject);
                            player1cells[j].hasCard = false;
                            player1cells[j].attack = 0;
                            player1cells[j].defense = 0;
                            break;
                        }else{
                            Destroy(player2cells[i].transform.GetChild(0).gameObject);
                            player2cells[i].hasCard = false;
                            player2cells[i].attack = 0;
                            player2cells[i].defense = 0;
                            break;
                        }
                    }
                }

                if(!hasmonster){
                    Player1.health -= player1cells[i].attack;
                    if(Player1.health <= 0){
                        PlayerPrefs.SetInt("victory",2);
                        SceneManager.LoadScene("HomeMenu");
                    }
                }
            }
        }
        
    }

    //add function to handle attack orders
    //add function to handle defense orders


    
}



