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
        Settings.SetParentCard(currentCard.value.transform, Settings.gameManager.currentPlayer.tableGrid.transform);
        currentCard.value.gameObject.SetActive(true);
        currentCard.value.currentLogic = cardDownLogic;
        Settings.gameManager.currentPlayer.cardsDown.Add(currentCard.value);
        Settings.gameManager.currentPlayer.cardsHand.Remove(currentCard.value);
        if (Settings.gameManager.currentPlayer.cardsDown.Count == Settings.gameManager.cardsToEndGame)
        {
            Settings.gameManager.endGame = true;
        }
        // Debug.Log("place card down");
    }
}
