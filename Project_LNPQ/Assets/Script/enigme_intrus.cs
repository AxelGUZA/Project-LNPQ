using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enigmes : MonoBehaviour
{

    public static string[] ListeEnigme1 = { "nain", "elfe", "orc", "alien" };
    public static string[] ListeEnigme2 = { "épée", "hache", "balai", "lance" };
    public static string[] ListeEnigme3 = { "casque", "plastron", "blouson", "épaulière" };
    string[][] tableauEnigmes = { ListeEnigme1, ListeEnigme2, ListeEnigme3 };

    public static string[] ListeIntrus = { "alien", "balai", "blouson" };

    private string[] enigme;
    private int randomTableauEnigme;

    // Start is called before the first frame update
    void Start()
    {
        randomListeIntrus();

    }

    void Update()
    {

    }


    public void randomListeIntrus()
    {        //détermine la liste de mots de l'énigme
        int i = tableauEnigmes.Length;
        randomTableauEnigme = Random.Range(0, i);
        enigme = tableauEnigmes[randomTableauEnigme];
    }

}




/*
 dans void start faire l'affichage de l'énigme
 dans void update faire la fonction de résolution de l'énigme
 */
