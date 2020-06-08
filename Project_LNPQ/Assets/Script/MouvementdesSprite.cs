using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MouvementdesSprite : MonoBehaviour
{

    public Sprite[] serveuse;
    public GameObject serveuseB;

    private float delay = 0.1f;

    private bool verif = true;
    

    

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(premierPasServeuse());
       
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(allerRetour());

    }

    

    IEnumerator premierPasServeuse()
    {
        yield return new WaitForSeconds(delay);
        this.serveuseB.GetComponent<Image>().sprite = serveuse[0];
        
        StartCoroutine(secondPasServeuse());
        
    }

    IEnumerator secondPasServeuse()
    {
        yield return new WaitForSeconds(delay);
        this.serveuseB.GetComponent<Image>().sprite = serveuse[1];
      
        StartCoroutine(premierPasServeuse());
        
    }

    IEnumerator allerRetour()
    {
         int i = 0;
         if (serveuseB.transform.position.y >= 966)
         {
             while (i != 10)
             {
                 yield return new WaitForSeconds(delay);
                 deplacementServeuseVersbas();
                i++;
            }
            verif = false;

            if (i == 10 || serveuseB.transform.position.y <= 300)
            {
                verif = true;
            }

        }
         else if (verif)
         {
            
                yield return new WaitForSeconds(delay);
                deplacementServeuseVersHaut();
              
            

        }

        Debug.Log(serveuseB.transform.position.y);
    }



    private void deplacementServeuseVersHaut()
    {

       // serveuseB.transform.Rotate(0, 0, 180f, Space.Self);
        serveuseB.transform.position = transform.position + new Vector3(0, 10, 0);
    }

    private void deplacementServeuseVersbas()
    {
        
      ///  serveuseB.transform.Rotate(0, 0, -180f, Space.Self);
        serveuseB.transform.position = transform.position - new Vector3(0, 10, 0);
           
    }


}
