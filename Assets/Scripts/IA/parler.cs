using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class parler : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    private List<string> discussion = new List<string>();
    private List<string> option1= new List<string>();
    private bool true1 = false;
    private List<string> option2 = new List<string>();
    private bool true2 = false;

    private int var;
    private bool isTalking = false;
    private bool pressedReturn = false;
    private bool isTrigger = false;

    // Use this for initialization
    void Start()
    {
        var = 0;
        discussion.Add("Bonjour jeune voyageur!");
        discussion.Add("ça va?");
        option1.Add("Cool, moi aussi!");
        option2.Add("pourquoi? :'(");
    }

    // Update is called once per frame
    void Update()
    {
        if (isTrigger)
        {
            Parler(discussion);

        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.tag == "Player")
        {
            isTrigger = true;
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.tag == "Player")
        {
            isTrigger = false;
        }
    }

    void Parler(List<string> paroles)
    {
        if (Input.GetKeyDown("return"))
        {
            pressedReturn = true;
        }

        if (var == paroles.Count)
        {
            DialogueManager.instance.afficherReponses("1:oui 2:non", player);


            if (Input.GetKey("1"))
            {
                true1 = true;
                
            }

            if (Input.GetKey("2"))
            {
                true2 = true;
                
            }
            if (true1)
            {
                DialogueManager.instance.afficherReponses(option1[0], this.gameObject);
                DialogueManager.instance.arreter();
                isTalking = false;
                if (Input.GetKey("return"))
                {
                    DialogueManager.instance.arreter();
                }

            }
            if (true2)
            {
                DialogueManager.instance.arreter();
                DialogueManager.instance.afficherReponses(option2[0], this.gameObject);
                isTalking = false;
                if (Input.GetKey("return"))
                {
                    DialogueManager.instance.arreter();
                }
            }
        }

        if (pressedReturn)
        {
            isTalking = true;

            if (var == paroles.Count )
            {
                var = 0;
                DialogueManager.instance.arreter();
                pressedReturn = false;
                return;
            }

            DialogueManager.instance.afficherParoles(paroles[var], this.gameObject);
            var++;
            pressedReturn = false;


        }
    }
}
