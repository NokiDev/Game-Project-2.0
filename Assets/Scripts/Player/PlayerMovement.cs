using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public enum MovementState {NONE, CLIMB};

    private MovementBehaviour m_CurrentMovementBehaviour;
    [SerializeField]
    private float m_MaxSpeed = 10f;                 // Vittesse Maximum, sur l'axe des "x"
    [SerializeField]
    private float m_JumpForce = 800f;               // Force Ajouté lors d'un saut
    [Range (0,1)]
    [SerializeField]
    private float m_CrouchSpeed = .36f;             // %tage de la maxSpeed appliqué lorsque le joueur s'acroupi
    [SerializeField]
    private bool m_AirControl = false;              // Indique si le joueur peut controler son saut;


    [SerializeField]
    private LayerMask m_FloorMask;                  // Masque qui determine les layer représentant le sol

    public LayerMask FloorMask
    {
        get
        {
            return m_FloorMask;
        }
    }

    public bool AirControl
    {
        get
        {
            return m_AirControl;
        }

        set
        {
            m_AirControl = value;
        }
    }

    public float CrouchSpeed
    {
        get
        {
            return m_CrouchSpeed;
        }

        set
        {
            m_CrouchSpeed = value;
        }
    }

    public float JumpForce
    {
        get
        {
            return m_JumpForce;
        }

        set
        {
            m_JumpForce = value;
        }
    }

    public float MaxSpeed
    {
        get
        {
            return m_MaxSpeed;
        }

        set
        {
            m_MaxSpeed = value;
        }
    }

    public MovementBehaviour CurrentMovementBehaviour
    {
        get
        {
            return m_CurrentMovementBehaviour;
        }
    }

    // Use this for initialization
    void Awake()
    {
        m_CurrentMovementBehaviour = gameObject.AddComponent<BasicMovement>();
    }

    public MovementBehaviour ChangeMovementState(MovementState movementType)
    {
        m_CurrentMovementBehaviour.Stop();
        Destroy(CurrentMovementBehaviour);
        switch(movementType)
        {
            case MovementState.CLIMB:
                m_CurrentMovementBehaviour = gameObject.AddComponent<ClimbMovement>();
                break;
            case MovementState.NONE:
                m_CurrentMovementBehaviour = gameObject.AddComponent<BasicMovement>();
                break;
        }
        return m_CurrentMovementBehaviour;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Moving")
        {
            this.gameObject.transform.parent = coll.transform;
        }
    }
  
    void OnCollisionStay2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Moving")
        {
            /*Vector3 pos = transform.localPosition;
            Vector2 vel = coll.gameObject.GetComponent<Rigidbody2D>().velocity;
            transform.localPosition = new Vector3(pos.x + vel.x, pos.y + vel.y, pos.z);*/
        }
    }
    
    void OnCollisionExit2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Moving")
        {
           this.gameObject.transform.parent = null;
        }
    }    
}
