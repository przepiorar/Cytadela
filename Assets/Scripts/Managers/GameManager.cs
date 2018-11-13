using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public State currentState;
    public PlayerController currentPlayer;
    
    public List<Card> allCards = new List<Card>();
    Stack<Card> stackCards = new Stack<Card>();
    public GameObject cardPrefab;

    private void Start()
    {
        Settings.gameManager = this;
        int a;


        for (int i = allCards.Count - 1; i >= 0; i--)
        {
            a = Random.Range(0, i + 1);
            stackCards.Push(allCards[a]);
            allCards.RemoveAt(a);
        }
        PickCard();
        PickCard();
        PickCard();
        PickCard();
        PickCard();

    }

    void PickCard()
    {
        GameObject card = Instantiate(cardPrefab) as GameObject;
        CardVizu viz = card.GetComponent<CardVizu>();
        viz.LoadCard(stackCards.Pop());
        CardInstance inst = card.GetComponent<CardInstance>();
        inst.currentLogic = currentPlayer.startingLogic;
        Settings.SetParentCard(card.transform, currentPlayer.handGrid.transform);
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
