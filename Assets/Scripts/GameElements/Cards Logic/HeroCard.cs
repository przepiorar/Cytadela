using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Cards Logic/Hero Card")]
public class HeroCard: CardLogic
{
    public override void OnClick(CardInstance inst)
    {
        Library.gameManager.currentPlayer.heroCard.gameObject.SetActive(true);
        Library.gameManager.endTurnButton.gameObject.SetActive(true);
        Library.gameManager.currentPlayer.currentHero = inst.viz.card;
        Library.gameManager.currentPlayer.heroCard.LoadCard(inst.viz.card);
        if (Library.gameManager.allPlayers[1] == Library.gameManager.currentPlayer)
        {
            Library.gameManager.currentPlayer.heroCard.transform.localScale= new Vector3(0.8f, -0.8f, 0.8f);
        }
        else
        {
            Library.gameManager.currentPlayer.heroCard.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
        }
    }

    public override void OnHighlight(CardInstance inst)
    {
        Library.gameManager.cardVariable = inst;
        GameObject GameCard = GameObject.FindGameObjectWithTag("Highlighted");
        CurrentHighlighted c = GameCard.GetComponent<CurrentHighlighted>();
        c.LoadCard();
    }
}

