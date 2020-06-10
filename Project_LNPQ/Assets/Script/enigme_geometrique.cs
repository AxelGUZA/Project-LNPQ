using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Events;

public class enigme_geometrique : MonoBehaviour
{
    public Button boutonBonneReponse; //trouver comment l'appliquer sur l'élément unique 
    public Button boutonMauvaiseReponse; // trouver comment l'appliquer sur les autres boutons 

    public Sprite[] tableauImages;
    public Button[] boutonReponse;
    public GameObject[] boutons; 
    public GameObject[] boutonImages;
    public GameObject enigme;
    public GameObject reussite;
    public GameObject echec;
    public GameObject groupeDeBouton;

    public float delay;
    
    private int[] tableauImageARandomiser = new int[5];
    private int[] tableauDeBoutonARandomiser = new int[9];

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("tableau d'Image");
        randomValeur(tableauImageARandomiser);
        //Debug.Log("tableau de bouton");
        randomValeur(tableauDeBoutonARandomiser);
        //Debug.Log("Tableau trier");
        AttributionDesboutonsImages(tableauImageARandomiser, tableauDeBoutonARandomiser);
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void randomValeur(int[] K)
    {
       
        int i;
        int j;
        int x;
        bool verif;

        for (i=0; i < K.Length; i++)
        {
                verif = true;
                while (verif)
                {
                    verif = false;
                    x = Random.Range(0,K.Length);
                    for (j = 0; j < i; j++)
                    {
                        if(K[j] == x)
                        {
                            verif = true;
                        }
                    }
                    K[i] = x;
                   
                }
        }
      
    }

    private void AttributionDesboutonsImages(int[] tableauImageARandomiser,int[] tableauDeBoutonARandomiser)
    {
        Debug.Log("#### tableauImageARandomiser[] = [" + tableauImageARandomiser[0] + tableauImageARandomiser[1] + tableauImageARandomiser[2]
            + tableauImageARandomiser[3] + tableauImageARandomiser[4] + "] ####");

        Debug.Log("#### tableauDeBoutonARandomiser[] = [" + tableauDeBoutonARandomiser[0] + tableauDeBoutonARandomiser[1] + tableauDeBoutonARandomiser[2]
           + tableauDeBoutonARandomiser[3] + tableauDeBoutonARandomiser[4] + tableauDeBoutonARandomiser[5]
           + tableauDeBoutonARandomiser[6] + tableauDeBoutonARandomiser[7] + tableauDeBoutonARandomiser[8] + "] ####");

        int y=0;
        for(int i=0; i< tableauImageARandomiser.Length-1; i++)
        {
           
            boutonImages[tableauDeBoutonARandomiser[y]].GetComponent<Image>().sprite = tableauImages[tableauImageARandomiser[i]];
            boutonReponse[tableauDeBoutonARandomiser[y]].onClick.AddListener(afficheDefaite);
            //on place dans le tableau de boutons les indices randomiser des boutons relier au sprite des images du tableau image eux-même compléter par les indices randomiser des images 
            Debug.Log(" # boutonImages 1 [ " + tableauDeBoutonARandomiser[y] + "] , y = " + y + " tableauImages  [" + tableauImageARandomiser[i] +" indice de i =" + i + "]");
            y = y + 1;

            boutonImages[tableauDeBoutonARandomiser[y]].GetComponent<Image>().sprite = tableauImages[tableauImageARandomiser[i]];
            boutonReponse[tableauDeBoutonARandomiser[y]].onClick.AddListener(afficheDefaite);
            // étant donné qu'il y a 2* plus de bouton que de sprite on effectue l'opération 2* en incrémentant l'indice
            Debug.Log(" ## boutonImages 2 [ " + tableauDeBoutonARandomiser[y] + "] , y = " + y + " tableauImages  [" + tableauImageARandomiser[i] + " indice de i =" + i + "]");
            y = y + 1;
            
        }
        y = 0;

        boutonImages[tableauDeBoutonARandomiser[tableauDeBoutonARandomiser.Length - 1]].GetComponent<Image>().sprite = tableauImages[tableauImageARandomiser[tableauImageARandomiser.Length - 1]];
       
        boutonReponse[tableauDeBoutonARandomiser[tableauDeBoutonARandomiser.Length - 1]].onClick.AddListener(afficheVictoire);
        //normalement tabBouton[8] = tabImage[4] //cela correspond à la réponse de l'énigme
      /*  Button boutonBonneReponse = boutonImages[tableauDeBoutonARandomiser[tableauDeBoutonARandomiser.Length - 1]].GetComponent<Button>();
        boutonBonneReponse.onClick.AddListener(afficheVictoire); */

       /* Button boutonMauvaiseReponse = boutonImages[tableauDeBoutonARandomiser[y]].GetComponent<Button>();
        boutonMauvaiseReponse.onClick.AddListener(afficheDefaite); */

        Debug.Log(" ## boutonImages 2 [ " + tableauDeBoutonARandomiser[tableauDeBoutonARandomiser.Length - 1]+ "] , tableauImages  [" + tableauImageARandomiser[tableauImageARandomiser.Length - 1] + " ]");
    }

    private void afficheVictoire()
    {

        afficheVictoireAvecDelay();
        //StartCoroutine = launcher de fonction
    }

    private void afficheDefaite()
    {

        afficheDefaiteAvecDelay();
        //StartCoroutine = launcher de fonction
    }
    private void afficheVictoireAvecDelay() //IEnumerator = permet d'appliquer un delay  
    {
        groupeDeBouton.SetActive(false);
        Debug.Log("Reussite");
        // reussite.SetActive(true);
       
        enigme.SetActive(false);
    }

    private void afficheDefaiteAvecDelay() //IEnumerator = permet d'appliquer un delay  
    {
        groupeDeBouton.SetActive(false);
        Debug.Log("ECHEC");
       // echec.SetActive(true);
     
        enigme.SetActive(false);
    }

  
    


}
