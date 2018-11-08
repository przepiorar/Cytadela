using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "My Card Down")]
public class CardsDown: GE_Logic
{
    // public GameEvent onCurrentCardSelected;
    // public CardVariable currentCard;
    // public State holdingCard;

    public override void OnClick(CardInstance inst)
    {
        Debug.Log("this card is on table");
        //      currentCard.Set(card);
        //      Setting.gameManager.UpdateState(holdingCard);
        //     onCurrentCardSelected.Raise();
    }

    public override void OnHighlight(CardInstance inst)
    {

    }
}
