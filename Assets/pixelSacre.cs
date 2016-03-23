using UnityEngine;
using System.Collections;

public class pixelSacre : MonoBehaviour {

    SpriteRenderer[] m_Colors;

	// Use this for initialization
	void Start () {
        m_Colors = gameObject.GetComponentsInChildren<SpriteRenderer>();
        m_Colors[0].material.SetColor("_Color", new Color(Random.Range(0, 255), Random.Range(0, 255), Random.Range(0, 255)));
        m_Colors[1].material.SetColor("_Color", new Color(Random.Range(0, 255), Random.Range(0, 255), Random.Range(0, 255)));
        m_Colors[2].material.SetColor("_Color", new Color(Random.Range(0, 255), Random.Range(0, 255), Random.Range(0, 255)));
    }

    // Update is called once per frame
    void Update()
    {

        Invoke("SwapColor", 0.0f);

    }


    void SwapColor()
    {
        m_Colors[0].material.SetColor("_Color", new Color(Random.Range(0,255), Random.Range(0, 255), Random.Range(0, 255)));
        m_Colors[1].material.SetColor("_Color", new Color(Random.Range(0, 255), Random.Range(0, 255), Random.Range(0, 255)));
        m_Colors[2].material.SetColor("_Color", new Color(Random.Range(0, 255), Random.Range(0, 255), Random.Range(0, 255)));
        /*m_Colors[0].color = new Color(Random.Range(1, 255), 0, 0);
        m_Colors[1].color = new Color(0, Random.Range(1, 255), 0);
        m_Colors[2].color = new Color(0, 0, Random.Range(1, 255));*/
    }

}
