using UnityEngine;
using System.Collections;

public class IAThwomp : MonoBehaviour {

	private Rigidbody2D rb2d;
	public LayerMask mask;
	private bool fallOrNot = false;
	private Vector2 startPosition;

	// Use this for initialization
	void Start () {
	
		rb2d = GetComponent<Rigidbody2D> ();
		startPosition = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (fallOrNot&&gameObject.transform.position == new Vector3(startPosition.x, startPosition.y, gameObject.transform.position.z)){
			StopCoroutine ("Reset");
			fallOrNot = false;
		}
		if (!fallOrNot) {
			
			if (Physics2D.Raycast (gameObject.transform.position, Vector2.down, 50, mask.value)) {
				rb2d.gravityScale = 2f;
				fallOrNot = true;

			}
		} 
		else if (rb2d.velocity.y == 0) {
		
			//gameObject.transform.position = startPosition;

			//rb2d.MovePosition(startPosition);
			Invoke("startReset", 1f);

			rb2d.gravityScale = 0f;
		}


	}

	void startReset(){
		StartCoroutine("Reset");
	}

	void Reset()
	{
		gameObject.transform.position = Vector3.MoveTowards (gameObject.transform.position, startPosition, 0.3f);
	}
}
