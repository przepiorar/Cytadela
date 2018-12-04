using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[CreateAssetMenu(menuName = "Action/MouseOverDetection")]
public class MouseOverDetection : Actions
{
    public override void Execute(float d)
    {
        List<RaycastResult> results = Settings.GetUIObjects();
        IClickable c = null;
        GameObject GameCard = GameObject.FindGameObjectWithTag("Selected2");
        CurrentSelected2 card = null;
        if (GameCard != null)
        {
            card = GameCard.GetComponent<CurrentSelected2>();
        }
        foreach (RaycastResult r in results)
        {
            c = r.gameObject.GetComponentInParent<IClickable>();
            if (c != null)
            {
                if (c != card)
                {
                    card.CloseCard();
                }
                c.OnHighlight();
                break;
            }
            else
            {
                if (card !=null)
                {
                    card.CloseCard();
                }
            }
        }
    }
}