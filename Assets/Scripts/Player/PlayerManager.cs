using UnityEngine;
using System.Collections;

public class PlayerManager : EntityManager {

    PlayerCaracteristics m_Caracteristics;
    PlayerStamina m_StaminaManager;
    PlayerHealth m_HealthManager;

	// Use this for initialization
	void Awake () {
        m_Caracteristics = GetComponent<PlayerCaracteristics>();
        m_Caracteristics.enabled = true;
        m_StaminaManager = GetComponent<PlayerStamina>();
        m_StaminaManager.enabled = true;
        m_HealthManager = GetComponent<PlayerHealth>();
        m_HealthManager.enabled = true;
        GetComponent<PlayerSpell>().enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
