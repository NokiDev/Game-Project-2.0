using UnityEngine;
using System.Collections;

public class fly : MonoBehaviour {

	private Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D (Collision2D coll){

		rb2d.gravityScale = 0f;
	}
}
