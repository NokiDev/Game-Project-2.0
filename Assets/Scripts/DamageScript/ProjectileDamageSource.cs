using UnityEngine;
using System.Collections;

public class ProjectileDamageSource : DamageSource {

    public float m_TimeToLive;
    public float m_Speed;

    private Rigidbody2D m_RigidBody2D;
    
	// Use this for initialization
	void Start () {
        m_RigidBody2D = GetComponent<Rigidbody2D>();
        Destroy(this.gameObject, m_TimeToLive);
	}
	
	// Update is called once per frame
	void Update ()
    {
        int coefDir = 1;
        if (transform.localScale.x > 0)
            coefDir = -1;
        m_RigidBody2D.velocity = new Vector3(coefDir * m_Speed, 0);
	}

    void FixedUpdate()
    {

    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (((1 << coll.gameObject.layer) & targetLayer.value) != 0)//Teste le layer en fonction du layerMask, si ce n'est pas = a 0 le mask correspond  
        {
            if(coll.gameObject.tag == "Player")
            {
                coll.gameObject.GetComponent<PlayerHealth>().TakeDamage(this);
                Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, range, targetLayer);
                foreach (Collider2D enemy in enemies)
                {
                    if(enemy.tag == "Enemies")
                    {
                        enemy.gameObject.GetComponent<PlayerHealth>().TakeDamage(this);
                    }
                }
                Destroy(this.gameObject);
            }
        }
    }
}
