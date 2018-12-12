using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[CreateAssetMenu(menuName = "Action/OnMouseClick")]
public class OnMouseClick : Actions
{
    public override void Execute()
    {
        if (Input.GetMouseButtonDown(0))
        {
            List<RaycastResult> results = Library.GetUIElements();
            IClickable c = null;
            foreach (RaycastResult r in results)
            {
                 c = r.gameObject.GetComponentInParent<IClickable>();
                if (c != null)
                {
                    c.OnClick();
                    break;
                }
            }
        }
    }
}
