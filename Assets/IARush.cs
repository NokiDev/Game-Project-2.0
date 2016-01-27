using UnityEngine;
using System.Collections;

public class IARush : MonoBehaviour {

	private Rigidbody2D rb2d;
	public LayerMask mask;
	private bool rushOrNot = false;
	private Vector2 startPosition;

	// Use this for initialization
	void Start () {

		rb2d = GetComponent<Rigidbody2D> ();
		startPosition = gameObject.transform.position;
	}

	// Update is called once per frame
	void Update () {

		if (!rushOrNot) {

			if (Physics2D.Raycast (gameObject.transform.position, Vector2.left, 10, mask.value)) {
				//rb2d.velocity.x = -2;
				rushOrNot = true;

			}
		} 
		else if (rb2d.velocity.y == 0) {

			gameObject.transform.position = startPosition;
			rushOrNot = false;
			//rb2d.velocity.x = 0;
		}
	}
}