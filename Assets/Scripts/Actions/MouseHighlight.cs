using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[CreateAssetMenu(menuName = "Action/MouseHighlight")]
public class MouseHighlight : Actions
{
    public State playerControlState;
    public CardVariable currentCard;
    public override void Execute(float d)
    {
        // PointerEventData pointerData = new PointerEventData(EventSystem.current) { position = Input.mousePosition };
       // while (true)
       // {
       
        //   Czekaj();
         //   if (Input.mousePosition != currentCard.value.viz.transform.position)
          if(Input.GetMouseButton(0))
            // Czekaj();
            {
                //List<RaycastResult> results = Settings.GetUIObjects();

            
                currentCard.value.gameObject.SetActive(true);  //wracanie karty na rękę
                currentCard.value = null;

                Settings.gameManager.SetState(playerControlState);

                GameObject GameCard = GameObject.FindGameObjectWithTag("Selected2");
                CurrentSelected2 c = GameCard.GetComponent<CurrentSelected2>();
                c.CloseCard();
               // break;
                
            }
     //   }
        return;
    }

    //IEnumerator Czekaj()
    //{
    //    //Vector3 s = Vector3.one * 2;
    //    // this.transform.localScale = s;
    //    yield return new WaitForSeconds(10);

    //    // this.transform.localScale = s / 2;
    //}
}
