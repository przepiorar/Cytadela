using UnityEngine;
using System.Collections;

public class Area : MonoBehaviour
{
    public GE_Logic cardDownLogic;

    public void OnDrop()
    {
        if (Library.gameManager.cardVariable == null)
        {
            return;
        }
        Library.SetParentCard(Library.gameManager.cardVariable.transform, Library.gameManager.currentPlayer.tableGrid.transform);
        Library.gameManager.cardVariable.gameObject.SetActive(true);
        Library.gameManager.cardVariable.currentLogic = cardDownLogic;
        Library.gameManager.currentPlayer.cardsDown.Add(Library.gameManager.cardVariable);
        Library.gameManager.currentPlayer.cardsHand.Remove(Library.gameManager.cardVariable);
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
