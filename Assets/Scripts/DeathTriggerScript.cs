using UnityEngine;
using System.Collections;

public class DeathTriggerScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            //Display Game Over
            GameObject.Find("GameOverMenu").GetComponent<GameOverScript>().enabled = true;

        }
        else if (coll.gameObject.tag == "Enemies")
        {
            Destroy(coll.gameObject);
        }
    }
}
