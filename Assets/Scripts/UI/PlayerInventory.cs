using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;



public class PlayerInventory : MonoBehaviour {


    private GameObject m_Player;
    private Dictionary<string, List<string>> m_PInventory;
    struct Slot
    {
        int key;
        string Item;
    }

    void Awake()
    {
        if ((m_Player = GameObject.Find("Character")) == null)
        {
            Debug.LogWarning("Warning Character not found !");
            gameObject.SetActive(false);
            return;
        }
        m_PInventory = m_Player.GetComponent<InventoryScript>().Inventory;
    }

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
