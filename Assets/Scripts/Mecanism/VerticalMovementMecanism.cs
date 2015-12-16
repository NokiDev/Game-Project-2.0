﻿using UnityEngine;
using System.Collections;

public class VerticalMovementMecanism : MecanismScript {

    [SerializeField]
    private LayerMask m_Mask;

    private GameObject m_Plateform;

    private Transform m_AtBotCheck;
    const float k_AtBotRadius = .2f;
    [SerializeField]
    private bool m_AtBot;

    private Transform m_AtTopCheck;
    const float k_AtTopRadius = .2f;
    [SerializeField]
    private bool m_AtTop;

    [SerializeField]
    private bool m_GoTop = false;

    private Rigidbody2D m_Rigidbody2D;

    // Use this for initialization
    void Awake()
    {
        m_Plateform = GameObject.Find("Plateform");
        m_Rigidbody2D = m_Plateform.GetComponent<Rigidbody2D>();

        m_AtTopCheck = transform.Find("Top");
        m_AtBotCheck = transform.Find("Bot");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch (behaviour)
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
            m_AtTop = Physics2D.OverlapCircle(m_AtTopCheck.position, k_AtTopRadius, m_Mask);
            m_AtBot = Physics2D.OverlapCircle(m_AtBotCheck.position, k_AtBotRadius, m_Mask);
            if (m_AtTop)
                m_GoTop = false;
            if (m_AtBot)
                m_GoTop = true;

            if (m_GoTop)
                m_Rigidbody2D.velocity = new Vector2(0, 5);
            else
                m_Rigidbody2D.velocity = new Vector2(0, -5);
        }
    }

    void TimerBehaviour()
    {
        if (m_Activated || m_Auto)
        {
            m_AtTop = Physics2D.OverlapCircle(m_AtTopCheck.position, k_AtTopRadius, m_Mask);
            m_AtBot = Physics2D.OverlapCircle(m_AtBotCheck.position, k_AtBotRadius, m_Mask);
            if (m_AtTop)
                m_GoTop = false;
            if (m_AtBot)
                m_GoTop = true;

            if (m_GoTop)
                m_Rigidbody2D.velocity = new Vector2(0, 5);
            else
                m_Rigidbody2D.velocity = new Vector2(0, -5);
        }
    }

    void OneShotBehaviour()
    {

        m_GoTop = m_Activated;
        m_AtTop = Physics2D.OverlapCircle(m_AtTopCheck.position, k_AtTopRadius, m_Mask);
        m_AtBot = Physics2D.OverlapCircle(m_AtBotCheck.position, k_AtBotRadius, m_Mask);
        if ((m_AtBot && !m_GoTop) || (m_AtTop && m_GoTop))
        {
            m_Rigidbody2D.velocity = new Vector2(0, 0);
        }
        else
        {
            if (m_GoTop)
                m_Rigidbody2D.velocity = new Vector2(0, 5);
            else
                m_Rigidbody2D.velocity = new Vector2(0, -5);
        }
    }
}
