using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    private int marge=1;
    public GameObject bulle;
    public GameObject bulleJoueur;
    public static DialogueManager instance;


	// Use this for initialization
	void Start () {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

        bulle.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
       
	}

    public void afficherParoles(string paroles, GameObject pnj)
    {
        bulle.SetActive(true);
        bulle.GetComponentInChildren<TextMesh>().text = paroles;
        bulle.gameObject.GetComponent<Transform>().position = new Vector2(pnj.transform.position.x, (pnj.gameObject.GetComponent<Collider2D>().bounds.size.y)+marge);

    }
    public void afficherReponses(string paroles, GameObject joueur)
    {
        bulleJoueur.SetActive(true);
        bulleJoueur.GetComponentInChildren<TextMesh>().text = paroles;
        bulleJoueur.gameObject.GetComponent<Transform>().position = new Vector2(joueur.transform.position.x, (joueur.gameObject.GetComponent<Collider2D>().bounds.size.y) + marge);
    }

    public void arreter()
    {
        bulle.SetActive(false);

    }

}
