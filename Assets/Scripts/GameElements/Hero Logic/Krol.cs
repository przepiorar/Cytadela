using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Heroes/krol")]
public class Krol : Hero_Logic
{
    public override void OnStart()
    {
        int count = 0;
        foreach (CardInstance item in Settings.gameManager.currentPlayer.cardsDown)
        {
            if (item.viz.card.colour == "yellow")
            {
                count++;
            }
        }
        Settings.gameManager.currentPlayer.currentGold += count;
        Settings.gameManager.currentPlayer.UpdateGold();
        // niepotrzebne
        //for (int i = 0; i < Settings.gameManager.allPlayers.Count; i++)
        //{
        //    if (Settings.gameManager.currentPlayer == Settings.gameManager.allPlayers[i])
        //    {
        //        Settings.gameManager.kingIndeks = i;
        //        //korona.SetActive
        //    }
        //}
    }


    public override void Active()
    {
    }
}