using UnityEngine;
using System.Collections;

public abstract class MecanismScript : MonoBehaviour {

    [SerializeField]
    protected bool m_Locked; //Défini si l'activation du mécanisme est bloqué ou non
    [SerializeField]
    protected bool m_Activated; // Défni si le mécanisme est activé ou non
    [SerializeField]
    protected float m_Delay; //Défini la durée d'activation
    [SerializeField]
    protected float m_Timer; //Sert à compter le temps écoulé 
    public enum MecaBehaviour{DEFAULT, LOOP, TIMER}//Enumération des différents comportements d'un mécanisme
    [SerializeField]
    protected MecaBehaviour behaviour = MecaBehaviour.DEFAULT; // Etat qui défini le comportement du mécanisme
    [SerializeField]
    protected bool m_Auto; //Défini si le mécanisme est automatique ou non ou s'il nécessite un mecanisme d'activation (levier, bouttons etc..)

    public void setActivated(bool flag)
    {
        if(m_Locked == false)
        {
            m_Activated = flag;
        }
    }

    public void setBehaviour(MecaBehaviour bvr)
    {
        behaviour = bvr;
    }
}
