using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MouvementdesSprite : MonoBehaviour
{

    public Sprite[] serveuse;
    public GameObject serveuseB;
    

    

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(premierPasServeuse());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    IEnumerator premierPasServeuse()
    {
        yield return new WaitForSeconds(0.25f);
        this.serveuseB.GetComponent<Image>().sprite = serveuse[0];
        Debug.Log("Premier Pas");
        StartCoroutine(secondPasServeuse());
    }

    IEnumerator secondPasServeuse()
    {
        yield return new WaitForSeconds(0.25f);
        this.serveuseB.GetComponent<Image>().sprite = serveuse[1];
        Debug.Log("Deuxième Pas");
        StartCoroutine(premierPasServeuse());
    }

    IEnumerator deplacementServeuseVersHaut()
    {
        yield return new WaitForSeconds(0.25f);
    }
}
