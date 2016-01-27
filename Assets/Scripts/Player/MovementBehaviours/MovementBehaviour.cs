using UnityEngine;
using System.Collections;

public abstract class MovementBehaviour : MonoBehaviour {

    protected bool m_Jump = false;                    //Indique si le joueur saute

    protected float m_MaxSpeed = 10f;                 // Vittesse Maximum, sur l'axe des "x"

    protected float m_JumpForce = 800f;               // Force Ajouté lors d'un saut

    protected float m_CrouchSpeed = .36f;             // %tage de la maxSpeed appliqué lorsque le joueur s'acroupi

    protected bool m_AirControl = false;              // Indique si le joueur peut controler son saut;

    protected LayerMask m_FloorMask;                  // Masque qui determine les layer représentant le sol

    protected Transform m_GroundCheck;                // Position ou l'on teste si le joueur touche le sol
    protected const float k_GroundedRadius = .2f;     // Rayon du cercle de collision pour savoir si le joueur touche le sol
    private bool grounded;                        // Indique si le joueur touche le sol.
    protected Transform m_CeilingCheck;               // Position ou l'on teste si le joueur touche le plafond ou non
    protected const float k_CeilingRadius = .01f;     // Rayon du cercle de collision pour savoir si le joueur touche le plafond

    protected bool m_FacingRight = true;              // Indique vers quelle direction le joueur regarde

    protected bool lockHorizontal = false;
    protected bool lockVertical = true;

    protected PlayerMovement.MovementState type;

    protected Animator m_Anim;                        // Référence à l'animator du joueur
    protected Rigidbody2D m_Rigidbody2D;              // Référence au rigidbody du joueur

    public bool Grounded
    {
        get
        {
            return grounded;
        }

        set
        {
            grounded = value;
        }
    }

    public bool LockHorizontal
    {
        get
        {
            return lockHorizontal;
        }

        set
        {
            lockHorizontal = value;
        }
    }

    public bool LockVertical
    {
        get
        {
            return lockVertical;
        }

        set
        {
            lockVertical = value;
        }
    }

    public PlayerMovement.MovementState Type
    {
        get
        {
            return type;
        }
    }

    // Use this for initialization
    protected void MovementStart()
    {
        //Mise en place des références
        m_GroundCheck = transform.Find("GroundCheck");
        m_CeilingCheck = transform.Find("CeilingCheck");
        m_Anim = GetComponent<Animator>();
        m_Rigidbody2D = GetComponent<Rigidbody2D>();

        m_FloorMask = GetComponent<PlayerMovement>().FloorMask;
        m_MaxSpeed = GetComponent<PlayerMovement>().MaxSpeed;
        m_JumpForce = GetComponent<PlayerMovement>().JumpForce;
        m_CrouchSpeed = GetComponent<PlayerMovement>().CrouchSpeed;
        m_AirControl = GetComponent<PlayerMovement>().AirControl;
        m_FacingRight = (gameObject.transform.localScale.x > 0) ? true : false;
    }

    // Update is called once per frame
    protected void MovementUpdate()
    {
        if (!m_Jump)
        {
            // Read the jump input in Update so button presses aren't missed.
            m_Jump = Input.GetButtonDown("Jump");
        }
    }

    protected void MovementFixedUpdate()
    {
        Grounded = false;
        RaycastHit2D hit = Physics2D.Raycast(m_GroundCheck.position, Vector2.down, 10, m_FloorMask);
        if (hit && hit.distance == 0)   
        {
            Grounded = true;
            
        }
        m_Anim.SetBool("Ground", Grounded);
        float moveH = 0f;
        float moveV = 0f;
        // Read the inputs.
        if (!LockHorizontal)
        {
            moveH = Input.GetAxis("Horizontal");
        }
        if (!LockVertical)
        {
            moveV = Input.GetAxis("Vertical");
        }
        Behaviour(moveH, moveV);
    }
    
    protected void Flip()
    {
        // Interverti la direction du regard Gauche -> Droite, Droite -> Gauche
        m_FacingRight = !m_FacingRight;

        // Multiplie le scale du joueur par -1 pour inverser l'image
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public abstract void Behaviour(float moveH, float moveV);

    public abstract void Stop();
}
