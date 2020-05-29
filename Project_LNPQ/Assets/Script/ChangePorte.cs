using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangePorte : MonoBehaviour
{
    public Sprite[] spritePorte;
    public int textureCourantePorte;

    public Sprite[] spriteCouloir;
    private string nomDePorte = null;

    public GameObject gameObjectCouloir;


    public GameObject gameObjectPorte;
    public GameObject gameObjectPorte2;
    public GameObject gameObjectPorte3;

 
 

    public Text etage_text;

    private int ramdomNombre;



    public void clickporte1()
    {
        this.nomDePorte = gameObjectPorte.GetComponent<Image>().sprite.ToString();
        Debug.Log("nom de la porte cliquer 1: " + gameObjectPorte.GetComponent<Image>().sprite.ToString());
    }




    public void clickPorte2()
    {
        this.nomDePorte = gameObjectPorte2.GetComponent<Image>().sprite.ToString();
        Debug.Log("nom de la porte cliquer 2 : " + gameObjectPorte2.GetComponent<Image>().sprite.ToString());
    }



    public void clickPorte3()
    {
        this.nomDePorte = gameObjectPorte3.GetComponent<Image>().sprite.ToString();
        Debug.Log("nom de la porte cliquer 3 : " + gameObjectPorte3.GetComponent<Image>().sprite.ToString());
    }




    public void etageSuivant()
    {

        int etage = PlayerPrefs.GetInt("etage");
        etage++;

        if (nomDePorte == "porte_violet (UnityEngine.Sprite)")
        {
            gameObjectCouloir.GetComponent<Image>().sprite = spriteCouloir[3];
            etage = Random.Range(1, 9);

            PlayerPrefs.SetInt("etage", etage);
            Debug.Log("Etage : " + etage);
            activePortecote();
        }

        if (etage == 10)
        {
            nomDePorte = "porte_boss";
            desactivePortecote();
        }
        else if (etage > 10)
        {
            etage = 1;
            activePortecote();
        }


        PlayerPrefs.SetInt("etage", etage);
        etage_text.text = etage + "";



        if (nomDePorte == "porte_boss")
        {
            gameObjectCouloir.GetComponent<Image>().sprite = spriteCouloir[4];
            nomDePorte = null;
        }
        else if (nomDePorte == "porte_rouge (UnityEngine.Sprite)")
        {
            gameObjectCouloir.GetComponent<Image>().sprite = spriteCouloir[0];
            activePortecote();
        }
        else if (nomDePorte == "porte_blue (UnityEngine.Sprite)")
        {
            gameObjectCouloir.GetComponent<Image>().sprite = spriteCouloir[1];
            activePortecote();

        }
        
        else if (nomDePorte == "porte_jaune (UnityEngine.Sprite)")
        {
            gameObjectCouloir.GetComponent<Image>().sprite = spriteCouloir[2];
            desactivePortecote();
        }
      
    }




    private void activePortecote()
    {
        gameObjectPorte2.SetActive(true);
        gameObjectPorte3.SetActive(true);
    }

    private void desactivePortecote()
    {
        gameObjectPorte2.SetActive(false);
        gameObjectPorte3.SetActive(false);
    }




    void Start()
    {

        PlayerPrefs.SetInt("etage", 1);
        randomiseLesPorte();
    }

        

    public void randomiseLesPorte()
    {

       
        randomPorte();
        gameObjectPorte.GetComponent<Image>().sprite = spritePorte[this.textureCourantePorte];



        randomPorte();
        gameObjectPorte2.GetComponent<Image>().sprite = spritePorte[this.textureCourantePorte];
  

        
        randomPorte();
        gameObjectPorte3.GetComponent<Image>().sprite = spritePorte[this.textureCourantePorte];

    }





    public void randomPorte()
    {
        int etage = PlayerPrefs.GetInt("etage");
        ramdomNombre = Random.Range(0, 100);

        if (ramdomNombre >= 0 && ramdomNombre <= 50)
            this.textureCourantePorte = 1;
        else if (ramdomNombre > 50 && ramdomNombre <= 90)
            this.textureCourantePorte = 2;
        else if (ramdomNombre > 90 && ramdomNombre <= 94)
            this.textureCourantePorte = 3;
        else if (ramdomNombre > 94 && ramdomNombre <= 100)
            this.textureCourantePorte = 4;

        if (etage == 9)
        {
            textureCourantePorte = 5;
        }


            switch (textureCourantePorte)
        {
            case 1:
                textureCourantePorte = 1;
                this.textureCourantePorte %= spritePorte.Length;
                break;
            case 2:
                textureCourantePorte = 2;
                this.textureCourantePorte %= spritePorte.Length;
                break;

            case 3:
                textureCourantePorte = 3;
                this.textureCourantePorte %= spritePorte.Length;
                break;
            case 4:
                textureCourantePorte = 4;
                this.textureCourantePorte %= spritePorte.Length;
                break;
            case 5:
                textureCourantePorte = 5;
                this.textureCourantePorte %= spritePorte.Length;
                break;

            default:
                textureCourantePorte = 0;
                this.textureCourantePorte %= spritePorte.Length;
                break;


 
        }
        
    }
}

