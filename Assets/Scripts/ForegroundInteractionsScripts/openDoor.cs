using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class openDoor : MonoBehaviour {

    public string dest = "";

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnTriggerStay2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            if (Input.GetKey("up"))
            {
                open();
            }
        }
    }

    void open()
    {
        SceneManager.LoadScene(dest);
    }
}
