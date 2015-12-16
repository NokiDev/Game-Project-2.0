﻿using UnityEngine;
using System.Collections;

public class damageBDF : DamageSource {

    // Use this for initialization
    void Start () {
        Destroy(this.gameObject, 3f);
    }
	
	// Update is called once per frame
	void Update () {
        this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-5, 0);
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
       if( coll.gameObject.tag == "Player")
        {
            HealthManager healthManager = coll.gameObject.GetComponent<HealthManager>();
            healthManager.TakeDamage(this);
        }
    }
}