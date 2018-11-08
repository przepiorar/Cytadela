using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "My Card Hand ")]
public class HandCard : GE_Logic
{
   // public GameEvent onCurrentCardSelected;
   public CardVariable currentCard;
   // public State holdingCard;

    public override void OnClick(CardInstance inst)
    {
      //  Debug.Log("this card is in hand");
       currentCard.Set(inst);
  //      Setting.gameManager.UpdateState(holdingCard);
   //     onCurrentCardSelected.Raise();
    }

    public override void OnHighlight(CardInstance inst)
    {

    }
}
