using UnityEngine;
using System.Collections;

public class OpenCloseMecanism : MonoBehaviour {

    // Use this for initialization
    public bool m_Open = false;
    private bool triggerPlayer = false;

    public GameObject m_Mecanism;

	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        if (triggerPlayer)
        {
            if (Input.GetKeyUp(KeyCode.Return))
            {
                print("KEY DOWN");
                m_Open = !m_Open;
            }
        }
        MecanismScript script = m_Mecanism.GetComponent<MecanismScript>();
        script.setActivated(m_Open);
    }

    void OnTriggerEnter2D(Collider2D coll){
        

    }

    void OnTriggerStay2D(Collider2D coll){
        if(coll.gameObject.tag == "Player"){
            triggerPlayer = true;
        }
    }
}
