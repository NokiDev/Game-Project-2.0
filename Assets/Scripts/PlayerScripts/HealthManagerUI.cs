using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthManagerUI : HealthManager {

    private Image healthBar;

    void Awake()
    {
        healthBar = healthBarGameObj.GetComponent<Image>();
        anim = GetComponent<Animator>();
        rigidBody2D = GetComponent<Rigidbody2D>();
        healthScale = healthBar.transform.localScale;
    }

    protected override void UpdateHealthBar()
    {
        //Set la couleur de la barre en fonction de la vie du joueur 
        healthBar.material.color = Color.Lerp(Color.green, Color.red, 1 - health * 0.01f);

        // Set le scale de la barre de vie proportionnellement a ses points de vie
        healthBar.transform.localScale = new Vector3(healthScale.x * health * 0.01f, 1, 1);

    }
}
