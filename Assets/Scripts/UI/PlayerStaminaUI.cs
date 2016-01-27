using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class PlayerStaminaUI : MonoBehaviour
{

    private Image m_StaminaBar;

    // Use this for initialization
    void Start()
    {
        m_StaminaBar = GetComponentInChildren<Image>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float stamina = GameObject.Find("Character").GetComponent<PlayerStamina>().Stamina;

        //Debug.Log(stamina);

        // Set le scale de la barre de vie proportionnellement a ses points de vie
        m_StaminaBar.transform.localScale = new Vector3(m_StaminaBar.transform.localScale.x * stamina * 0.01f, 1, 1);

    }
}
