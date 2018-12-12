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
        Library.SetParentCard(currentCard.value.transform, Library.gameManager.currentPlayer.tableGrid.transform);
        currentCard.value.gameObject.SetActive(true);
        currentCard.value.currentLogic = cardDownLogic;
        Library.gameManager.currentPlayer.cardsDown.Add(currentCard.value);
        Library.gameManager.currentPlayer.cardsHand.Remove(currentCard.value);
        if (Library.gameManager.currentPlayer.cardsDown.Count == Library.gameManager.cardsToEndGame)
        {
            Library.gameManager.endGame = true;
            if (Library.gameManager.firstEnd == null)
            {
                Library.gameManager.firstEnd = Library.gameManager.currentPlayer;
            }
        }
    }
}
