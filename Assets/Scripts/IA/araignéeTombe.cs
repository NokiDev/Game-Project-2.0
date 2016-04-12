using UnityEngine;
using System.Collections;

public class araignéeTombe : MonoBehaviour {

    [SerializeField]
    private LayerMask mask;

    private float pointA;
    private float pointB;
    private Vector2 vectorA;
    private Vector2 vectorB;
    private float pos;
    private float oldPos;
    private Collider2D collider;
    private Vector2 velocity = new Vector2(0, 0);
    private bool estTombe = false;

	// Use this for initialization
	void Start () {
        vectorA = new Vector2(this.transform.position.x - 3, this.transform.position.y + 2);
        vectorB = new Vector2(this.transform.position.x + 3, this.transform.position.y - 10);
        
    }

    // Update is called once per frame
    void Update() {
        if (this.gameObject.GetComponent<Rigidbody2D>().gravityScale < 0 ) {
            Debug.Log("test");
            Collider2D coll = Physics2D.OverlapArea(vectorA, vectorB, mask);
            if (coll != null)
            {
                this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
                this.transform.Rotate(0, 0, 180);
            }
        }
    }

    void FixedUpdate()
    {
        if (this.gameObject.GetComponent<Rigidbody2D>().gravityScale >= 0 
            && (collider = Physics2D.OverlapCircle(this.transform.position, 20, mask)) != null
            && estTombe)
            
        {
            Vector2 direction = new Vector2(collider.transform.position.x - this.transform.position.x, 0);
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(direction.normalized * 20.0F);

        }
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Mur")
        {
            estTombe = true;
        }
    }
}
