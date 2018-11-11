using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[CreateAssetMenu(menuName = "My Card Hand ")]
public class HandCard : GE_Logic
{
   public CardVariable currentCard;
    public State holdingCard;  //na jaki state ma sie zmienic karta którą wezmiemy

    public override void OnClick(CardInstance inst)
    {
        //  Debug.Log("this card is in hand");
        currentCard.Set(inst);
        Settings.gameManager.SetState(holdingCard);

        GameObject GameCard = GameObject.FindGameObjectWithTag("Selected");
        CurrentSelected c = GameCard.GetComponent<CurrentSelected>();
        c.LoadCard();

        GameObject GameArea = GameObject.FindGameObjectWithTag("AreaParent");
        GameArea.SetActiveRecursively(true);

    }

    public override void OnHighlight(CardInstance inst)
    {
    }
}
