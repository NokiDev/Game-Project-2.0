using UnityEngine;
using System.Collections;

public class ProjectileDamageSource : DamageSource {

    public float timeToLive;
    
	// Use this for initialization
	void Start () {
        Destroy(this.gameObject, timeToLive);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (((1 << coll.gameObject.layer) & targetLayer.value) != 0)//Teste le layer en fonction du layerMask, si ce n'est pas = a 0 le mask correspond  
        {
            coll.gameObject.GetComponent<HealthManager>().TakeDamage(this); 
            Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, range, targetLayer);
            foreach (Collider2D enemy in enemies)
            {
                enemy.gameObject.GetComponent<HealthManager>().TakeDamage(this);
            }
            Destroy(this.gameObject);
        }
    }
}
