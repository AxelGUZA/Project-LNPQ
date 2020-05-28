using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangePorte : MonoBehaviour
{
    public Sprite[] spritePorte;
    public int textureCourante;

    public GameObject gameObjectPorte;
    public GameObject gameObjectPorte2;
    public GameObject gameObjectPorte3;
    private string nomdeLaPorte;

    private int ramdomNombre;


    void Start()
    {
        randomPorte();
        gameObjectPorte.GetComponent<Image>().sprite = spritePorte[this.textureCourante];
        this.nomdeLaPorte = gameObjectPorte.GetComponent<Image>().sprite.ToString();
        randomPorte();
        gameObjectPorte2.GetComponent<Image>().sprite = spritePorte[this.textureCourante];
        this.nomdeLaPorte = gameObjectPorte.GetComponent<Image>().sprite.ToString();
        randomPorte();
        gameObjectPorte3.GetComponent<Image>().sprite = spritePorte[this.textureCourante];
        this.nomdeLaPorte = gameObjectPorte.GetComponent<Image>().sprite.ToString();
    }

    public void randomiseLesPorte()
    {


        randomPorte();
        gameObjectPorte.GetComponent<Image>().sprite = spritePorte[this.textureCourante];
        this.nomdeLaPorte = gameObjectPorte.GetComponent<Image>().sprite.ToString();
        randomPorte();
        gameObjectPorte2.GetComponent<Image>().sprite = spritePorte[this.textureCourante];
        this.nomdeLaPorte = gameObjectPorte.GetComponent<Image>().sprite.ToString();
        randomPorte();
        gameObjectPorte3.GetComponent<Image>().sprite = spritePorte[this.textureCourante];
        this.nomdeLaPorte = gameObjectPorte.GetComponent<Image>().sprite.ToString();
    }




    public void randomPorte()
    {

        ramdomNombre = Random.Range(0, 100);

        if (ramdomNombre >= 0 && ramdomNombre <= 50)
            this.textureCourante = 1;
        else if (ramdomNombre > 50 && ramdomNombre <= 93)
            this.textureCourante = 2;
        else if (ramdomNombre > 93 && ramdomNombre <= 94)
            this.textureCourante = 3;
        else if (ramdomNombre > 94 && ramdomNombre <= 100)
            this.textureCourante = 4;


        switch (textureCourante)
        {
            case 1:
                textureCourante = 1;
                this.textureCourante %= spritePorte.Length;
                break;
            case 2:
                textureCourante = 2;
                this.textureCourante %= spritePorte.Length;
                break;

            case 3:
                textureCourante = 3;
                this.textureCourante %= spritePorte.Length;
                break;
            case 4:
                textureCourante = 4;
                this.textureCourante %= spritePorte.Length;
                break;
            case 5:
                textureCourante = 5;
                this.textureCourante %= spritePorte.Length;
                break;

            default:
                textureCourante = 0;
                this.textureCourante %= spritePorte.Length;
                break;


               
          
        }
        

       

        Debug.Log("Nom de la porte : " + nomdeLaPorte);
 
    }

    public void getNomDeLaPorte(){

        Debug.Log("Nom de la porte : " + nomdeLaPorte);
      
    }
}

