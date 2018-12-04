using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Cards Logic/Hero Card")]
public class HeroCard: GE_Logic
{
    public CardVariable currentCard;
    public State highlightCard;  //na jaki state ma sie zmienic karta którą wezmiemy

    public override void OnClick(CardInstance inst)
    {
        Settings.gameManager.currentPlayer.heroCard.gameObject.SetActive(true);
        Settings.gameManager.endButton.gameObject.SetActive(true);
        Settings.gameManager.currentPlayer.currentHero = inst.viz.card;
        Settings.gameManager.currentPlayer.heroCard.LoadCard(inst.viz.card);
        if (Settings.gameManager.allPlayers[1] == Settings.gameManager.currentPlayer)
        {
            Settings.gameManager.currentPlayer.heroCard.transform.localScale= new Vector3(0.8f, -0.8f, 0.8f);
        }
        else
        {
            Settings.gameManager.currentPlayer.heroCard.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
        }
    }

    public override void OnHighlight(CardInstance inst)
    {
        currentCard.Set(inst);
        GameObject GameCard = GameObject.FindGameObjectWithTag("Selected2");
        CurrentSelected2 c = GameCard.GetComponent<CurrentSelected2>();
        c.LoadCard();
    }
}

