using UnityEngine;
using System.Collections;

public class LeverMecanism : MonoBehaviour
{

    // Use this for initialization
    public bool m_Open = false;//Indique si le levier est tiré ou non 
    private bool triggerPlayer = false;//Indique si le joueur est sur le levier

    public GameObject m_Mecanism;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (triggerPlayer)
        {
            if (Input.GetKeyUp(KeyCode.Return))
            {
                m_Open = !m_Open;
            }
        }
        MecanismScript script = m_Mecanism.GetComponent<MecanismScript>();
        script.setActivated(m_Open);
    }

    void OnTriggerEnter2D(Collider2D coll)
    {


    }

    void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            triggerPlayer = true;
        }
    }
}
