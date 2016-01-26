using UnityEngine;
using System.Collections;

public class PlayerStamina : MonoBehaviour {

    private float m_StaminaMax;
    private float m_CurrentStamina;
    private float m_StaminaLastUse;
    private bool m_Exausted;
    public float Stamina
    {
        get
        {
            return m_CurrentStamina;
        }

        set
        {
            m_CurrentStamina = value;
        }
    }

    PlayerCaracteristics playerCaracteristics;

    // Use this for initialization
    void Start()
    {
        playerCaracteristics = GetComponent<PlayerCaracteristics>();
        m_StaminaMax = playerCaracteristics.StaminaMax;
        m_CurrentStamina = m_StaminaMax;
        m_Exausted = false;
        m_StaminaLastUse = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - m_StaminaLastUse > 2.0f && m_CurrentStamina < m_StaminaMax && !m_Exausted)
        {
            m_CurrentStamina += 5f;
            if (m_CurrentStamina > m_StaminaMax)
                m_CurrentStamina = m_StaminaMax;
        }
        else if (Time.time - m_StaminaLastUse > 4.0f && m_CurrentStamina < m_StaminaMax)
            m_Exausted = false;
    }

    public void UseStamina(float staminaAmount)
    {
        m_CurrentStamina -= staminaAmount;
        m_StaminaLastUse = Time.time;
        if (m_CurrentStamina <= 0)
        {
            m_Exausted = true;
        }
    }

    public void RegenStamina(float staminaAmount)
    {
        m_CurrentStamina += staminaAmount;
        if (m_CurrentStamina > m_StaminaMax)
            m_CurrentStamina = m_StaminaMax;
    }
}
