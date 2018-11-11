using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[CreateAssetMenu(menuName = "Action/MouseHoldWithCard")]
public class MouseHoldWithCard : Actions
{
    public State playerControlState;
    public CardVariable currentCard;
    public override void Execute(float d)
    {
        bool mouseIsDown = Input.GetMouseButton(0);
        if (!mouseIsDown)
        {
            List<RaycastResult> results = Settings.GetUIObjects();
            
            foreach (RaycastResult r in results)
            {
                Area a = r.gameObject.GetComponentInParent<Area>();
                if (a !=null)
                {
                    a.OnDrop();
                    break;
                }
            }
            currentCard.value.gameObject.SetActive(true);  //wracanie karty na rękę
            currentCard.value = null; 
            
            Settings.gameManager.SetState(playerControlState);

            GameObject GameCard = GameObject.FindGameObjectWithTag("Selected");
            CurrentSelected c = GameCard.GetComponent<CurrentSelected>();
            c.CloseCard();

            GameObject GameArea= GameObject.FindGameObjectWithTag("Area");
            GameArea.SetActive(false);

            return;
        }
    }
}
