using UnityEngine;
using System.Collections;
using System;

public class PlayerSpell : MonoBehaviour {

    PlayerComboManager playerComboScript;
    PlayerStamina playerStamina;
    Spell[] m_Spells = { null, null, null };

    // Use this for initialization
    void Start () {
        playerComboScript = gameObject.GetComponent<PlayerComboManager>();
        playerStamina = gameObject.GetComponent<PlayerStamina>();
        /**Initialise les sorts actif **/
        if (SaveManager.instance.getValue<string>("Spell1") != default(string))
            m_Spells[0] = (Spell)Activator.CreateInstance(Type.GetType(SaveManager.instance.getValue<string>("Spell1")), new object[] { gameObject });
        if (SaveManager.instance.getValue<string>("Spell2") != default(string))
            m_Spells[1] = (Spell)Activator.CreateInstance(Type.GetType(SaveManager.instance.getValue<string>("Spell2")), new object[] { gameObject });
        if (SaveManager.instance.getValue<string>("Spell3") != default(string))
            m_Spells[2] = (Spell)Activator.CreateInstance(Type.GetType(SaveManager.instance.getValue<string>("Spell3")), new object[] { gameObject });
    }
	
	// Update is called once per frame
	void Update () {
        
	    if(Input.GetButton("Spell1"))
        {
            UseSpell(0);
        }
        if(Input.GetButton("Spell2"))
        {
            UseSpell(1);
        }
        if (Input.GetButton("Spell3"))
        {
            UseSpell(2);
        }
    }

    void UseSpell(int index)
    {
        if (m_Spells[index] != null)
        {
            if (playerStamina.Stamina >= m_Spells[index].StaminaCost && !m_Spells[index].InCooldown)
            {
                m_Spells[index].onUse();
                playerComboScript.addCombo(m_Spells[index].Combo);
                playerStamina.UseStamina(m_Spells[index].StaminaCost);
            }
        }
    }
}
