using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpritePersonnageManager : MonoBehaviour
{

    public Sprite[] images;
    public int imageCourante;
    public float VIEMAX;
    public int DEGATMAX;
    public int RESISTANCEMAX;
    public int CHANCEMAX;
    public string NOMDUPERSO;
    public int LEVELUP;
    public int NIVEAU;

    public GameObject charactere;
    public GameObject couloir;
    public GameObject mort;
    public GameObject win;
    public GameObject bpSword;
    public GameObject bpShield;
    public GameObject bpDes;

    private float vie;
    private int degat;
    private int resistance;
    private int chance;
    private int Niveau;
    private int LVL;
    private string nomPerso;


    // Start is called before the first frame update
    void Start()
    {
        initialisation();
        mort.SetActive(false);
        win.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        levelUp();
    }

    public void initialisation()
    {
        setVie(VIEMAX);
        setDegat(DEGATMAX);
        setResistance(RESISTANCEMAX);
        setChance(CHANCEMAX);
        setNomPerso(NOMDUPERSO);
        charactere.GetComponent<Image>().sprite = images[imageCourante];
        setNiveau(NIVEAU);
    }



    
    public void levelUp()
    {
        if(this.LVL >= this.LEVELUP)
        {
            this.LVL -= LEVELUP;
            niveauUp();
            degatlvlUp();
            vielvlUp();
            resistancelvlUp();
        }
    }


    ////////// LVL  ////////// 
    public void setNiveau(int lvl)
    {
        this.Niveau = lvl;
    }

    public int getLvl()
    {
        return this.Niveau;
    }

    public void niveauUp()
    {
        this.Niveau += 1;
    }

    public void niveauDown()
    {
        this.Niveau -= 1;
    }

    public void degatlvlUp()
    {
        this.degat = this.degat * 1 + (this.Niveau / 100);
    }

    public void vielvlUp()
    {
        this.vie = this.vie * 1 + (this.Niveau / 100);
    }

    public void resistancelvlUp()
    {
        this.resistance = this.resistance * 1 + (this.Niveau / 100);
    }




    ////////// NOM PERSO  ////////// 
    public void setNomPerso(string nom)
    {
        this.nomPerso = nom;
    }

    public string getNomPerso()
    {
        return this.nomPerso;
    }




    ////////// VIE  ////////// 
    public void setVie(float vie)
    {
        this.vie = vie;
        estMort(vie);
    }

    public float getVie()
    {
        return this.vie;
    }

    public void tuEstMort()
    {
        //Gestion de la mort
        mort.SetActive(true);
        Debug.Log("Le hero est Mort");
    }

    public void prendDesDegat(int degat, float rand,int critique)
    {
        float vie = getVie();
        float degatAprendre;
        degatAprendre =degat* (1+(rand / 100) * critique);
        vie = ((vie * 1+(getResistance()/10)) - degatAprendre);
        Debug.Log(" vie :" + vie);
        setVie(vie);
        vie = 0;
    }

    private void perteDeVie(float vie, int degat, float rand, int critique)
    {
        vie = vie - (degat * rand / critique);
    }

    private void perteDeVieCritique(float vie, int degat, float rand, int critique)
    {
        vie = vie - (degat * 1+(rand / critique));
    }

    private void gagneVie(float vie, int resistance, float rand, int diviseur)
    {
        vie = vie + ((resistance/10) * (rand / diviseur));
        vieMaxVerif(vie);
    }

    private void gagneVieCritique(float vie, int resistance, float rand, int diviseur)
    {
        vie = vie + vie*(resistance * (rand / diviseur));
       vieMaxVerif(vie);
    }

    public void vieMaxVerif(float vie)
    {
        if (vie > this.VIEMAX)
        {
             vie = this.VIEMAX;
        }
    }

    public void estMort(float vie)
    {
        if (vie <= 0)
        {
            vie = 0;
            tuEstMort();
        }
    }



    ////////// ATTAQUE  ////////// 
    public void setDegat(int degat)
    {
        this.degat = degat ;
       
    }

    public int getDegat()
    {
        return this.degat;
        
    }

    public void attaque()
    {
        Debug.Log("La vie est de : " + getVie() + " avant la attaque");

        int rand = Random.Range(1, 100);

        Debug.Log("le rand : " + rand );
        if (rand < 10)
        {
            echecCritAttaque(rand);
        }
        else if (rand < 50)
        {
            echecAttaque(rand);
        }
        else if (rand >= 90)
        {
            reussiteCritAttaque(rand);
        }
        else if (rand >= 50)
        {
            reussiteAttaque(rand);
        }
        rand = 0;
        setDegat(DEGATMAX);

        Debug.Log("La vie est de : " + getVie() + " après la attaque");


    }

    public void echecCritAttaque(int rand)
    {
        prendDesDegat(getDegat(), rand,5) ;
        
    }

    public void echecAttaque(int rand)
    {
        prendDesDegat(getDegat(), rand, 1);
      
    }

    public void reussiteCritAttaque(int rand)
    {
        donnerDesDegat(50, rand, 2);

    }

    public void reussiteAttaque(int rand)
    {
        donnerDesDegat(50, rand, 1);
       
    }


    public void donnerDesDegat(float vieMonstre,float rand, int critique)
    {
        int degat = getDegat();
        vieMonstre = vieMonstre - degat+(degat * ((rand / 100) * critique));
        Debug.Log("Vie du monstre : " + vieMonstre);

        if (vieMonstre <= 0)
        {
            Debug.Log("monstre mort ! " );
            win.SetActive(true);
            Invoke("finDePartiMonstre", 2);
        }
        degat = 0;
    }


    private void finDePartiMonstre()
    {
        win.SetActive(false);
        bpSword.SetActive(false);
        bpShield.SetActive(false);
        bpDes.SetActive(false);

}


    ////////// RESISTANCE  ////////// 
    public void setResistance(int resistance)
    {
        this.resistance = resistance;
    }


    public int getResistance()
    {
        return this.resistance;
    }

    public void Def()
    {

        Debug.Log("La vie est de : " + getVie() + " avant la Def");

        int rand = Random.Range(0, 100);
        if (rand < 10)
        {
            echecCritDef(rand);
        }
        else if (rand < 50)
        {
            echecDef(rand);
        }
        else if (rand > 90)
        {
            reussiteCritDef(rand);
        }
        else if (rand >= 50)
        {
            reussiteDef();
        }

        Debug.Log("La vie est de : " + getVie() + " après la Def");


    }

    public void echecCritDef(float rand)
    {
        this.vie = this.vie - (this.degat * 1 + rand / 5);
        Debug.Log("echecCritDef");
    }

    public void echecDef(float rand)
    {
        this.vie = this.vie - (this.degat * rand / 50);
    }

    public void reussiteDef()
    {
        //Tu sort de la salle sans encombre
    }

    public void reussiteCritDef(float rand)
    {
       
    }




    ////////// CHANCE  ////////// 
    public int getChance()
    {
        return this.chance;
    }

    public void setChance(int Chance)
    {
        this.chance = Chance;
    }


    public void Des()
    {

        Debug.Log("La vie est de : " + getVie() + " avant le Des" );

        int rand = Random.Range(0, 100);
        if (rand < 10)
        {
            echecCritDes(rand);
        }
        else if (rand < 50)
        {
            echecDes(rand);
        }
 
        else if (rand >= 50)
        {
            reussiteDes(rand);
        }

        Debug.Log("La vie est de : " + getVie() + " après le Des");

    }

    public void echecCritDes(float rand)
    {
        perteDeVieCritique(this.vie, getDegat(), rand, 5);
    }

   

    public void echecDes(float rand)
    {
        perteDeVie(this.vie, getDegat(), rand, 1);
    }



    public void reussiteDes(int rand)
    {
        //Tu sort de la salle sans encombre
    }
}
