using UnityEngine;
using System.Collections;

public class Plateform : MonoBehaviour {

    public bool canComeFromBot = false;
    public LayerMask m_Mask;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (canComeFromBot)
        {
            Vector2 pos = new Vector2(gameObject.GetComponent<Collider2D>().bounds.center.x - gameObject.GetComponent<Collider2D>().bounds.extents.x, gameObject.GetComponent<Collider2D>().bounds.center.y - gameObject.GetComponent<Collider2D>().bounds.extents.y);
            Vector2 size = new Vector2(gameObject.GetComponent<Collider2D>().bounds.extents.x * 2, gameObject.GetComponent<Collider2D>().bounds.extents.y * 2);
            if (Physics2D.Linecast(new Vector2(pos.x, pos.y), new Vector2(pos.x + size.x, pos.y), m_Mask))
            {
                GetComponent<Collider2D>().isTrigger = true;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        GetComponent<Collider2D>().isTrigger = false;
    }

}
