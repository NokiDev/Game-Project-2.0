using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour {


    private Image m_HealthBar;

	// Use this for initialization
	void Start () {
        m_HealthBar = GetComponentInChildren<Image>();
	}
	
	// Update is called once per frame
	void Update () { 
        float playerHealth = GameObject.Find("Character").GetComponent<PlayerCaracteristics>().Health;
        m_HealthBar.material.color = Color.Lerp(Color.green, Color.red, 1 - playerHealth * 0.01f);

        // Set le scale de la barre de vie proportionnellement a ses points de vie
        m_HealthBar.transform.localScale = new Vector3(m_HealthBar.transform.localScale.x * playerHealth * 0.01f, 1, 1);

    }
}
