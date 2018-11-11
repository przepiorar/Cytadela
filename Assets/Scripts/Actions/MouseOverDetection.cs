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
        foreach (RaycastResult r in results)
        {
             c = r.gameObject.GetComponentInParent<IClickable>();
            if (c != null)
            {   
                c.OnHighlight();
                break;
            }
        }
    }
}