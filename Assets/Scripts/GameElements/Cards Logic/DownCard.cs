using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Cards Logic/Down Card ")]
public class DownCard: GE_Logic
{
    public CardVariable currentCard;
    public State highlightCard;  //na jaki state ma sie zmienic karta którą wezmiemy

    public override void OnClick(CardInstance inst)
    {
        if (Settings.gameManager.currentPlayer.currentHero.value ==8 && Settings.gameManager.destroyBuilding)
        {
            if (Settings.gameManager.currentPlayer.currentGold >= inst.viz.card.value-1 && inst.player.currentHero.value !=5 && inst.viz.card.sprite.name != "fort" && inst.player.cardsDown.Count < Settings.gameManager.cardsToEndGame)
            {
                inst.player.cardsDown.Remove(inst);
                inst.viz.gameObject.SetActive(false);

                //GameObject card =inst.GetComponent<GameObject>();
                //Destroy(card);

                Settings.gameManager.actionButton.gameObject.SetActive(false);
                Settings.gameManager.currentPlayer.currentGold -= (inst.viz.card.value - 1);
                Settings.gameManager.currentPlayer.UpdateGold();
                Settings.gameManager.destroyBuilding = false;
            }
        }
        Debug.Log("this card is on table");
    }

    public override void OnHighlight(CardInstance inst)
    {
        currentCard.Set(inst);
        GameObject GameCard = GameObject.FindGameObjectWithTag("Selected2");
        CurrentSelected2 c = GameCard.GetComponent<CurrentSelected2>();
        c.LoadCard();
    }
}

