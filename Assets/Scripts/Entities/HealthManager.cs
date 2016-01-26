using UnityEngine;
using System.Collections;

public class HealthManager : MonoBehaviour {

    public float m_InvicibilityTime;

    protected float m_HealthMax = 100; //Health Max
    protected float m_Health; //Health;
    protected bool m_Damaged;

    protected float m_LastHitTime;

    protected Rigidbody2D m_RigidBody;
    protected EntityManager m_Manager;
    
    public float Health
    {
        get
        {
            return m_Health;
        }

        set
        {
            m_Health = value;
        }
    }

    public float HealthMax
    {
        get
        {
            return m_HealthMax;
        }

        set
        {
            m_HealthMax = value;
        }
    }

    void Awake()
    {
        m_Health = m_HealthMax;
    }
    // Use this for initialization
    void Start () {
        //Init References
        m_RigidBody = GetComponent<Rigidbody2D>();
        m_Manager = GetComponent<EntityManager>();
	}
	
	// Update is called once per frame
	void Update () {
	    if(m_Health < 0)
        {
            m_Manager.Death();
        }
	}

    public void TakeDamage(DamageSource damageSource)
    {
        if (Time.time > m_LastHitTime + m_InvicibilityTime)
        {
            //Si le joueur a toujours de la vie
            if (Health > 0f)
            {
                m_Damaged = true;
                // ... prends des dégat et reset le temps du dernier coup pris
                // Creer un vecteur de l'enemi jusqu'au joueur plus un boost up
                Vector3 hurtVector = transform.position - damageSource.transform.position + Vector3.up * 5f;

                // Ajoute une force en direction du vecteur multiplié par la force de dégats
                m_RigidBody.AddForce(hurtVector * damageSource.hurtForce);

                // Réduit la vie du joueur de 10
                m_Health -= damageSource.damage;

                m_LastHitTime = Time.time;

                if (m_Health <= 0)
                {
                    m_Manager.Death();
                }
            }
        }
    }

    public bool isDead()
    {
        return Health > 0 ? false : true;
    }
}
