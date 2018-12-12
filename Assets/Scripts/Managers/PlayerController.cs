using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameObject handGrid;
    public GameObject tableGrid;
    public CardLogic startingLogic;
    public CardVizu heroCard;
    public Text goldText;
    public Text PlayerNameText;
    public Image PlayerCrown;
    [System.NonSerialized]
    public List<CardInstance> cardsHand = new List<CardInstance>();
    [System.NonSerialized]
    public List<CardInstance> cardsDown= new List<CardInstance>();
    [System.NonSerialized]
    public int currentGold;
    [System.NonSerialized]
    public Card currentHero;
    [System.NonSerialized]
    public int built;


    public void PickCard()
    {
        GameObject card = Instantiate(Library.gameManager.cardPrefab);// as GameObject;
        CardVizu viz = card.GetComponent<CardVizu>();
        viz.LoadCard(Library.gameManager.stackCards.Pop());
        CardInstance inst = card.GetComponent<CardInstance>();
        inst.player = this;
        cardsHand.Add(inst);
        inst.currentLogic = startingLogic;
        Library.SetParentCard(card.transform,handGrid.transform);
    }
    public void OffGraphic()
    {
        foreach (CardInstance inst in cardsHand)
        {
            inst.viz.art.sprite = Library.gameManager.rewersBud;
        }
    }
    public void OffLogic()
    {
        foreach (CardInstance inst in cardsHand)
        {
            inst.currentLogic = null;          
        }
    }
    public void OnLogicAndGraphic()
    {
        foreach (CardInstance inst in cardsHand)
        {
            inst.currentLogic = startingLogic;
            inst.viz.art.sprite = inst.viz.card.sprite;            
        }
    }
    public void UpdateGold()
    {
        goldText.text = "Złoto: " + currentGold.ToString();
    }
}
