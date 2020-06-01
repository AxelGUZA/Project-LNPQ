using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resume_bouton : MonoBehaviour
{
    public GameObject canvas;
    public GameObject bouton;
  

    void Start()
    {
        resume();
    }

  

    public void resume() {
        bouton.SetActive(true);
        canvas.SetActive(false);
       
    }


    public void pause()
    {
        bouton.SetActive(false);
        canvas.SetActive(true);
    
    }
}
