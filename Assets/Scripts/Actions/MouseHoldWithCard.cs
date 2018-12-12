using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[CreateAssetMenu(menuName = "Action/MouseHoldWithCard")]
public class MouseHoldWithCard : Actions
{
    public State playerControlState;
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
                    if (Library.gameManager.currentPlayer.currentGold >= Library.gameManager.cardVariable.viz.card.value && Library.gameManager.currentPlayer.built>0)
                    {
                        Library.gameManager.currentPlayer.currentGold -= Library.gameManager.cardVariable.viz.card.value;
                        Library.gameManager.currentPlayer.UpdateGold();
                        Library.gameManager.currentPlayer.built--;
                        if (Library.gameManager.cardVariable.viz.card.colour == "bonus")
                        {
                            Library.gameManager.cardVariable.viz.card.value = 8;
                            Library.gameManager.cardVariable.viz.card.colour = "purple";
                        }
                        a.OnDrop();
                    }
                    break;
                }
            }
            Library.gameManager.cardVariable.gameObject.SetActive(true);  //wracanie karty na rękę
            Library.gameManager.cardVariable = null; 
            
            Library.gameManager.currentState = playerControlState;

            GameObject GameCard = GameObject.FindGameObjectWithTag("Selected");
            CurrentSelected c = GameCard.GetComponent<CurrentSelected>();
            c.CloseCard();

            GameObject GameArea= GameObject.FindGameObjectWithTag("Area");
            GameArea.SetActive(false);
        }
    }
}
