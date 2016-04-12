using UnityEngine;
using System.Collections;

public class Item {

    public enum ItemType {
        Unknown,
        Quest,
        Consommer,
        Armor, 
        Weapon
    }
    // Use this for initialization
    string m_Name = "UKNNOWN";

    ItemType m_Type;
    
    Item(string name, ItemType type)
    {
        m_Name = name;
        m_Type = type;
    }

    void OnUse()
    {

    }

    

}
