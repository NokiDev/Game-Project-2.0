﻿using UnityEngine;
using UnityEditor;
using System.Collections;
using System;

public class FireballSpell : Spell {

    private GameObject m_FireBall; //Préfab de la boule de feu

    private GameObject m_Master; // GameObject maitre de la boule de feu (celui qui possede le sort)

    public FireballSpell(GameObject boss)
    {
        m_Master = boss;
        //Charge le préfab de la boule de feu à l'emplacement précisé
        m_FireBall = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Spells/Fireball.prefab", typeof(GameObject));
        //Initialise les infos du sorts
        m_Name = "Fireball";
        m_Type = SpellType.PROJECTILE;
        m_CoolDown = 0.3f;
        inCooldown = false;
        m_Timer = 0f;
        staminaCost = 10f;
        comboDamageMultiplier = 1f;
        combo = new Combos(m_FireBall.GetComponent<DamageSource>(), comboDamageMultiplier, staminaCost);
    }

    public override void init () {
        
	}

    // Update is called once per frame
    void Update () {
        
	}

    //Comportement de la boule de feu
    protected override void ProjectileBehaviour()
    {
        m_Timer = Time.time;
        inCooldown = true;
        float facingCoeff = 1;
        GameObject ball = MonoBehaviour.Instantiate(m_FireBall, new Vector3(m_Master.transform.position.x, m_Master.transform.position.y, m_Master.transform.position.z), Quaternion.identity) as GameObject;
        if (m_Master.transform.localScale.x > 0)
        {
            facingCoeff = -1;
        }
        ball.transform.localScale = new Vector3(facingCoeff * ball.transform.localScale.x, ball.transform.localScale.y, ball.transform.localScale.z);
    }
}
