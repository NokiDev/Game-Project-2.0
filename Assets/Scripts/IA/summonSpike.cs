using UnityEngine;
using System.Collections;

public class summonSpike : MonoBehaviour {

    [SerializeField]
    private LayerMask mask;

    [SerializeField]
    private GameObject spike;

    private float timer;
    private Vector2 position;
    private GameObject[] spikeList;
    
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
       
        Collider2D coll = Physics2D.OverlapCircle(this.transform.position, 20, mask);

        if(coll!= null)
        {
            timer += Time.deltaTime;
            if (timer == 0)
            {
                position = coll.transform.position;
            }
            if (timer > 3)
            {
                position =new Vector2(coll.transform.position.x,0);
                timer = 0;
                GameObject.Instantiate(spike, position, Quaternion.identity);
            }
        }
	}
}
