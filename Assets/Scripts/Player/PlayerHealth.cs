using UnityEngine;
using System.Collections;

public class PlayerHealth : HealthManager {

    PlayerCaracteristics m_Caracteristics;
	// Use this for initialization
	void Start () {
        m_Caracteristics = GetComponent<PlayerCaracteristics>();
        m_RigidBody = GetComponent<Rigidbody2D>();
        m_Health = m_Caracteristics.Health;
	}

    // Update is called once per frame
    void Update()
    {
        if (m_Health < 0)
        {
            //m_Manager.Death();
        }
    }

    public new void TakeDamage(DamageSource damageSource)
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
                    m_Health = 0;
                    //m_Manager.Death();
                }
                m_Caracteristics.Health = m_Health;
            }
        }
    }
}
