using UnityEngine;
using System.Collections;

public class snakeScript : MonoBehaviour {

    [SerializeField]
    LayerMask mask;
    public float speed;
    public bool faceRight;

    Rigidbody2D rigidbody2d;
    Transform transform2;

    // Use this for initialization
	void Start () {
        rigidbody2d = GetComponent<Rigidbody2D>();
        transform2 = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        if (GetComponent<EntityHealth>().isDead)
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        Vector2 vel;
        vel.x = speed * Time.deltaTime;
        vel.y = rigidbody2d.velocity.y;
        if (!faceRight){
            vel.x *= -1;
        }
        rigidbody2d.velocity = vel;
    }


    void OnCollisionEnter2D(Collision2D coll)
    {
        if (((1 << coll.gameObject.layer) & mask.value) != 0)
        {
			Debug.LogWarning ("TEST");
            faceRight = !faceRight;
            
        }
    }
}
