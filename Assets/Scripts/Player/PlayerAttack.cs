using UnityEngine;
using System.Collections;


public class PlayerAttack : DamageSource {

    private Animator anim;

    private float m_staminaCost = 3f;
    private float m_damageMultiplier = 0.3f;
    private Combos m_Combo;

    private int nbComboMax = 3;
    private float interval = 0.2f;
    private float comboTimer = 0.0f;
    private int nbCombo = 0;

    PlayerComboManager playerComboScript;
    PlayerStamina m_PlayerStamina;

	// Use this for initialization
	void Awake () {
        playerComboScript = GetComponentInParent<PlayerComboManager>();
        m_PlayerStamina = GetComponentInParent<PlayerStamina>();
        m_Combo = new Combos(this, m_damageMultiplier, m_staminaCost);
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        comboTimer += Time.deltaTime;
        if(Input.GetButton("Sword") && !attackLocked)
        {
            if(nbCombo == 0 || comboTimer >=interval)
            {
                comboTimer = 0.0f;
                attack = true;
                nbCombo++;
                if(nbCombo == nbComboMax)
                {
                    nbCombo = 0;
                    LockAttack();
                }
            }            
        }
	}

    void FixedUpdate()
    {
        if(attack)
        {
            anim.SetTrigger("Attack");
            //Attack();
            attack = false;
        }
    }

    void  Attack()
    {
       /* Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, range, targetLayer);
        foreach(Collider2D enemy in enemies)
        {
            playerComboScript.addCombo(m_Combo);
            m_PlayerStamina.RegenStamina(1f);
            EntityHealth healthManager = enemy.gameObject.GetComponent<EntityHealth>();
            healthManager.TakeDamage(this);
        }*/
    }

    void OnTriggerEnter2D(Collision coll)
    {
        playerComboScript.addCombo(m_Combo);
        m_PlayerStamina.RegenStamina(1f);
        EntityHealth healthManager = coll.gameObject.GetComponent<EntityHealth>();
        healthManager.TakeDamage(this);
    }
}
