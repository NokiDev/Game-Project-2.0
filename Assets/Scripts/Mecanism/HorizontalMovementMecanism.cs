using UnityEngine;
using System.Collections;

public class HorizontalMovementMecanism : MecanismScript
{
    [SerializeField]
    private LayerMask m_Mask; //Masque sur lequel on va tester les collisions

    public GameObject m_Plateform; //Gameobject de la plateforme

    private Transform m_AtWestCheck; //Transform 
    const float k_AtWestRadius = .2f; //Rayon du cercle de collision lorsque la plateforme arrive au gameObject "West"
    [SerializeField]
    private bool m_AtWest;//Indique si la plateforme est arrivé au maximum a gauche

    private Transform m_AtEastCheck;//Transform
    const float k_AtEastRadius = .2f;//Rayon du cercle de collision lorsque la plateforme arrive au gameObject "East"
    [SerializeField]
    private bool m_AtEast;//Indique si la plateforme est arrivé au maximum à droite

    [SerializeField]
    private bool m_GoEast = true;//Indique la direction du mouvement de la plateforme

    private Rigidbody2D m_Rigidbody2D; // RigidBody de la plateforme

    // Use this for initialization
    void Awake()
    {
        m_Timer = 0f;
        m_Rigidbody2D = m_Plateform.GetComponent<Rigidbody2D>();

        m_AtEastCheck = transform.Find("East");
        m_AtWestCheck = transform.Find("West");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch(behaviour)
        {
            case MecaBehaviour.DEFAULT:
                DefaultBehaviour();
                break;
            case MecaBehaviour.LOOP:
                LoopBehaviour();
                break;
            case MecaBehaviour.TIMER:
                TimerBehaviour();
                break;
        }
    }

    void DefaultBehaviour()
    {
        m_GoEast = m_Activated;
        m_AtEast = Physics2D.OverlapCircle(m_AtEastCheck.position, k_AtEastRadius, m_Mask);
        m_AtWest = Physics2D.OverlapCircle(m_AtWestCheck.position, k_AtWestRadius, m_Mask);
        if ((m_AtWest && !m_GoEast) || m_AtEast && m_GoEast)
        {
            m_Rigidbody2D.velocity = new Vector2(0, 0);
        }
        else
        {
            if (m_GoEast)
                m_Rigidbody2D.velocity = new Vector2(5, 0);
            else
                m_Rigidbody2D.velocity = new Vector2(-5, 0);
        }
    }

    void TimerBehaviour()
    {
        if (m_Activated || m_Auto)
        {
            if(m_Timer < m_Delay)
            {
                m_Locked = true;
                m_AtEast = Physics2D.OverlapCircle(m_AtEastCheck.position, k_AtEastRadius, m_Mask);
                m_AtWest = Physics2D.OverlapCircle(m_AtWestCheck.position, k_AtWestRadius, m_Mask);
                if (m_AtEast)
                    m_GoEast = false;
                if (m_AtWest)
                    m_GoEast = true;

                if (m_GoEast)
                    m_Rigidbody2D.velocity = new Vector2(5, 0);
                else
                    m_Rigidbody2D.velocity = new Vector2(-5, 0);
            }
            else
            {
                m_Locked = false;
                m_Activated = false;
                m_Timer = 0f;
                m_Rigidbody2D.velocity = new Vector2(0, 0);
            }
            m_Timer += Time.deltaTime;
        }
    }

    void LoopBehaviour()
    {
        if (m_Activated || m_Auto)
        {
            m_AtEast = Physics2D.OverlapCircle(m_AtEastCheck.position, k_AtEastRadius, m_Mask);
            m_AtWest = Physics2D.OverlapCircle(m_AtWestCheck.position, k_AtWestRadius, m_Mask);
            if (m_AtEast)
                m_GoEast = false;
            if (m_AtWest)
                m_GoEast = true;

            if (m_GoEast)
                m_Rigidbody2D.velocity = new Vector2(5, 0);
            else
                m_Rigidbody2D.velocity = new Vector2(-5, 0);
        }
        else
        {
            m_Rigidbody2D.velocity = new Vector2(0, 0);
        }
    }
}
