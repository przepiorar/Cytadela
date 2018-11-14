using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject handGrid;
    public GameObject tableGrid;
    public GE_Logic startingLogic;
    [System.NonSerialized]
    public List<CardInstance> cardsHand = new List<CardInstance>();
    [System.NonSerialized]
    public List<CardInstance> cardsDown= new List<CardInstance>();
    

   public void PickCard()
    {
        GameObject card = Instantiate(Settings.gameManager.cardPrefab) as GameObject;
        CardVizu viz = card.GetComponent<CardVizu>();
        viz.LoadCard(Settings.gameManager.stackCards.Pop());
        CardInstance inst = card.GetComponent<CardInstance>();
        cardsHand.Add(inst);
        inst.currentLogic = startingLogic;
        Settings.SetParentCard(card.transform,handGrid.transform);
    }

    public void OffLogic()
    {
        foreach (CardInstance inst in cardsHand)
        {
            inst.currentLogic = null;
            inst.viz.art.sprite = Settings.gameManager.rewers;
        }
    }
    public void OnLogic()
    {
        foreach (CardInstance inst in cardsHand)
        {
            inst.currentLogic = startingLogic;
            inst.viz.art.sprite = inst.viz.card.sprite;
        }
    }
}
