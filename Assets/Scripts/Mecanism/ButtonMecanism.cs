using UnityEngine;
using System.Collections;

public class ButtonMecanism : MonoBehaviour
{

    // Use this for initialization
    public bool m_Press = false;//Indique si le bouton est préssé
    private bool triggerPlayer = false;//Indique si le joueur est bien sur le bouton

    public GameObject m_Mecanism;//Mecanisme à activer

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (m_Press)
            m_Press = false;
        if (triggerPlayer)
        {
            if (Input.GetKeyUp(KeyCode.Return))
            {
                m_Press = true;
            }
        }
        MecanismScript script = m_Mecanism.GetComponent<MecanismScript>();
        script.setActivated(m_Press);
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
