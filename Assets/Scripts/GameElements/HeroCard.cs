using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Hero Card")]
public class HeroCard: GE_Logic
{
    public CardVariable currentCard;
    public State highlightCard;  //na jaki state ma sie zmienic karta którą wezmiemy

    public override void OnClick(CardInstance inst)
    {
        Settings.gameManager.currentPlayer.heroCard.gameObject.SetActive(true);
        Settings.gameManager.currentPlayer.currentHero = inst.viz.card;
        Settings.gameManager.currentPlayer.heroCard.LoadCard(inst.viz.card);
        if (Settings.gameManager.currentPlayerId ==1)
        {
            Settings.gameManager.currentPlayer.heroCard.transform.localScale= new Vector3(0.8f, -0.8f, 0.8f);
        }
    }

    public override void OnHighlight(CardInstance inst)
    {
        if (currentCard.value != null)
        {
            return;
        }
        currentCard.Set(inst);
        Settings.gameManager.SetState(highlightCard);


        GameObject GameCard = GameObject.FindGameObjectWithTag("Selected2");
        CurrentSelected2 c = GameCard.GetComponent<CurrentSelected2>();
        c.LoadCard();
    }
}

