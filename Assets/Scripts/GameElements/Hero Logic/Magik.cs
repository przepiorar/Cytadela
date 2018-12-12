using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Heroes/magik")]
public class Magik : Hero_Logic
{
    public override void OnStart()
    {
    }

    public override void Active()
    {
        List<CardInstance> tmp = Library.gameManager.currentPlayer.cardsHand;
        Library.gameManager.currentPlayer.cardsHand = Library.gameManager.order[Library.gameManager.allPlayers.Count-1 - Library.gameManager.indeks].cardsHand;
        Library.gameManager.order[Library.gameManager.allPlayers.Count-1 - Library.gameManager.indeks].cardsHand = tmp ;
        foreach (CardInstance card in Library.gameManager.currentPlayer.cardsHand)
        {
            //card.viz.LoadCard(card.viz.card);
            Library.SetParentCard(card.transform, Library.gameManager.currentPlayer.handGrid.transform);
        }
        Library.gameManager.currentPlayer.OnLogicAndGraphic();
        foreach (CardInstance card in Library.gameManager.order[Library.gameManager.allPlayers.Count - 1 - Library.gameManager.indeks].cardsHand)
        {
            card.currentLogic = null;
            card.viz.art.sprite = Library.gameManager.rewersBud;
            Library.SetParentCard(card.transform, Library.gameManager.order[Library.gameManager.allPlayers.Count - 1 - Library.gameManager.indeks].handGrid.transform);
        }
        Library.gameManager.actionButton.gameObject.SetActive(false);
    }

}
