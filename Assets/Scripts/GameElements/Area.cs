using UnityEngine;
using System.Collections;

public class Area : MonoBehaviour, IDropable
{
    public CardVariable currentCard;
    public GameObject areaGrid;
    public GE_Logic cardDownLogic;

    public void OnDrop()
    {
        if (currentCard.value == null)
        {
            return;
        }
        //place card down
        currentCard.value.transform.SetParent(areaGrid.transform);
        currentCard.value.transform.localPosition = Vector3.zero;
        currentCard.value.transform.localEulerAngles = Vector3.zero;
        currentCard.value.transform.localScale = Vector3.one;
        currentCard.value.gameObject.SetActive(true);
        currentCard.value.currentLogic = cardDownLogic;
        // Debug.Log("place card down");
    }
}
