using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public State currentState;
    public PlayerController currentPlayer;

    public List<PlayerController> allPlayers = new List<PlayerController>();    
    public List<Card> allCards = new List<Card>();
    public List<Card> allHeroCards = new List<Card>();
    public GameObject cardPrefab;
    public Sprite rewersBud;
    public Sprite rewersHero;
    public List<CardVizu> HeroPickGrid = new List<CardVizu>();

    public int startingGold;
    public int cardsToEndGame;
    public Text endText;

    [System.NonSerialized]
    public Stack<Card> stackCards = new Stack<Card>();
    [System.NonSerialized]
    public bool endTurn;
    [System.NonSerialized]
    public bool picked; //gold or card
    [System.NonSerialized]
    public int currentPlayerId;
    [System.NonSerialized]
    public bool endGame;
    [System.NonSerialized]
    public bool heroTurn;

    [System.NonSerialized]
    List<int> cyfry = new List<int>();

    private void Start()
    {
        Settings.gameManager = this;
        int a;
        endText.text = "";
        endTurn = true;
        picked = false;
        endGame = false;
        heroTurn = false;
        currentPlayerId = 1;
        currentPlayer = allPlayers[1];

        for (int i = allCards.Count - 1; i >= 0; i--)
        {
            a = Random.Range(0, i + 1);
            stackCards.Push(allCards[a]);
            allCards.RemoveAt(a);
        }
        foreach (PlayerController player in allPlayers)
        {
            player.currentGold = startingGold;
            player.PickCard();
            player.PickCard();
            player.PickCard();
            player.PickCard();
            player.UpdateGold();
            player.heroCard.gameObject.SetActive(false);
        }
    }

    public void EndTurnButton()
    {
        endTurn = true;
    }
    public void PickCardButton()
    {
        if (!picked)
        {
            currentPlayer.PickCard();
            picked = true;
        }
    }
    public void PickGoldButton()
    {
        if (!picked)
        {
            currentPlayer.currentGold += 2;
            currentPlayer.UpdateGold();
            picked = true;
        }
    }


    private void Update()
    {
        currentState.Tick(Time.deltaTime);

        if (endTurn)
        {
            currentPlayer.OffLogic();
            if (currentPlayerId < allPlayers.Count - 1) //0<1
            {
                //currentPlayerId++;
                //currentPlayer = allPlayers[currentPlayerId];
                //currentPlayer.OnLogic();
                Settings.MirrorRotation(-1); //zmienia gracza na 1
                currentPlayer.heroCard.LoadCard(currentPlayer.currentHero);
                if (heroTurn)
                {

                    allPlayers[0].heroCard.art.sprite = rewersHero;
                    foreach (CardInstance inst in currentPlayer.cardsHand)
                    {
                        inst.currentLogic = null;
                    }
                }
            }
            else //1==1
            {
                Settings.MirrorRotation(1); //obraca karty i zmienia gracza na 0.
                if (heroTurn)
                {
                    allPlayers[1].heroCard.art.sprite = rewersHero;
                    heroTurn = false;
                    foreach (CardVizu item in HeroPickGrid)
                    {
                        item.gameObject.SetActive(false);
                    }
                    currentPlayer.heroCard.LoadCard(currentPlayer.currentHero);
                }
                else
                {
                    if (!endGame)
                    {
                        endTurn = false;
                        heroTurn = true;
                        cyfry = Settings.RandomHero();
                        foreach (CardInstance inst in currentPlayer.cardsHand)
                        {
                            inst.currentLogic = null;
                        }
                        foreach (CardVizu item in HeroPickGrid)
                        {
                            item.gameObject.SetActive(true);
                        }
                        for (int i = 0; i < 6; i++)
                        {
                            HeroPickGrid[i].LoadCard(allHeroCards[cyfry[i]]);
                            HeroPickGrid[i].gameObject.SetActive(true);
                        }
                        foreach (PlayerController pc in allPlayers)
                        {
                            pc.heroCard.gameObject.SetActive(false);
                        }
                    }
                    else
                    {
                        int score = 0;
                        int index = 0;
                        endText.text = "Koniec gry! \n";
                        foreach (PlayerController pl in allPlayers)
                        {
                            score = 0;
                            for (int i = 0; i < pl.cardsDown.Count; i++)
                            {
                                score += pl.cardsDown[i].viz.card.value;
                            }
                            endText.text += "Gracz " + (index + 1) + " uzyskał: " + score + " punktów \n";
                            index++;
                        }
                    }
                }
            }
            endTurn = false;
            picked = false;
        }
    }

    public void SetState(State state)
    {
        currentState = state;
    }
}
