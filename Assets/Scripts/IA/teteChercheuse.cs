using UnityEngine;
using System.Collections;

public class teteChercheuse : MonoBehaviour {

    [SerializeField]
    private LayerMask mask;

	// Use this for initialization
	void Start () {
        

        this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-5, 0);
    }

    // Update is called once per frame
    void Update () {
       Collider2D collider = Physics2D.OverlapCircle(this.transform.position, 50, mask);

        if (collider != null)
        {
            this.gameObject.GetComponent<Rigidbody2D>().angularVelocity= (Mathf.Rad2Deg * Mathf.Atan2(this.transform.position.y - collider.transform.position.y, this.transform.position.x - collider.transform.position.x));
            this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(collider.GetComponent<Transform>().position.x - this.GetComponent<Transform>().position.x, collider.GetComponent<Transform>().position.y - this.GetComponent<Transform>().position.y);
            //this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(collider.GetComponent<Transform>().position.x - this.GetComponent<Transform>().position.x, collider.GetComponent<Transform>().position.y - this.GetComponent<Transform>().position.y));
           
        }
    }
}
