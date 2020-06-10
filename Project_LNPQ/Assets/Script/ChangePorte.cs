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

    public GameObject gameobjectbp_bouclier;
    public GameObject gameobjectbp_combat;
    public GameObject gameobjectbp_des;

 
    public GameObject gameObjectPorte;
    public GameObject gameObjectPorte2;
    public GameObject gameObjectPorte3;

   
    public GameObject gameobjectEgnimeCal;
    public GameObject gameobjectEgnimeGeo;
    public GameObject gameobjectEgnimeintru;

    public Text etage_text;

    private int ramdomNombre;

    private bool verifPorteDroit;
    private bool verifPorteDroite;
    private bool verifPorteGauche;



    public void clickporte1()
    {
        this.nomDePorte = gameObjectPorte.GetComponent<Image>().sprite.ToString();
        activeCouloirDroit();
        Debug.Log("nom de la porte cliquer 1: " + gameObjectPorte.GetComponent<Image>().sprite.ToString());
    }




    public void clickPorte2()
    {
        this.nomDePorte = gameObjectPorte2.GetComponent<Image>().sprite.ToString();
        activeCouloirDroite();
        Debug.Log("nom de la porte cliquer 2 : " + gameObjectPorte2.GetComponent<Image>().sprite.ToString());
    }



    public void clickPorte3()
    {
        this.nomDePorte = gameObjectPorte3.GetComponent<Image>().sprite.ToString();
        activeCouloirGauche();
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

        if (this.nomDePorte == "porte_boss")
        {
            gameObjectCouloir.GetComponent<Image>().sprite = spriteCouloir[5];
            nomDePorte = null;
            activeAllBouton();
            desactiveAllEgnime();
        }
        else if (verifPorteDroit)
        {
           
            choixDecouloirDroit();
        }
        else if (verifPorteDroite)
        {
            
            choixDecouloirDroite();
        }
        else if (verifPorteGauche)
        {
            choixDecouloirGauche();
        }
            





    }

    private void choixDecouloirDroit()
    {
         if (this.nomDePorte == "porte_rouge (UnityEngine.Sprite)")
        {
            gameObjectCouloir.GetComponent<Image>().sprite = spriteCouloir[0];
            activePortecote();
            activeAllBouton();
            desactiveAllEgnime();
        }
        else if (this.nomDePorte == "porte_blue (UnityEngine.Sprite)")
        {
            gameObjectCouloir.GetComponent<Image>().sprite = spriteCouloir[6];
            activePortecote();
            activeOnlyDesBouton();
            randomEgnime();

        }

        else if (this.nomDePorte == "porte_jaune (UnityEngine.Sprite)")
        {
            gameObjectCouloir.GetComponent<Image>().sprite = spriteCouloir[11];
            desactivePortecote();
            desactiveAllBouton();
            desactiveAllEgnime();
        }
    }

    private void choixDecouloirDroite()
    {
        int rand = Random.Range(1, 100);

        if (rand < 50)
        {
            rand = 3;
        }
        else
        {
            rand = 4;
        }
    
        Debug.Log("le random est de = " + rand);


         if (this.nomDePorte == "porte_rouge (UnityEngine.Sprite)")
        {
            gameObjectCouloir.GetComponent<Image>().sprite = spriteCouloir[0+rand];
            porteActivePourDroite();
            activeAllBouton();
            desactiveAllEgnime();
        }
        else if (this.nomDePorte == "porte_blue (UnityEngine.Sprite)")
        {
            gameObjectCouloir.GetComponent<Image>().sprite = spriteCouloir[6+rand];

            porteActivePourDroite();
            activeOnlyDesBouton();
            randomEgnime();

        }

        else if (this.nomDePorte == "porte_jaune (UnityEngine.Sprite)")
        {
            rand = Random.Range(1, 2);
            gameObjectCouloir.GetComponent<Image>().sprite = spriteCouloir[11+rand];
            desactivePortecote();
            desactiveAllBouton();
            desactiveAllEgnime();
        }
    }

    private void choixDecouloirGauche()
    {
        int rand = Random.Range(1, 100);

        if (rand < 50)
        {
            rand = 1;
        }
        else
        {
            rand = 2;
        }

        if (this.nomDePorte == "porte_rouge (UnityEngine.Sprite)")
        {
            gameObjectCouloir.GetComponent<Image>().sprite = spriteCouloir[0 + rand];
            porteActivePourGauche();
            activeAllBouton();
            desactiveAllEgnime();
        }
        else if (this.nomDePorte == "porte_blue (UnityEngine.Sprite)")
        {
            gameObjectCouloir.GetComponent<Image>().sprite = spriteCouloir[6 + rand];

            porteActivePourGauche();
            activeOnlyDesBouton();
            randomEgnime();

        }

        else if (this.nomDePorte == "porte_jaune (UnityEngine.Sprite)")
        {
            gameObjectCouloir.GetComponent<Image>().sprite = spriteCouloir[11 + rand];
            desactivePortecote();
            desactiveAllBouton();
            desactiveAllEgnime();
        }
    }



    private void randomEgnime()
    {


        switch (Random.Range(2, 2))
        {
            case 1: activeCalEgnime();
                break;
            case 2:
                activeGeoEgnime();
                break;
            case 3:
                //activeIntruEgnime();
                break;
        }
    }


    //COULOIR

    private void activeCouloirDroit()
    {
        verifPorteDroit = true;
        verifPorteDroite = false;
        verifPorteGauche = false;
    }

    private void activeCouloirDroite()
    {
        verifPorteDroit = false;
        verifPorteDroite = true;
        verifPorteGauche = false;
    }

    private void activeCouloirGauche()
    {
        verifPorteDroit = false;
        verifPorteDroite = false;
        verifPorteGauche = true;
    }


    //PORTE


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

    private void porteActivePourDroite()
    {
        gameObjectPorte.SetActive(true);
        gameObjectPorte2.SetActive(false);
        gameObjectPorte3.SetActive(true);
    }

    private void porteActivePourGauche()
    {
        gameObjectPorte.SetActive(true);
        gameObjectPorte2.SetActive(true);
        gameObjectPorte3.SetActive(false);
    }


    // BOUTON

    private void desactiveAllBouton()
    {
        gameobjectbp_bouclier.SetActive(false);
        gameobjectbp_combat.SetActive(false);
        gameobjectbp_des.SetActive(false);
    }

    private void activeAllBouton()
    {
        gameobjectbp_bouclier.SetActive(true);
        gameobjectbp_combat.SetActive(true);
        gameobjectbp_des.SetActive(true);
    }

    private void activeOnlyDesBouton()
    {
        gameobjectbp_bouclier.SetActive(false);
        gameobjectbp_combat.SetActive(false);
        gameobjectbp_des.SetActive(true);
    }

    // Egnime


    private void desactiveAllEgnime()
    {
        gameobjectEgnimeCal.SetActive(false);
        gameobjectEgnimeGeo.SetActive(false);
        gameobjectEgnimeintru.SetActive(false);
    }

    private void activeCalEgnime()
    {
        gameobjectEgnimeCal.SetActive(true);
        gameobjectEgnimeGeo.SetActive(false);
        gameobjectEgnimeintru.SetActive(false);

    }

    private void activeGeoEgnime()
    {
        gameobjectEgnimeGeo.SetActive(true);
        gameobjectEgnimeCal.SetActive(false);
        gameobjectEgnimeintru.SetActive(false);

    }

    private void activeIntruEgnime()
    {
        gameobjectEgnimeintru.SetActive(true);
        gameobjectEgnimeCal.SetActive(false);
        gameobjectEgnimeGeo.SetActive(false);

    }





    void Start()
    {

        PlayerPrefs.SetInt("etage", 1);
        randomiseLesPorte();
        desactiveAllEgnime();
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

