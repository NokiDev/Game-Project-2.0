using UnityEngine;
using System.Collections;

public class SpikeAttack : DamageSource {


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnCollisionEnter2D(Collision2D coll){

		if (coll.gameObject.tag == "Player") {
			HealthManager healthManager = coll.gameObject.GetComponent<HealthManager>();
			healthManager.TakeDamage(this);
		}
	}
}
