using UnityEngine;
using System.Collections;

public abstract class EntityHealth : MonoBehaviour {

    public int maxHealth = 10; //Vie de l'entite
    public int currentHealth;
    public float invicibilityTime = 2f;//Temps entre deux coups

    public float hurtForce = 10f; //Force ajouté lorsque le joueur prends un coup

    public GameObject healthBarGameObj; //Référence au sprite de la barre de vie
    //protected SpriteRenderer healthBar;
    protected float lastHitTime;//Dernière fois ou le joueur s'est fait touché
    protected Vector3 healthScale;//Scale pour la bare de vie
    protected Animator anim;//Référence a l'animator
    protected Rigidbody2D rigidBody2D; //Référence au rigidbody

    public bool isDead;
    protected bool damaged;
    
    //Fonction public appelé lors d'une prise de dégat
    public void TakeDamage(DamageSource damageSource)
    {
        if (Time.time > lastHitTime + invicibilityTime)
        {
            //Si le joueur a toujours de la vie
            if (currentHealth > 0f)
            {
                damaged = true;
                // ... prends des dégat et reset le temps du dernier coup pris
                // Creer un vecteur de l'enemi jusqu'au joueur plus un boost up
                Vector3 hurtVector = transform.position - damageSource.transform.position + Vector3.up * 5f;

                // Ajoute une force en direction du vecteur multiplié par la force de dégats
                rigidBody2D.AddForce(hurtVector * damageSource.hurtForce);

                // Réduit la vie du joueur de 10
                currentHealth -= damageSource.damage;

                lastHitTime = Time.time;

                if(currentHealth <= 0 && !isDead)
                {
                    Death();
                }
            }
        }
    }

    protected virtual void Death()
    {
        isDead = true;
    }
}
