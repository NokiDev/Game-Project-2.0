using UnityEngine;
using System.Collections;



public class bouleDeFeu : MonoBehaviour {

    public GameObject BDF;
    private Transform transform2;
	// Use this for initialization
	void Start () {
        transform2 = GetComponent<Transform>();
        InvokeRepeating("summon", 3f, 3f);
    }

    // Update is called once per frame
    void Update () {
    }

    void summon()
    {
        GameObject BDF1 = (GameObject)(GameObject.Instantiate(BDF, new Vector3 (transform2.position.x, transform2.position.y, transform2.position.z), Quaternion.identity));
        GameObject BDF2 = (GameObject)(GameObject.Instantiate(BDF, new Vector3(transform2.position.x, transform2.position.y-2, transform2.position.z), Quaternion.identity));
    }
}
