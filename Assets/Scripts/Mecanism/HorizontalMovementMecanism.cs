using UnityEngine;
using System.Collections;

public class HorizontalMovementMecanism : MecanismScript
{
    [SerializeField]
    private LayerMask m_Mask;

    public GameObject m_Plateform;

    private Transform m_AtWestCheck;
    const float k_AtWestRadius = .2f;
    [SerializeField]
    private bool m_AtWest;

    private Transform m_AtEastCheck;
    const float k_AtEastRadius = .2f;
    [SerializeField]
    private bool m_AtEast;

    [SerializeField]
    private bool m_GoEast = true;

    private Rigidbody2D m_Rigidbody2D;

    // Use this for initialization
    void Awake()
    {
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
            case MecaBehaviour.TIMER:
                TimerBehaviour();
                break;
            case MecaBehaviour.ONESHOT:
                OneShotBehaviour();
                break;
        }
    }

    void DefaultBehaviour()
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
    }

    void TimerBehaviour()
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

        }
    }

    void OneShotBehaviour()
    {
        m_GoEast = m_Activated;
        m_AtEast = Physics2D.OverlapCircle(m_AtEastCheck.position, k_AtEastRadius, m_Mask);
        m_AtWest = Physics2D.OverlapCircle(m_AtWestCheck.position, k_AtWestRadius, m_Mask);
        if((m_AtWest && !m_GoEast )|| m_AtEast && m_GoEast)
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
}
