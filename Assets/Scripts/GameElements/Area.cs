using UnityEngine;
using System.Collections;

public class Area : MonoBehaviour
{
    public CardVariable currentCard;
    public GE_Logic cardDownLogic;

    public void OnDrop()
    {
        if (currentCard.value == null)
        {
            return;
        }
        ////place card down
        //currentCard.value.transform.SetParent(areaGrid.transform);
        //currentCard.value.transform.localPosition = Vector3.zero;
        //currentCard.value.transform.localEulerAngles = Vector3.zero;
        //currentCard.value.transform.localScale = Vector3.one;
        Settings.SetParentCard(currentCard.value.transform, Settings.gameManager.currentPlayer.tableGrid.transform);
        currentCard.value.gameObject.SetActive(true);
        currentCard.value.currentLogic = cardDownLogic;
        Settings.gameManager.currentPlayer.cardsDown.Add(currentCard.value);
        Settings.gameManager.currentPlayer.cardsHand.Remove(currentCard.value);
        // Debug.Log("place card down");
    }
}
