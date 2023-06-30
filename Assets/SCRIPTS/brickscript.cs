using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brickscript : MonoBehaviour
{
    // Start is called before the first frame update
    public int points;
   
    public int hitsToBreak;
    public Sprite hitSprite;
   

    public void BreakBrick()
    {
        hitsToBreak--;

        GetComponent<SpriteRenderer>().sprite = hitSprite;
    }
}
