using UnityEngine;
using System.Collections;

public abstract class MecanismScript : MonoBehaviour {

    [SerializeField]
    protected bool m_Locked; //Défini si l'activation du mécanisme est bloqué ou non
    protected bool m_Activated; // Défni si le mécanisme est activé ou non
    protected string behaviour; // Etat qui défini le comportement du mécanism
    [SerializeField]
    protected bool m_Auto; //Défini si le mécanisme est automatique ou non ou s'il nécessite un mecanisme d'activation (levier, bouttons etc..)

    public void setActivated(bool flag)
    {
        if(!m_Locked || !m_Activated)
        {
            m_Activated = flag;
        }
    }
}
