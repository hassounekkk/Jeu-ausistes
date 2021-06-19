using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LettersVoice : MonoBehaviour
{
    public AudioSource[] letter;
    // Start is called before the first frame update
   
    public void Tell(int n)
    {
        letter[n].Play();
    }

}
