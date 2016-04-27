using UnityEngine;
using System.Collections;

public class EndTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            GameObject.Find("EndMenu").GetComponent<EndScript>().enabled = true;
        }
    }
}
