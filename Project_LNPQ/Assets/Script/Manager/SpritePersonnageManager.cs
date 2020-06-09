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
        Debug.Log("Vie set a = " + this.vie);
    }

    public float getVie()
    {
        return this.vie;
    }

    public void tuEstMort()
    {
        //Gestion de la mort
        Debug.Log("Le hero est Mort");
    }

    public void regagneDesPV(int pvUp)
    {
        this.vie += pvUp;
        if (this.vie > VIEMAX)
        {
            this.vie = VIEMAX;
        }
    }

    public void prendDesDegat(int degat, int rand,int critique)
    {
        float vie = getVie();
        float degatAprendre;
        degatAprendre = degat * ((rand / 100) * critique);
        Debug.Log(" Alors :" +
            " \n - degat = "+ degat +
            " \n - rand = " + rand+
             " \n - critique = " + critique+
             "\n ("+degat + "* (("+ rand + " /100) * "+ critique + ")) = " + degatAprendre);
        vie = ((vie + vie*(getResistance()/100)) - degatAprendre);
        Debug.Log(" vie :" + vie);
       setVie(vie);
        if (vie <= 0)
        {
            tuEstMort();
        }
        vie = 0;
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

        int rand = Random.Range(1, 10);

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



    public void donnerDesDegat(float vieMonstre,int rand, int critique)
    {
        int degat = getDegat();
        vieMonstre = vieMonstre - degat+(degat * ((rand / 100) * critique));
        Debug.Log("Vie du monstre : " + vieMonstre);
        degat = 0;
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

    public void echecCritDef(int rand)
    {
        this.vie = this.vie - (this.degat * 1 + rand / 5);
        Debug.Log("echecCritDef");
    }

    public void echecDef(int rand)
    {
        this.vie = this.vie - (this.degat * rand / 50);
    }

    public void reussiteDef()
    {
        //Tu sort de la salle sans encombre
    }

    public void reussiteCritDef(int rand)
    {
        this.vie = this.vie + (this.resistance * rand / 50);
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

    public void echecCritDes(int rand)
    {
        this.vie = this.vie - (this.degat * 1 + rand / 5);
    }

    public void echecDes(int rand)
    {
        this.vie = this.vie - (this.degat * rand / 50);
    }

    public void reussiteDes(int rand)
    {
        //Tu sort de la salle sans encombre
    }
}
