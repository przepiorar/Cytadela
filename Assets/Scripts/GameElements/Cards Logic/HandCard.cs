using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[CreateAssetMenu(menuName = "Cards Logic/Hand Card ")]
public class HandCard : GE_Logic
{
    public State holdingCard;  //na jaki state ma sie zmienic karta którą wezmiemy

    public override void OnClick(CardInstance inst)
    {
        Library.gameManager.cardVariable = inst;
        Library.gameManager.currentState = holdingCard;

        GameObject GameCard = GameObject.FindGameObjectWithTag("Selected");
        CurrentSelected c = GameCard.GetComponent<CurrentSelected>();
        c.LoadCard();

        GameObject GameCard1 = GameObject.FindGameObjectWithTag("Highlighted");
        CurrentHighlighted c1 = GameCard1.GetComponent<CurrentHighlighted>();
        c1.CloseCard();

        GameObject GameArea = GameObject.FindGameObjectWithTag("AreaParent");
        GameArea.SetActiveRecursively(true);

    }

    public override void OnHighlight(CardInstance inst)
    {
        Library.gameManager.cardVariable = inst;        
        GameObject GameCard = GameObject.FindGameObjectWithTag("Highlighted");
        CurrentHighlighted c = GameCard.GetComponent<CurrentHighlighted>();
        c.LoadCard();
    }
}
