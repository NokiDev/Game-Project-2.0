using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour {


    private Image m_HealthBar;
    private GameObject m_Player;

    void Awake()
    {
        if((m_Player = GameObject.Find("Character")) == null)
        {
            Debug.LogWarning("Warning Character not found !");
            gameObject.SetActive(false);

        }
    }

	// Use this for initialization
	void Start () {
        m_HealthBar = GetComponentInChildren<Image>();
	}
	
	// Update is called once per frame
	void Update () { 
        float playerHealth = m_Player.GetComponent<PlayerCaracteristics>().Health;
        m_HealthBar.material.color = Color.Lerp(Color.green, Color.red, 1 - playerHealth * 0.01f);

        // Set le scale de la barre de vie proportionnellement a ses points de vie
        m_HealthBar.fillAmount = playerHealth * 0.01f;

    }
}
