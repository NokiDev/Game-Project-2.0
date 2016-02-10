using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class parler : MonoBehaviour
{

    private List<string> discussion = new List<string>();
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
    }

    // Update is called once per frame
    void Update()
    {
        if (isTrigger)
        {
            if (Input.GetKeyDown("return"))
            {
                pressedReturn = true;
            }
            if (pressedReturn)
            {
                //Debug.Log(var);
                isTalking = true;
                if (var == discussion.Count)
                {
                    var = 0;
                    DialogueManager.instance.arreter();
                    pressedReturn = false;
                    return;
                }
                DialogueManager.instance.afficherParoles(discussion[var], this.gameObject);

                var++;
                pressedReturn = false;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.tag == "Player")
        {
            isTrigger = true;
        }
    }

    void OnTriggerStay2D(Collider2D player)
    {
        
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.tag == "Player")
        {
            isTrigger = false;
        }
    }
}
