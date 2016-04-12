using UnityEngine;
using System.Collections;

public class IARush : MonoBehaviour {

	private Rigidbody2D rb2d;
	public LayerMask mask;
	private bool rushOrNot = false;
	private Vector2 startPosition;
	public Vector2 targetPosition;

	// Use this for initialization
	void Start () {

		rb2d = GetComponent<Rigidbody2D> ();
		startPosition = gameObject.transform.position;
	}

	// Update is called once per frame
	void Update () {

		if (!rushOrNot) {
			
			Collider2D coll = Physics2D.OverlapCircle (gameObject.transform.position, 20, mask.value);
			if (coll) {
				if (coll.tag == "Player") {
					targetPosition = coll.GetComponent<Transform> ().position;
					rushOrNot = true;
				}
			}
		}
		Vector2 position = gameObject.transform.position;
		if (rushOrNot ){
			if (position == targetPosition) {
				rushOrNot = false;
				StopCoroutine ("rush");
			} else {
				StartCoroutine ("rush");
			}
		}
		
		/*else if (rb2d.velocity.x == 0) {


			gameObject.transform.position = startPosition;
			rushOrNot = false;
			//rb2d.velocity.x = 0;
		}*/
	}


	void startRushing()
	{
		StartCoroutine ("rush");
	}

	void rush (){
		gameObject.transform.position = Vector3.MoveTowards (gameObject.transform.position, targetPosition, 0.7f);
	}
}