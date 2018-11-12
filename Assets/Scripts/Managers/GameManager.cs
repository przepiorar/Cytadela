using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public State currentState;
    public PlayerController currentPlayer;

    public Card[] allCards;
    Dictionary<int, Card> cardDict = new Dictionary<int, Card>();
    public GameObject cardPrefab;

    private void Start()
    {
        Settings.gameManager = this;
        cardDict.Clear();
        for (int i = 0; i < allCards.Length; i++)
        {
            cardDict.Add(i, allCards[i]);
        }
        CreateStartingCard();


    }

    void CreateStartingCard()
    {
        for (int i = 0; i < currentPlayer.startingCards.Length; i++)
        {
            GameObject go = Instantiate(cardPrefab) as GameObject;
            CardVizu viz = go.GetComponent<CardVizu>();
            viz.LoadCard(GetCardInst(currentPlayer.startingCards[i]));
            CardInstance inst = go.GetComponent<CardInstance>();
            Settings.SetParentCard(go.transform,currentPlayer.handGrid.transform);
        }
    }

    Card GetCardInst(int id)
    {
        Card c = null;
        cardDict.TryGetValue(id, out c);
        Card newCard = c ;
        return newCard;

    }

    private void Update()
    {
        currentState.Tick(Time.deltaTime);
    }

    public void SetState(State state)
    {
        currentState = state;
    }

}
