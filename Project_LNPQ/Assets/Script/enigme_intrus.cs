using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class enigme_intrus : MonoBehaviour
{

    public static string[] ListeEnigme1 = { "nain", "elfe", "orc", "alien", "squelette" };
    public static string[] ListeEnigme2 = { "épée", "hache", "balai", "lance", "dague" };
    public static string[] ListeEnigme3 = { "casque", "plastron", "blouson", "épaulière", "jambière" };
    string[][] tableauEnigmes = { ListeEnigme1, ListeEnigme2, ListeEnigme3 };

    public static string[] ListeIntrus = { "alien", "balai", "blouson" };

    public GameObject[] boutons;
    public GameObject[] boutonsTextes;
    public Button[] boutonReponse;

    public float delay;
    public GameObject groupeDeBouton;
    public GameObject bpDes;
    public GameObject enigme;
    public GameObject reussite;
    public GameObject echec;

    private int[] tableauDeBoutons = new int[5]; //les boutons a affubler de texte
    private string[] resultRandomListe; //liste choisi aléatoirement pour l'énigme
    private int randomTableauEnigme;

//#######################################################################################################

    // Start is called before the first frame update
    void Start()
    {
        reussite.SetActive(false);
        echec.SetActive(false);
        initialisation();
    }

    void Update()
    {

    }

    //#######################################################################################################

    private void randomListeIntrus() //détermine la liste de mots de l'énigme
    {        //détermine la liste de mots de l'énigme
        int i = tableauEnigmes.Length;
        randomTableauEnigme = UnityEngine.Random.Range(0, i);
        resultRandomListe = tableauEnigmes[randomTableauEnigme];
    }


    private void melangeurDeTableau(string[] tableau)   //détermine l'ordre de la liste de mots de l'énigme
    {
        string contenu; int index,i;
       for (i = 0; i < tableau.Length; i++)
       {
          index = UnityEngine.Random.Range(0, tableau.Length);
            contenu = tableau[i];
            tableau[i] = tableau[index];
            tableau[index] = contenu;
       }   
    }
     
    private void AttributionDesboutonsTextes(string[] resultRandomListe, int[] tableauDeBoutons)
    {

    }


//#######################################################################################################
    private void initialisation()
    {
        randomListeIntrus();
        melangeurDeTableau(resultRandomListe);
        AttributionDesboutonsTextes(resultRandomListe, tableauDeBoutons);

    }

    private void afficheVictoire()
    {
        groupeDeBouton.SetActive(false);
        //Debug.Log("Reussite");
        reussite.SetActive(true);
        Invoke("afficheVictoireAvecDelay", 1);
        //StartCoroutine = launcher de fonction
    }

    private void afficheDefaite()
    {
        groupeDeBouton.SetActive(false);
        //Debug.Log("ECHEC");
        echec.SetActive(true);
        Invoke("afficheDefaiteAvecDelay", 1);
        //StartCoroutine = launcher de fonction
    }
    private void afficheVictoireAvecDelay() //IEnumerator = permet d'appliquer un delay  
    {

        reussite.SetActive(false);
        enleveBoutonDes();
    }

    private void afficheDefaiteAvecDelay() //IEnumerator = permet d'appliquer un delay  
    {

        echec.SetActive(false);
        enleveBoutonDes();

    }

    private void enleveBoutonDes()
    {
        groupeDeBouton.SetActive(true);

        enigme.SetActive(false);
        if (!this.enigme.activeSelf)
        {
            bpDes.SetActive(false);
        }
        initialisation();

    }
}
