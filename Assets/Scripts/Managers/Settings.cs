using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public static class Settings
{
    public static GameManager gameManager;
    public static float time;
    //public static RaycastResult lastCard;
    public static List<RaycastResult> GetUIObjects()  // zwraca liste obiektów w które klikniemy
    {
        PointerEventData pointerData = new PointerEventData(EventSystem.current) { position = Input.mousePosition };
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerData, results);
        return results;
    }

    public static void SetParentCard(Transform c, Transform p)
    {
        c.SetParent(p.transform);
        c.localPosition = Vector3.zero;
        c.localEulerAngles = Vector3.zero;
        c.localScale = Vector3.one;
    }


}
