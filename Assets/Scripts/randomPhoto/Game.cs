using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public bool pause;
   public float timer_of_finish = 0;

    public void Pause()
    {
        pause = true;
        
    }
    public void resume()
    {
        pause = false;
       
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
