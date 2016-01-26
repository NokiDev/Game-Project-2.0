using UnityEngine;
using System.Collections;



public class bouleDeFeu : MonoBehaviour {

    public GameObject BDF;
	// Use this for initialization
	void Start () {
        InvokeRepeating("summon", 3f, 3f);
    }

    // Update is called once per frame
    void Update () {
    }

    void summon()
    {
        GameObject BDF1 = (GameObject)(GameObject.Instantiate(BDF, new Vector3 (gameObject.transform.position.x, transform.position.y, transform.position.z), Quaternion.identity));
        GameObject BDF2 = (GameObject)(GameObject.Instantiate(BDF, new Vector3(gameObject.transform.position.x, transform.position.y-2, transform.position.z), Quaternion.identity));
    }
}
