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
        List<CardInstance> tmp = Settings.gameManager.currentPlayer.cardsHand;
        Settings.gameManager.currentPlayer.cardsHand = Settings.gameManager.kolejnosc[Settings.gameManager.allPlayers.Count-1 - Settings.gameManager.indeks].cardsHand;
        Settings.gameManager.kolejnosc[Settings.gameManager.allPlayers.Count-1 - Settings.gameManager.indeks].cardsHand = tmp ;
        foreach (CardInstance card in Settings.gameManager.currentPlayer.cardsHand)
        {
            //card.viz.LoadCard(card.viz.card);
            Settings.SetParentCard(card.transform, Settings.gameManager.currentPlayer.handGrid.transform);
        }
        Settings.gameManager.currentPlayer.OnLogicAndGraphic();
        foreach (CardInstance card in Settings.gameManager.kolejnosc[Settings.gameManager.allPlayers.Count - 1 - Settings.gameManager.indeks].cardsHand)
        {
            card.currentLogic = null;
            card.viz.art.sprite = Settings.gameManager.rewersBud;
            Settings.SetParentCard(card.transform, Settings.gameManager.kolejnosc[Settings.gameManager.allPlayers.Count - 1 - Settings.gameManager.indeks].handGrid.transform);
        }
        Settings.gameManager.actionButton.gameObject.SetActive(false);
    }

}
