using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enigme_geometrique : MonoBehaviour
{
    public Sprite[] tableauImages ;
    public GameObject[] boutons ;

   

    private Sprite[] resultTableauImages;
    private GameObject[] resultTableauBoutons;

    private int supportRandom;
    private int[] K = new int[5];
    

    private void randomImage()
    {
        int i = 0;
        int x = Random.Range(0, tableauImages.Length);
        do
        {
            for(int j =0; j < K.Length; j++)
            {
                if (K[j] == x)
                  x = Random.Range(0, tableauImages.Length);
                else
                    K[i] = x;
            }
            Debug.Log("les valeur de k sont :" + K[i]);
            i++;
            

        } while (i != tableauImages.Length);



       /* int i = 0;  //indice de K[]
            int j = i - 1;  //indice permettant d'empêcher les doublons
            int nb = Random.Range(0, tableauImages.Length);
            K[i] = nb;

            for (i=1; i<K.Length; i++) 
            {
                
                nb = Random.Range(0, tableauImages.Length);
                if(nb == K[j])
                {
                    i--;
                }
                else
                {
                    K[i] = nb;
                }
            }*/
        
    }

    private void randomBouton()
    {

        foreach (GameObject bouton in boutons)
        {
            int i = Random.Range(0, boutons.Length);
            
        }
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
