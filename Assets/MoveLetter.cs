using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLetter : GGame
{
    bool locked;
   public int indice;
    float timer=1;
    bool inIt;
   
    voiceLetters cc;
    private void Start()
    {
        cc = FindObjectOfType<voiceLetters>();
    }
    private void OnMouseDrag()
    {
       
        Vector2 MousePo = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (!locked)
        {
            transform.position = MousePo;
        }
    }



    private void Update()
    {
        if(indice == cc.curLetter && !finish)
        {
            if (this.transform.position.x < 6.2 && this.transform.position.x > 4.8 && this.transform.position.y < 0.5 && this.transform.position.y > -1.5) { inIt = true; };
            if (inIt) timer -= Time.deltaTime;
            
            if (timer<=0)
            {
                this.transform.position = new Vector2(0, 0);
                cc.nextLevel();
            }
        }
    }
}
