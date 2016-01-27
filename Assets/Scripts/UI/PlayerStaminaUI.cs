using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class PlayerStaminaUI : MonoBehaviour
{

    private Image m_StaminaBar;

    private GameObject m_Player;

    // Use this for initialization
    void Awake()
    {
        if(GameObject.Find("Character") == null)
        {
            Debug.LogWarning("WARNING Character Gameobject not found");
            this.gameObject.SetActive(false);
        }
    }

    void Start()
    {
        m_Player = GameObject.Find("Character");
        m_StaminaBar = GetComponentInChildren<Image>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float stamina = m_Player.GetComponent<PlayerStamina>().Stamina;

        //Debug.Log(stamina);

        // Set le scale de la barre de vie proportionnellement a ses points de vie
        m_StaminaBar.fillAmount = stamina * 0.01f;

    }
}
