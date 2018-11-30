using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Heroes/zabojca")]
public class Zabojca : Hero_Logic
{
    public override void OnStart()
    {
    }

    public override void Active()
    {
        foreach (Button bt in Settings.gameManager.heroesButton)
        {
            bt.gameObject.SetActive(true);
        }
    }

}
