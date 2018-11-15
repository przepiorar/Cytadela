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

    public static void MirrorRotation(int a)
    {
        GameObject[] test = GameObject.FindGameObjectsWithTag("test");
        foreach (GameObject item in test)
        {
          //  item.transform.localScale = new Vector3(1, a*1, 1);
            item.transform.localScale = new Vector3(item.transform.localScale.x, a * Mathf.Abs( item.transform.localScale.y), item.transform.localScale.z);
        }
        gameManager.currentPlayer.tableGrid.transform.localScale = new Vector3(0.8f, a*0.8f, 0.8f);
        gameManager.allPlayers[1-gameManager.currentPlayerId].tableGrid.transform.localScale = new Vector3(0.8f, a*0.8f, 0.8f);
        GameObject.FindGameObjectWithTag("Selected").transform.localScale = new Vector3(1, a*1, 1);
        GameObject.FindGameObjectWithTag("Selected2").transform.localScale = new Vector3(1, a*1, 1);
    }


}
