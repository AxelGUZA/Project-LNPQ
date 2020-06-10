using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextureSol : MonoBehaviour
{
    public Sprite[] imagesSprite;
    public int imagesCourante;
    public GameObject[] imagesAramplacer ;
    // Start is called before the first frame update
    void Start()
    {
        changeSol(this.imagesCourante);
        changeSolRamdom();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void changeSol(int imagesChiffre)
    {
        for (int i = 0; i < imagesAramplacer.Length; i++)
        {
            this.imagesAramplacer[i].GetComponent<Image>().sprite = this.imagesSprite[imagesChiffre];
        }
    }

    public void changeSolRamdom()
    {
        int imagesChiffre = Random.Range(0, imagesSprite.Length);

        for (int i = 0; i < imagesAramplacer.Length; i++)
        {
            this.imagesAramplacer[i].GetComponent<Image>().sprite = this.imagesSprite[imagesChiffre];
        }
    }
}
