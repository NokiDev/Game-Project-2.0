using UnityEngine;
using System.Collections;

public class timer : MonoBehaviour {
    public float timeleft=4;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        timeleft -= Time.deltaTime;
        if (timeleft < 0)
        {
            Destroy(this.gameObject);
        }
    }
}
