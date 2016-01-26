using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class PlayerCaracteristics : MonoBehaviour {

    [SerializeField]
    private float m_Health = 100;
    [SerializeField]
    private float m_HealthMax = 100;

    private int m_NumberOfHealthUpgrades = 0;

    [SerializeField]
    private float m_PhyDamage = 15;

    private float m_Stamina = 50;
    [SerializeField]
    private float m_StaminaMax = 50;

    private int m_NumberOfStaminaUpgrades = 0;

    private bool m_HasUnlockStamina = true;

    private float m_GlobalCooldown;

    //InventoryManager inventory;
    private Dictionary<Spell.Elements, int> m_ElementMasteriesLvl = new Dictionary<Spell.Elements, int>();

    public float Health
    {
        get
        {
            return m_Health;
        }

        set
        {
            m_Health = value;
        }
    }
    public float HealthMax
    {
        get
        {
            return m_HealthMax;
        }

        set
        {
            m_HealthMax = value;
        }
    }
    public float StaminaMax
    {
        get
        {
            return m_StaminaMax;
        }

        set
        {
            m_StaminaMax = value;
        }
    }
    // Use this for initialization
    void Start () {

        m_NumberOfHealthUpgrades = SaveManager.instance.getValue<int>("HealthUpgrades");
        m_NumberOfStaminaUpgrades = SaveManager.instance.getValue<int>("StaminaUpgrades");
        m_HasUnlockStamina = SaveManager.instance.getValue<bool>("StaminaUnlocked");
        if(SaveManager.instance.getValue<float>("Health") > 0)
        {
            m_Health = SaveManager.instance.getValue<float>("Health");
        }

        m_HealthMax += m_NumberOfHealthUpgrades * 20;
        m_StaminaMax += m_NumberOfStaminaUpgrades * 20;
        m_Stamina = m_StaminaMax;
    }

    public void addHealthUpgrade(int number)
    {
        m_NumberOfHealthUpgrades += number;
        m_HealthMax += number * 20;
        m_Health += number * 20;
    }

    public void addStaminaUpgrade(int number)
    {
        m_NumberOfStaminaUpgrades += number;
        m_StaminaMax += number * 20;
        m_Stamina += number * 20;
    }

	// Update is called once per frame
	void Update () {
	
	}
}
