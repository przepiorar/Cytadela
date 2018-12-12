using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Heroes/general")]
public class General : Hero_Logic
{
    public override void OnStart()
    {
        int count = 0;
        foreach (CardInstance item in Library.gameManager.currentPlayer.cardsDown)
        {
            if (item.viz.card.colour == "red" || item.viz.card.sprite.name == "szkolaMagii")
            {
                count++;
            }
        }
        Library.gameManager.currentPlayer.currentGold += count;
        Library.gameManager.currentPlayer.UpdateGold();
    }

    public override void Active()
    {
        Library.gameManager.destroyBuilding = true;
    }
}
