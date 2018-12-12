using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public State currentState;

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
    public Button endTurnButton;
    public List<Button> heroesButton;
    public Canvas[] canvases;
    public Text windowText;
    public InputField[] inputs;
    public Text textForGeneral;

    [System.NonSerialized]
    public PlayerController currentPlayer;
    [System.NonSerialized]
    public Stack<Card> stackCards = new Stack<Card>();
    bool started;
    bool endTurn;
    bool actionStarted;
    int killedIndeks;
    int robberyIndeks;
    [System.NonSerialized]
    public bool picked; //gold or card
    [System.NonSerialized]
    public int indeks;
    [System.NonSerialized]
    public bool endGame;
    [System.NonSerialized]
    public bool heroTurn;    
    [System.NonSerialized]
    public List<PlayerController> order = new List<PlayerController>();
    [System.NonSerialized]
    public int kingIndeks;
    [System.NonSerialized]
    public bool destroyBuilding;
    [System.NonSerialized]
    public PlayerController firstEnd;
    [System.NonSerialized]
    public string info;
    [System.NonSerialized]
    public CardInstance cardVariable;

    private void Start()
    {
        Library.gameManager = this;
        canvases[2].gameObject.SetActive(false);
        canvases[3].gameObject.SetActive(true);
        canvases[4].gameObject.SetActive(false);
        canvases[5].gameObject.SetActive(false);
        canvases[0].gameObject.SetActive(true);
        canvases[1].gameObject.SetActive(true);
        Init();
    }

    public void Init()
    {
        endText.gameObject.SetActive(false);
        textForGeneral.gameObject.SetActive(false);
        endTurn = true;
        started = false;
        picked = false;
        endGame = false;
        heroTurn = false;
        destroyBuilding = false;
        indeks = 1;
        currentPlayer = allPlayers[indeks];
        firstEnd = null;
        actionStarted = false;
        kingIndeks = 0;
        killedIndeks = -1;
        robberyIndeks = -1;

        for (int i = allCards.Count - 1; i >= 0; i--)
        {
            int a = Random.Range(0, i + 1);
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
        order = allPlayers;
    }

    //poczatek buttonow
    public void EndTurnButton()
    {
        endTurn = true;
    }

    public void NextPlayerButton()
    {
        canvases[0].gameObject.SetActive(true);
        canvases[1].gameObject.SetActive(true);
        canvases[2].gameObject.SetActive(false);
        currentPlayer.OnLogicAndGraphic();
        if (heroTurn)
        {
            currentPlayer.OffLogic();
        }
        else
        {
            if (currentPlayer.currentHero != null && currentPlayer.currentHero.value == killedIndeks)
                endTurn = true;
            else
                if (currentPlayer.heroCard.card.logic != null)
                    currentPlayer.heroCard.card.logic.OnStart();
        }
    }

    public void PickCardButton()
    {
        if (!picked)
        {
            currentPlayer.PickCard();
            Library.PickButtons(false);
        }
    }

    public void PickGoldButton()
    {
        if (!picked)
        {
            currentPlayer.currentGold += 2;
            currentPlayer.UpdateGold();
            Library.PickButtons(false);
        }
    }

    public void ActionButton()
    {
        if (!actionStarted)
        {
            actionStarted = true;
            currentPlayer.heroCard.card.logic.Active();
            if (currentPlayer.currentHero.value == 8)
            {
                textForGeneral.gameObject.SetActive(true);
                textForGeneral.text = "burzenie aktywne";
            }
        }
        else
        {
            actionStarted = false;
            destroyBuilding = false;
            foreach (Button bt in heroesButton)
            {
                bt.gameObject.SetActive(false);
            }
            if (currentPlayer.currentHero.value == 8)
            {
                textForGeneral.text = "burzenie nieaktywne";
            }
        }
    }

    public void KillButton(int a)
    {
        if (currentPlayer.currentHero.value == 1)
        {
            foreach (PlayerController pc in allPlayers)
            {
                if (pc.currentHero.value == a)
                {
                    pc.heroCard.LoadCard(pc.currentHero);
                    break;
                }
            }
            killedIndeks = a;
            info += "\nzabójca zabija postać numer " + a;
        }
        else
        {
            robberyIndeks = a;
            info += "\nzłodziej okrada postać numer " + a;
        }       

        foreach (Button bt in heroesButton)
        {
            bt.gameObject.SetActive(false);
        }
        actionButton.gameObject.SetActive(false);
    }

    public void NewGameButton()
    {
        canvases[3].gameObject.SetActive(false);
        canvases[4].gameObject.SetActive(true);
    }

    public void StartGameButton()
    {
        if (inputs[0].text !="" && inputs[1].text != "" && inputs[0].text.Length<11 && inputs[1].text.Length < 11 && inputs[0].text != inputs[1].text)
        {
            canvases[2].gameObject.SetActive(true);
            canvases[4].gameObject.SetActive(false);
            started = true;
            allPlayers[0].PlayerNameText.text = inputs[0].text;
            allPlayers[1].PlayerNameText.text = inputs[1].text;
            windowText.text = "nastepny gracz: " + inputs[0].text;
        }
    }

    public void EndPanel()
    {
        canvases[5].gameObject.SetActive(true);
    }

    public void StayInGameButton()
    {
        canvases[5].gameObject.SetActive(false);
    }

    public void EndGameButton()
    {
        Application.Quit();
    }
    //koniec buttonow

    private void Update()
    {
        currentState.Tick();

        if (Input.GetKey("escape"))
        {
            EndPanel();
        }

        if (endTurn)
        {
            endTurn = false;
            currentPlayer.OffLogic();
            currentPlayer.OffGraphic();

            if (indeks < order.Count - 1) //0<1
            {
                if (heroTurn)
                {
                    currentPlayer.heroCard.art.sprite = rewersHero; //ukrycie bohatera wybranego przez gracza
                    Library.HidePickedHero(); //usuniecie z puli boh postaci wybranej przez gracza

                    Library.MirrorRotation(); //zmienia gracza

                    Library.PickButtons(false);
                    actionButton.gameObject.SetActive(false);
                    endTurnButton.gameObject.SetActive(false);
                }
                else
                {
                    Library.MirrorRotation(); //zmienia gracza

                    currentPlayer.heroCard.LoadCard(currentPlayer.currentHero);
                    if (currentPlayer.currentHero.value == robberyIndeks)
                    {
                        foreach (PlayerController pc in order)
                        {
                            if (pc.currentHero.value == 2)
                            {
                                pc.currentGold += currentPlayer.currentGold;
                                currentPlayer.currentGold = 0;
                                pc.UpdateGold();
                                currentPlayer.UpdateGold();
                                break;
                            }
                        }
                    }
                    currentPlayer.built = 1;
                    Library.PickButtons(true);
                    if (currentPlayer.heroCard.card.value == 1 || currentPlayer.heroCard.card.value == 2 || currentPlayer.heroCard.card.value == 3 || (currentPlayer.heroCard.card.value == 8 && order[0].heroCard.card.value != 5))
                    {
                        actionButton.gameObject.SetActive(true);
                        actionStarted = false;
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
                    info = "";
                    currentPlayer.heroCard.art.sprite = rewersHero;
                    Library.HeroPickFaze(false);

                    Library.SortByHero();
                    if (currentPlayer != order[0])
                    {
                        Library.MirrorRotation(); //zmienia gracza
                    }
                    else
                    {
                        indeks = 0;
                    }
                    currentPlayer.heroCard.LoadCard(currentPlayer.currentHero); //wczytanie bohatera gracza0
                    currentPlayer.built = 1;
                    Library.PickButtons(true);
                    if (currentPlayer.heroCard.card.value == 1 || currentPlayer.heroCard.card.value == 2 || currentPlayer.heroCard.card.value == 3 || currentPlayer.heroCard.card.value == 8)
                    {
                        actionButton.gameObject.SetActive(true);
                        actionStarted = false;
                    }
                    else actionButton.gameObject.SetActive(false);
                }
                else//zaczyna sie wybieranie bohaterów
                {
                    killedIndeks = -1;
                    robberyIndeks = -1;
                    Library.PickButtons(false);
                    actionButton.gameObject.SetActive(false);
                    endTurnButton.gameObject.SetActive(false);
                    textForGeneral.gameObject.SetActive(false);
                    foreach (Button bt in heroesButton)
                    {
                        bt.gameObject.SetActive(false);
                    }
                    if (!endGame)
                    {
                        Library.SortByKing();
                        indeks = order.Count;
                        if (currentPlayer != order[0])
                        {
                            Library.MirrorRotation(); //zmienia gracza
                        }
                        else
                        {
                            indeks = 0;
                        }
                        Library.HeroPickFaze(true);
                    }
                    else
                    {
                        Library.EndGame();
                    }
                }
            }
            canvases[0].gameObject.SetActive(false);
            canvases[1].gameObject.SetActive(false);
            if (started)
            {
                canvases[2].gameObject.SetActive(true);
                //if(endGame){ windowText.text= koniec gry } // lub pominąć ten fragment
                windowText.text = "nastepny gracz: " + currentPlayer.PlayerNameText.text;
                if (!heroTurn)
                {
                    windowText.text += "\nbohater o numerze " + currentPlayer.currentHero.value.ToString() + info;
                }
            }
        }
    }
}