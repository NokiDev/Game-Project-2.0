using UnityEngine;
using System.Collections;

public class Combos {

    DamageSource m_DamageSource;
    private float m_StaminaCost;
    private float m_DamageMultiplier;

    public float DamageMultiplier
    {
        get
        {
            return m_DamageMultiplier;
        }

        set
        {
            m_DamageMultiplier = value;
        }
    }

    public float StaminaCost
    {
        get
        {
            return m_StaminaCost;
        }

        set
        {
            m_StaminaCost = value;
        }
    }

    public Combos(DamageSource damageSrc, float damageMultiplier, float staminaCost)
    {
        m_DamageSource = damageSrc;
        m_DamageMultiplier = damageMultiplier;
        StaminaCost = staminaCost;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
