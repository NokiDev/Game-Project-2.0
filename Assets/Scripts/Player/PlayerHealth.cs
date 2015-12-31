﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : EntityHealth {

    private Image healthBar;

    void Awake()
    {
        healthBar = healthBarGameObj.GetComponent<Image>();
        anim = GetComponent<Animator>();
        rigidBody2D = GetComponent<Rigidbody2D>();
        healthScale = healthBar.transform.localScale;
        currentHealth = maxHealth;
    }

    void Update()
    {
        if (damaged)
        {
            //Set la couleur de la barre en fonction de la vie du joueur 
            healthBar.material.color = Color.Lerp(Color.green, Color.red, 1 - currentHealth * 0.01f);

            // Set le scale de la barre de vie proportionnellement a ses points de vie
            healthBar.transform.localScale = new Vector3(healthScale.x * currentHealth * 0.01f, 1, 1);
        }

        if (currentHealth <= 0)
        {
            Death();
            // ... Active l'état de mort dans l'animator
            //anim.SetTrigger("Die");
        }
    }

    protected override void Death()
    {
        isDead = true;
    }
}
