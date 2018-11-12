using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardVizu : MonoBehaviour {
    
    public Card card;
    public CardVizuProp[] properties; 

    //private void Start()
    //{
    //    LoadCard(card);
    //}
    public void LoadCard(Card c)
    {
        if (c == null)
        {
            return;
        }
        for (int i = 0; i < properties.Length; i++)
        {
            CardProperties cp = c.properties[i];
            CardVizuProp p = GetProp(cp.element);
            if (p==null)
            {
                continue;
            }
            if (cp.element is ElementImage)
            {
                p.image.sprite = cp.sprite;
            }
            if (cp.element is ElementInt)
            {
            }
        }
    }

    public CardVizuProp GetProp(Element e)
    {
        CardVizuProp result = null;
        for (int i = 0; i < properties.Length; i++)
        {
            if (properties[i].element == e)
            {
                result = properties[i];
                break;
            }

        }
        return result;
    }
}
