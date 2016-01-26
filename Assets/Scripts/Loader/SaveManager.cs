using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public interface ISaveProperty
{ }

public class SaveProperty<T> : ISaveProperty
{
    private T m_Value;
    public SaveProperty(T value)
    {
        m_Value = value;
    }

    public void setValue(T value)
    {
        m_Value = value;
    }

    public T getValue()
    {
        return m_Value;
    }
}

public class SaveManager : MonoBehaviour {

    public static SaveManager instance;
	// Use this for initialization
    [Serializable]
    public class Property<T>
    {
        public string name;
        public T value;
    }
    [Serializable]
    public class PropertyString : Property<string> { }
    [Serializable]
    public class PropertyInt : Property<int> { }
    [Serializable]
    public class PropertyFloat : Property<float> { }


    public PropertyInt[] DefaultIntProperties; ///Array of Int Caracteristics
    public PropertyFloat[] DefaultFloatProperties;///Array of Float Caracteristics
    public PropertyString[] DefaultStringProperties;///Array of String Caracteristics

    private Dictionary<string, ISaveProperty> m_Caracteristics = new Dictionary<string, ISaveProperty>();

    // Use this for initialization
    void Awake()
    {
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        ///Init default Caracs
        foreach (PropertyInt c in DefaultIntProperties)
        {
            m_Caracteristics[c.name] = new SaveProperty<int>(c.value);
        }
        foreach (PropertyString c in DefaultStringProperties)
        {
            m_Caracteristics[c.name] = new SaveProperty<string>(c.value);
        }
        foreach (PropertyFloat c in DefaultFloatProperties)
        {
            m_Caracteristics[c.name] = new SaveProperty<float>(c.value);
        }
    }

    public void Save()
    {

    }

    public void Load()
    {

    }

    public void addValue<T>(string key, T value)
    {
        m_Caracteristics[key] = new SaveProperty<T>(value);
    }

    public void setValue<T>(string key, T value)
    {
        SaveProperty<T> carac = (SaveProperty<T>)(m_Caracteristics[key]);
        carac.setValue(value);
    }

    public T getValue<T>(string key)
    {
        Debug.Log(key);
        if (m_Caracteristics.ContainsKey(key))
        {
            SaveProperty<T> carac = (SaveProperty<T>)(m_Caracteristics[key]);
            return carac.getValue();
        }
        return default(T);
    }
}
