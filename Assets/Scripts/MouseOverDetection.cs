using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[CreateAssetMenu(menuName = "Action/MouseOverDetection")]
public class MouseOverDetection : Actions 
{
    public override void Execute(float d)
    {
       // if (Input.GetMouseButton(0))
       // {
            List<RaycastResult> results = Settings.GetUIObjects();
            foreach (RaycastResult r in results)
            {
                IClickable c = r.gameObject.GetComponentInParent<IClickable>();
                if (c != null)
                {
                    c.OnHighlight();
                    break;
                }
                else
                {
                    Debug.Log(r.gameObject.name);
                }
            }
        //}
    }
}