using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[CreateAssetMenu(menuName = "Action/MouseOverDetection")]
public class MouseOverDetection : Actions
{
    //float time; += Time.deltaTime;
    public override void Execute(float d)
    {
       
        List<RaycastResult> results = Settings.GetUIObjects();
        IClickable c = null;
        foreach (RaycastResult r in results)
        {
             c = r.gameObject.GetComponentInParent<IClickable>();
            if (c != null )
            {
               // if (Settings.lastCard == r)
                //Settings.lastCard = r;
                Settings.time += d;
                if (Settings.time >=2f)
                {
                    Settings.time = 0;
                    c.OnHighlight();
                    break;
                }
            }
        }
    }
    
}