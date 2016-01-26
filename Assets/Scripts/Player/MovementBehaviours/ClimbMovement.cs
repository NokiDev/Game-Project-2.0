using UnityEngine;
using System.Collections;
using System;

public class ClimbMovement : MovementBehaviour {

    bool canJump = true;
    // Use this for initialization
    void Start () {
        base.MovementStart();
        m_Rigidbody2D.gravityScale = 0f;
        Collider2D[] colliders = GetComponents<Collider2D>();
        foreach (Collider2D coll in colliders)
        {
            coll.isTrigger = true;
        }
        m_Anim.SetBool("Climb", true);
        type = PlayerMovement.MovementState.CLIMB;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        base.MovementFixedUpdate();
    }

    void Update () {
        base.MovementUpdate();
	}

    public override void Behaviour(float moveH, float moveV)
    {
        m_Rigidbody2D.velocity = new Vector2(moveH * 5f, moveV * 7f);
        // Si le player peut sauter
        if(canJump && m_Jump)
        {
            m_Anim.SetBool("Ground", false);
            m_Anim.SetTrigger("Jump");
            canJump = false;
            m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
            GetComponent<PlayerMovement>().ChangeMovementState(PlayerMovement.MovementState.NONE);
        }
        // Set la vitesse verticale pour les sauts
        m_Anim.SetFloat("vSpeed", m_Rigidbody2D.velocity.y);
    }

    public override void Stop()
    {
        if(m_Rigidbody2D != null)
        {
            m_Rigidbody2D.gravityScale = 3f;
            Collider2D[] colliders = GetComponents<Collider2D>();
            foreach (Collider2D coll in colliders)
            {
                coll.isTrigger = false;
            }
            m_Anim.SetBool("Climb", false);
        }
    }
}
