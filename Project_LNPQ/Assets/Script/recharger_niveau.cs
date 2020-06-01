using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class recharger_niveau : MonoBehaviour
{
    public void rechargeNiveau()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
