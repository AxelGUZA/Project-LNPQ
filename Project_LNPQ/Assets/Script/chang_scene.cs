using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class chang_scene : MonoBehaviour
{
  
    public void chargerScene(string MapAchanger)
    {
        SceneManager.LoadScene(MapAchanger);
    }

  

  
}
