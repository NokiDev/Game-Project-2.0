using UnityEngine;
using System.Collections;

public class MecanismScript : MonoBehaviour {

    private bool m_Locked; //Défini si l'activation du mécanisme est bloqué ou non
    private bool m_Activated; // Défni si le mécanisme est activé ou non

    public BehaviourMecanism behaviour;

    public void setActivated(bool flag)
    {
        if(!m_Locked || !m_Activated)
        {
            m_Activated = flag;
        }
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (m_Activated)
        {
            behaviour.update();
        }
	}

}
