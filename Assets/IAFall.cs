using UnityEngine;
using System.Collections;

public class IAFall : MonoBehaviour {

	private Rigidbody2D rb2d;
	public LayerMask mask;

	// Use this for initialization
	void Start () {

		rb2d = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update () {


			if (Physics2D.Raycast (gameObject.transform.position, Vector2.down, 50, mask.value)) {
				rb2d.gravityScale = 2f;

		}
	}


	void OnCollisionEnter2D(Collision2D coll){

		Destroy (gameObject);
	}
}