﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EngimeCalMental : MonoBehaviour
{
    public Sprite[] biere;
    public Text num1;
    public Text num2;
    public Text multiAffiche;
    public GameObject image1;
    public GameObject image2;
    public GameObject canvas;
    public InputField inputField;

    private int numero1;
    private int numero2;
    private float total = 0;
    private string multiplicateur;
    


    // Start is called before the first frame update
    void Start()
    {
            lanceEngime();
    }

    // Update is called once per frame
    void Update()
    {
       
        
    }

    private void lanceEngime()
    {
        image2.GetComponent<Image>().sprite = biere[0];
        randomMultiplicateur(this.multiAffiche, this.multiplicateur);
    }

    private void randomMultiplicateur(Text multiAffiche, string multiplicateur)
    {
        randomChiffre();

        int rand = Random.Range(1,3);
        this.total = 0;
        switch (rand)
        {
            case 1:
                multiAffiche.text = "-";
                multiplicateur = "-";
                this.total = this.numero1 - this.numero2;
                image2.GetComponent<Image>().sprite = biere[1];


                break;
            case 2:
                multiAffiche.text = "+";
                multiplicateur = "+";
                this.total = this.numero1 + this.numero2;
                break;
            case 3:
                multiAffiche.text = "x";
                multiplicateur = "x";
                this.total = this.numero1 * this.numero2;
                break;
        }

    }

    public void verifRep()
    {
        float totalAVerif;
        float.TryParse(this.inputField.textComponent.text, out totalAVerif);
        Debug.Log("total a verifer = "  + totalAVerif + " et le vrai total = " + this.total);
        if(this.total == totalAVerif)
        {
            //Nous devron retrouver ici les bonus
            Debug.Log("exemple :+50 d'or");
            finEngime(this.canvas);
        }
        else
        {
            //Nous devrons trouver ici les malus
            Debug.Log("exemple :-50 d'or");
            finEngime(this.canvas);

        }
    }

    private void finEngime(GameObject canvas)
    {
        canvas.SetActive(false);
        
        lanceEngime();
    }

    private void randomChiffre()
    {
        this.numero1 = Random.Range(1, 100);
        this.numero2 = Random.Range(1, 100);
        num1.text = numero1.ToString();
        num2.text = numero2.ToString();
       

    }


}