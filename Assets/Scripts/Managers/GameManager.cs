using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public State currentState;
    public PlayerController currentPlayer;

    public List<PlayerController> allPlayers = new List<PlayerController>();    
    public List<Card> allCards = new List<Card>();
    public GameObject cardPrefab;
    public Sprite rewers;

    [System.NonSerialized]
    public Stack<Card> stackCards = new Stack<Card>();
    [System.NonSerialized]
    public bool koniecTury;
    [System.NonSerialized]
    public int currentPlayerId;

    private void Start()
    {
        Settings.gameManager = this;
        int a;

        for (int i = allCards.Count - 1; i >= 0; i--)
        {
            a = Random.Range(0, i + 1);
            stackCards.Push(allCards[a]);
            stackCards.Push(allCards[a]);
            allCards.RemoveAt(a);
        }
        foreach (PlayerController player in allPlayers)
        {
            player.PickCard();
            player.PickCard();
            player.PickCard();
            player.PickCard();
        }
        koniecTury = false;
        currentPlayerId = 0;
        //currentPlayer.PickCard();
        //currentPlayer.PickCard();
        //currentPlayer.PickCard();
        //currentPlayer.PickCard();
    }

    public void KoniecTury()
    {
      //  currentPlayer.PickCard();
        koniecTury = true;
    }


    private void Update()
    {
        currentState.Tick(Time.deltaTime);
        if (koniecTury)
        {
            if (currentPlayerId<allPlayers.Count-1)
            {
                currentPlayer.OffLogic();
                currentPlayerId++;
                currentPlayer = allPlayers[currentPlayerId];
                koniecTury =false;
                currentPlayer.OnLogic();
              //  allPlayers[1].handGrid = allPlayers[0].handGrid;
            }
            else
            {
                currentPlayer.OffLogic();
                currentPlayerId = 0;
                currentPlayer = allPlayers[currentPlayerId];
                koniecTury = false;
                currentPlayer.OnLogic();
            }
        }
    }

    public void SetState(State state)
    {
        currentState = state;
    }

}
