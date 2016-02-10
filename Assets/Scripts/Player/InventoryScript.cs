using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryScript : MonoBehaviour {

    private Dictionary<string, List<string>> m_Inventory = new Dictionary<string, List<string>>();

    public Dictionary<string, List<string>> Inventory
    {
        get
        {
            return m_Inventory;
        }
    }


    // Use this for initialization
    void Start () {
        m_Inventory.Add("Equipements", new List<string>());
            m_Inventory["Equipements"].Add("CASQUE");
            m_Inventory["Equipements"].Add("GANTS");
            m_Inventory["Equipements"].Add("PLASTRON");
            m_Inventory["Equipements"].Add("JAMBIERES");
            m_Inventory["Equipements"].Add("ARME");
            m_Inventory["Equipements"].Add("GANTS");
        m_Inventory.Add("Objets", new List<string>());
	}

	
	// Update is called once per frame
	void Update () {
	    
	}

    void AddItem(string key, string item)
    {
        if (m_Inventory.ContainsKey(key))
        {
            m_Inventory[key].Add(item);
        }
        else
            Debug.LogError("This Inventory Key doesn't exist !");
    }

    /*void SetItem(string item)
    {
        m_Inventory[key].Add(item);
    }*/
}
