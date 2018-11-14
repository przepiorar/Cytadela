using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "My Card Down")]
public class CardsDown: GE_Logic
{
    public CardVariable currentCard;
    public State highlightCard;  //na jaki state ma sie zmienic karta którą wezmiemy

    public override void OnClick(CardInstance inst)
    {
        Debug.Log("this card is on table");
        //      currentCard.Set(card);
        //      Setting.gameManager.UpdateState(holdingCard);
        //     onCurrentCardSelected.Raise();
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

