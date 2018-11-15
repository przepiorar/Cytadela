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
        koniecTury = true;
        currentPlayerId = 1;
        currentPlayer = allPlayers[1];

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
    }

    public void EndTurnButton()
    {
        koniecTury = true;
    }
    public void PickCardButton()
    {
        currentPlayer.PickCard();
    }


    private void Update()
    {
        currentState.Tick(Time.deltaTime);
        if (koniecTury)
        {
            currentPlayer.OffLogic();
            if (currentPlayerId<allPlayers.Count-1)
            {
                currentPlayerId++;
                currentPlayer = allPlayers[currentPlayerId];
                currentPlayer.OnLogic();
                Settings.MirrorRotation(-1);
            }
            else
            {
                currentPlayerId = 0;
                currentPlayer = allPlayers[currentPlayerId];
                currentPlayer.OnLogic();
                Settings.MirrorRotation(1);
            }
            koniecTury = false;
        }
    }

    public void SetState(State state)
    {
        currentState = state;
    }

}
