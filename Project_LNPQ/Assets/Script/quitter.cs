using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quitter : MonoBehaviour
{
   public void Pourquitter()
    {
        Debug.Log("has left ce game");
        Application.Quit();
    }
}
