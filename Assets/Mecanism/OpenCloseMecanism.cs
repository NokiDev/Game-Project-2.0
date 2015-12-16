using UnityEngine;
using System.Collections;

public class OpenCloseMecanism : MonoBehaviour {

    // Use this for initialization
    public bool m_Open = false;

    public GameObject m_Mecanism;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        MecanismScript script= m_Mecanism.GetComponent<MecanismScript>()
            script.setActivated(m_Open);
	}

    void OnTriggerEnter(Collider2D coll){
        

    }

    void OnTriggerStay(Collider2D coll){
        if(coll.gameObject.tag == "Player"){
            if(Input.GetKey("Enter")){
                m_Open = !m_Open;
            }
        }
    }
}
