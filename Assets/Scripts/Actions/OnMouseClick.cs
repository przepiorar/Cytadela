using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[CreateAssetMenu(menuName = "Action/OnMouseClick")]
public class OnMouseClick : Actions
{
    public override void Execute(float d)
    {
        if (Input.GetMouseButtonDown(0))
        {
            List<RaycastResult> results = Settings.GetUIObjects();
            foreach (RaycastResult r in results)
            {
                IClickable c = r.gameObject.GetComponentInParent<IClickable>();
                if (c != null)
                {
                    Settings.time = 0;
                    c.OnClick();
                    break;
                }
            }
        }
    }
}
