using UnityEngine;
using System.Collections;
using System;

public class BasicMovement : MovementBehaviour {

    // Use this for initialization
    void Start () {
        base.MovementStart(); 
        type = PlayerMovement.MovementState.NONE;
    }

    void Update()
    {
        base.MovementUpdate();
    }

    void FixedUpdate()
    {
        base.MovementFixedUpdate();
    }

    public override void Behaviour(float moveH, float moveV)
    {
        bool crouch = Input.GetKey(KeyCode.LeftControl);
        // Si le joueur est accroupi on vérifie si il peut se lever
        if (!crouch && m_Anim.GetBool("Crouch"))
        {
            // Si le joueur est bloqué par le plafond, alors il reste accroupi
            if (Physics2D.OverlapCircle(m_CeilingCheck.position, k_CeilingRadius, m_FloorMask))
            {
                crouch = true;
            }
        }

        // Set si le joueur est accroupi dans l'animator
        m_Anim.SetBool("Crouch", crouch);

        //Controle seulement si le player touche le sol ou qu'il peut bouger en l'air
        if (Grounded || m_AirControl)
        {
            // Réduit la vitesse si le personnage est accroupi
            moveH = (crouch ? moveH * m_CrouchSpeed : moveH);

            // Set la vitesse(absolue) du joueur dans l'animator
            m_Anim.SetFloat("Speed", Mathf.Abs(moveH));

            m_Anim.SetFloat("vSpeed", Mathf.Abs(moveV));

            m_Rigidbody2D.velocity = new Vector2(moveH * m_MaxSpeed, m_Rigidbody2D.velocity.y);

            // Vérifie si il faut inverser l'image si l'input est droite et que le joueur regarde a gauche
            if (moveH > 0 && !m_FacingRight)
            {
                // ... flip the player.
                Flip();
            }
            // Sinon si l'input est gauche et que le joueur regarde a droite
            else if (moveH < 0 && m_FacingRight)
            {
                // ... flip the player.
                Flip();
            }
        }

        // Si le player peut sauter
        if (Grounded && m_Jump && m_Anim.GetBool("Ground"))
        {
            // On ajoute une force vertical au joueur pour le saut
            Grounded = false;
            m_Anim.SetBool("Ground", false);
            m_Anim.SetTrigger("Jump");
            m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
        }
        m_Jump = false;
        // Set la vitesse verticale pour les sauts
        m_Anim.SetFloat("vSpeed", m_Rigidbody2D.velocity.y);
    }

    public override void Stop()
    {
        
    }
}
