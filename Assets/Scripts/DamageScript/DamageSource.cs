﻿using UnityEngine;
using System.Collections;

public abstract class DamageSource : MonoBehaviour {

    /**/
    public float range = 2f; //Portée de la source de dégats
    public int damage = 3; //Dégats de la source
    public float hurtForce = 50f; //Force de poussée lors d'une prise de dégats
    public float delay = 1f; //Delai entre deux attaque
    public LayerMask targetLayer;

    protected bool attack;
    protected bool attackLocked;

    public enum effect {NORMAL, POISON, STUN, FIRE, ICE};

    private void UnlockAttack()
    {
        attackLocked = false;
    }

    protected void LockAttack()
    {
        attackLocked = true;
        Invoke("UnlockAttack", delay);
    }

}
