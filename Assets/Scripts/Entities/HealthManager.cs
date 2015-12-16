﻿using UnityEngine;
using System.Collections;

public class HealthManager : MonoBehaviour {

    public float health = 10f; //Vie de l'entite
    public float invicibilityTime = 2f;//Temps entre deux coups

    public float hurtForce = 10f; //Force ajouté lorsque le joueur prends un coup

    public GameObject healthBarGameObj; //Référence au sprite de la barre de vie
    protected SpriteRenderer healthBar;
    protected float lastHitTime;//Dernière fois ou le joueur s'est fait touché
    protected Vector3 healthScale;//Scale pour la bare de vie
    protected Animator anim;//Référence a l'animator
    protected Rigidbody2D rigidBody2D; //Référence au rigidbody


    void Awake()
    {
        healthBar = healthBarGameObj.GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        rigidBody2D = GetComponent<Rigidbody2D>();
        healthScale = healthBar.transform.localScale;
    }

    void Update()
    {
        
        if(health <=0)
        {
            // ... Active l'état de mort dans l'animator
            Destroy(gameObject);
            //anim.SetTrigger("Die");
        }
    }
    
    //Fonction public appelé lors d'une prise de dégat
    public void TakeDamage(DamageSource damageSource)
    {
        if (Time.time > lastHitTime + invicibilityTime)
        {
            //Si le joueur a toujours de la vie
            if (health > 0f)
            {
                // ... prends des dégat et reset le temps du dernier coup pris
                // Creer un vecteur de l'enemi jusqu'au joueur plus un boost up
                Vector3 hurtVector = transform.position - damageSource.transform.position + Vector3.up * 5f;

                // Ajoute une force en direction du vecteur multiplié par la force de dégats
                rigidBody2D.AddForce(hurtVector * damageSource.hurtForce);

                // Réduit la vie du joueur de 10
                health -= damageSource.damage;

                // Update la barre de vie
                UpdateHealthBar();
                lastHitTime = Time.time;
            }
        }
    }

    protected virtual void UpdateHealthBar()
    {
        //Set la couleur de la barre en fonction de la vie du joueur 
        healthBar.material.color = Color.Lerp(Color.green, Color.red, 1 - health * 0.01f);

        // Set le scale de la barre de vie proportionnellement a ses points de vie
        healthBar.transform.localScale = new Vector3(healthScale.x * health * 0.01f, 1, 1);

    }
}
