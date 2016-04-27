using UnityEngine;
using System.Collections;

public class collideDamage : DamageSource {
    
    // Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D coll){
        if(((1 << coll.gameObject.layer) &targetLayer.value) != 0){
            coll.gameObject.GetComponent<PlayerHealth>().TakeDamage(this);
        }
    }
}
