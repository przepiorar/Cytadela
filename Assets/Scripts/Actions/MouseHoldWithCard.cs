using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[CreateAssetMenu(menuName = "Action/MouseHoldWithCard")]
public class MouseHoldWithCard : Actions
{
    public State playerControlState;
    public CardVariable currentCard;
    public override void Execute()
    {
        if (!Input.GetMouseButton(0))
        {
            List<RaycastResult> results = Library.GetUIObjects();
            
            foreach (RaycastResult r in results)
            {
                Area a = r.gameObject.GetComponentInParent<Area>();
                if (a !=null)
                {
                    if (Library.gameManager.currentPlayer.currentGold >= currentCard.value.viz.card.value && Library.gameManager.currentPlayer.built>0)
                    {
                        Library.gameManager.currentPlayer.currentGold -= currentCard.value.viz.card.value;
                        Library.gameManager.currentPlayer.UpdateGold();
                        Library.gameManager.currentPlayer.built--;
                        if (currentCard.value.viz.card.colour == "bonus")
                        {
                            currentCard.value.viz.card.value = 8;
                            currentCard.value.viz.card.colour = "purple";
                        }
                        a.OnDrop();
                    }
                    break;
                }
            }
            currentCard.value.gameObject.SetActive(true);  //wracanie karty na rękę
            currentCard.value = null; 
            
            Library.SetState(playerControlState);

            GameObject GameCard = GameObject.FindGameObjectWithTag("Selected");
            CurrentSelected c = GameCard.GetComponent<CurrentSelected>();
            c.CloseCard();

            GameObject GameArea= GameObject.FindGameObjectWithTag("Area");
            GameArea.SetActive(false);

            return;
        }
    }
}
