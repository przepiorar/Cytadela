using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    public Button goldButton;
    public Button cardButton;
    public Button actionButton;
    public Button endButton;
    public List<Button> heroesButton;

    [System.NonSerialized]
    public Stack<Card> stackCards = new Stack<Card>();
    [System.NonSerialized]
    public bool endTurn;
    [System.NonSerialized]
    public bool picked; //gold or card
    [System.NonSerialized]
    public int indeks;
    [System.NonSerialized]
    public bool endGame;
    [System.NonSerialized]
    public bool heroTurn;    
    [System.NonSerialized]
    public List<PlayerController> kolejnosc = new List<PlayerController>();
    [System.NonSerialized]
    public int kingIndeks;
    [System.NonSerialized]
    public int robberyIndeks;
    [System.NonSerialized]
    public bool destroyBuilding;

    private void Start()
    {
        Settings.gameManager = this;
        int a;
        endText.gameObject.SetActive(false);
        endTurn = true;
        picked = false;
        endGame = false;
        heroTurn = false;
        destroyBuilding = false;
        indeks = 1;
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
        kolejnosc = allPlayers;
        kingIndeks = 0;
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
            //picked = true;
            //goldButton.gameObject.SetActive(false);
            //cardButton.gameObject.SetActive(false);
            Settings.ActivateButtons(false);
        }
    }
    public void PickGoldButton()
    {
        if (!picked)
        {
            currentPlayer.currentGold += 2;
            currentPlayer.UpdateGold();
            Settings.ActivateButtons(false);
        }
    }
    public void ActionButton()
    {
        Debug.Log("test");
        currentPlayer.heroCard.card.logic.Active();
    }
    public void KillButton(int a)
    {
        foreach (PlayerController pc in allPlayers)
        {
            if (pc.currentHero.value == a)
            {
                if (currentPlayer.currentHero.value == 1)
                {
                    pc.heroCard.LoadCard(pc.currentHero);
                    kolejnosc.Remove(pc);
                    break;
                }
                else
                {
                    robberyIndeks = a;
                    break;
                }
            }
        }
        foreach (Button bt in Settings.gameManager.heroesButton)
        {
            bt.gameObject.SetActive(false);
        }        
        actionButton.gameObject.SetActive(false);
    }


    private void Update()
    {
        currentState.Tick(Time.deltaTime);
        

        if (endTurn)
        {
            endTurn = false;
            currentPlayer.OffLogic();
            currentPlayer.OffGraphic();

            if (indeks < kolejnosc.Count - 1) //0<1
            {
                if (heroTurn)
                {
                    currentPlayer.heroCard.art.sprite = rewersHero; //ukrycie bohatera wybranego przez gracza
                    Settings.HidePickedHero(); //usuniecie z puli boh postaci wybranej przez gracza

                    if (currentPlayer == allPlayers[0])
                    {
                        Settings.MirrorRotationAndOnLogic_Graph(-1);
                    }
                    else
                    {
                        Settings.MirrorRotationAndOnLogic_Graph(1); //zmienia gracza na 0
                    }
                    currentPlayer.OffLogic();
                    Settings.ActivateButtons(false);
                    actionButton.gameObject.SetActive(false);
                    endButton.gameObject.SetActive(false);
                }
                else
                {
                    if (currentPlayer == allPlayers[0])
                    {
                        Settings.MirrorRotationAndOnLogic_Graph(-1);
                    }
                    else
                    {
                        Settings.MirrorRotationAndOnLogic_Graph(1); //zmienia gracza na 0
                    }
                    currentPlayer.heroCard.LoadCard(currentPlayer.currentHero);
                    if (currentPlayer.currentHero.value == robberyIndeks)
                    {
                        foreach (PlayerController pc in kolejnosc)
                        {
                            pc.currentGold += currentPlayer.currentGold;
                            currentPlayer.currentGold = 0;
                            pc.UpdateGold();
                            currentPlayer.UpdateGold();
                        }
                    }
                    currentPlayer.built = 1;
                    if (currentPlayer.heroCard.card.logic != null)
                    {
                        currentPlayer.heroCard.card.logic.OnStart();
                    }
                    Settings.ActivateButtons(true);
                    if (currentPlayer.heroCard.card.value == 1 || currentPlayer.heroCard.card.value == 2 || currentPlayer.heroCard.card.value == 3 || currentPlayer.heroCard.card.value == 8)
                    {
                        actionButton.gameObject.SetActive(true);
                    }
                    else actionButton.gameObject.SetActive(false);
                    foreach (Button bt in heroesButton)
                    {
                        bt.gameObject.SetActive(false);
                    }
                }
            }
            else //1==1
            {
                if (heroTurn) //ukrycie kart bohaterow i przejscie do fazy budowania budynkow
                {
                    currentPlayer.heroCard.art.sprite = rewersHero;
                    Settings.HeroPickFaze(false);

                    Settings.SortByHero();
                    if (currentPlayer != kolejnosc[0])
                    {
                        if (kolejnosc[0]==allPlayers[0])
                        {
                            Settings.MirrorRotationAndOnLogic_Graph(1); //obraca karty i zmienia gracza.
                        }
                        else
                        {
                            Settings.MirrorRotationAndOnLogic_Graph(-1);
                        }
                    }
                    else 
                    {
                        indeks = 0;
                        currentPlayer.OnLogicAndGraphic();
                    }
                    currentPlayer.heroCard.LoadCard(currentPlayer.currentHero); //wczytanie bohatera gracza0
                    currentPlayer.built = 1;
                    if (currentPlayer.heroCard.card.logic!=null)
                    {
                        currentPlayer.heroCard.card.logic.OnStart();
                    }
                    Settings.ActivateButtons(true);
                    if (currentPlayer.heroCard.card.value==1 || currentPlayer.heroCard.card.value== 2 || currentPlayer.heroCard.card.value== 3 || currentPlayer.heroCard.card.value== 8)
                    {
                        actionButton.gameObject.SetActive(true);
                    }
                    else actionButton.gameObject.SetActive(false);
                }
                else//zaczyna sie wybieranie bohaterów
                {
                    Settings.ActivateButtons(false);
                    actionButton.gameObject.SetActive(false);
                    endButton.gameObject.SetActive(false);
                    foreach (Button bt in Settings.gameManager.heroesButton)
                    {
                        bt.gameObject.SetActive(false);
                    }
                    if (!endGame)
                    {                       
                        Settings.SortByKing();
                        indeks = kolejnosc.Count;
                        if (currentPlayer != kolejnosc[0])
                        {
                            if (kolejnosc[0] == allPlayers[0])
                            {
                                Settings.MirrorRotationAndOnLogic_Graph(1);//zmienia gracza na 0
                            }
                            else
                            {
                                Settings.MirrorRotationAndOnLogic_Graph(-1);
                            }
                        }
                        else
                        {
                            indeks = 0;
                            currentPlayer.OnLogicAndGraphic();
                        }
                        currentPlayer.OffLogic();
                        Settings.HeroPickFaze(true);
                    }
                    //koniec gry
                    // nie patrzec nizej !!!!
                    else
                    {
                        int score = 0;
                        int index = 0;
                        endText.gameObject.SetActive(true);
                        endText.text = "Koniec gry! \n";
                        foreach (PlayerController pl in allPlayers)
                        {
                            //pl.OnGraphic();
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
        }
    }

    public void SetState(State state)
    {
        currentState = state;
    }
}