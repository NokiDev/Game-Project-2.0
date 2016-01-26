using UnityEngine;
using System.Collections;

public class ClimbableObjectScript : MonoBehaviour {

   private PlayerMovement m_Player;      //Référence au script playerScript
   [SerializeField]
   private LayerMask m_Mask;          //Masque pour le calque du joueur

   public bool m_centerCheck = true;

   private bool m_topOut;
   private bool m_botOut;               //Indique si le joueur est en bas de l'échelle
   private bool m_rightOut;
   private bool m_leftOut;

   private bool m_onCenter = false;

   private bool m_climbing;
   private bool m_onClimbable;


   public bool m_LockHorizontal = true;
   public bool m_LockVertical = false;

   // Use this for initialization
   void Awake()
   {
       m_onCenter = false;
       m_Player = GameObject.Find("Character").GetComponent<PlayerMovement>();
   }

   void FixedUpdate()
   {
       Vector2 pos = new Vector2(gameObject.GetComponent<Collider2D>().bounds.center.x - gameObject.GetComponent<Collider2D>().bounds.extents.x, gameObject.GetComponent<Collider2D>().bounds.center.y - gameObject.GetComponent<Collider2D>().bounds.extents.y);
       Vector2 size = new Vector2(gameObject.GetComponent<Collider2D>().bounds.extents.x * 2, gameObject.GetComponent<Collider2D>().bounds.extents.y * 2);

       m_topOut = Physics2D.Linecast(new Vector2(pos.x, pos.y + size.y), new Vector2(pos.x + size.x, pos.y + size.y), m_Mask.value);
       m_botOut = Physics2D.Linecast(pos, new Vector2(pos.x + size.x, pos.y), m_Mask);

       m_rightOut = Physics2D.Linecast(new Vector2(pos.x + size.x, pos.y), new Vector2(pos.x + size.x, pos.y + size.y), m_Mask.value);
       m_leftOut = Physics2D.Linecast(new Vector2(pos.x, pos.y), new Vector2(pos.x, pos.y + size.y), m_Mask.value);
       if (m_centerCheck)
       {
           m_onCenter = Physics2D.Linecast(new Vector2(pos.x + size.x / 2, pos.y + size.y), new Vector2(pos.x + size.x / 2, pos.y), m_Mask.value);
       }
   }

   void OnTriggerStay2D(Collider2D coll)
   {
       var v = Input.GetAxis("Vertical");
       if (m_Player.CurrentMovementBehaviour.Type == PlayerMovement.MovementState.NONE)
       {
           if (m_onCenter || !m_centerCheck)
           {
               if ((v > 0 && !m_topOut) || (v < 0 && !m_botOut))
               {
                   MovementBehaviour mov = m_Player.ChangeMovementState(PlayerMovement.MovementState.CLIMB);
                   mov.LockHorizontal = m_LockHorizontal;
                   mov.LockVertical = m_LockVertical;
               }
           }
       }
       else
       {
           //else if (m_topOut && m_topCheck)
           //{
             //  Exit();
           //}
       }
   }

   void OnTriggerExit2D(Collider2D coll)
   {
       Exit();
       //Arrete de grimper lorsqu'il sort du trigger
   }


   void Exit()
   {
       m_Player.ChangeMovementState(PlayerMovement.MovementState.NONE);
       m_topOut = false;
       m_botOut = false;
       m_rightOut = false;
       m_leftOut = false;
       m_onCenter = false;
   }
}
