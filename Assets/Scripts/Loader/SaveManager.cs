using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public interface ISaveProperty
{
    Type Type();

    string ToString();

}

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

    public T GetValue()
    { 
        return m_Value;
    }

    public Type Type()
    {
        return m_Value.GetType();
    }

    public override string ToString()
    {
        return m_Value.ToString();
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

    public bool m_Reset = false;
    
    public PropertyInt[] DefaultIntProperties; ///Array of Int Caracteristics
    public PropertyFloat[] DefaultFloatProperties;///Array of Float Caracteristics
    public PropertyString[] DefaultStringProperties;///Array of String Caracteristics

    private Dictionary<string, ISaveProperty> m_SaveProperties = new Dictionary<string, ISaveProperty>();

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
            m_SaveProperties[c.name] = new SaveProperty<int>(c.value);
        }
        foreach (PropertyString c in DefaultStringProperties)
        {
            m_SaveProperties[c.name] = new SaveProperty<string>(c.value);
        }
        foreach (PropertyFloat c in DefaultFloatProperties)
        {
            m_SaveProperties[c.name] = new SaveProperty<float>(c.value);
        }
    }

    public void Save()
    {
        
    }

    public void setValue<T>(string key, T value)
    {
        SaveProperty<T> carac = (SaveProperty<T>)(m_SaveProperties[key]);
        carac.setValue(value);
        if (carac.GetValue() is float)
        {
            var d = (SaveProperty<float>)m_SaveProperties[key];
            PlayerPrefs.SetFloat(key, d.GetValue());
        }
        else if (carac.GetValue() is string)
        {
            var d = (SaveProperty<string>)m_SaveProperties[key];
            PlayerPrefs.SetString(key, d.GetValue());
        }
        else if (carac.GetValue() is int)
        {
            var d = (SaveProperty<int>)m_SaveProperties[key];
            PlayerPrefs.SetInt(key, d.GetValue());
        }
        else if (carac.GetValue() is bool)
        {
            var d= (SaveProperty<bool>)m_SaveProperties[key];
            PlayerPrefs.SetInt(key, (d.GetValue()) ? 1 : 0);
        }
    }

    public T getValue<T>(string key)
    {
        if (PlayerPrefs.HasKey(key) && !m_Reset)
        {
            if (typeof(T) == typeof(string))
                m_SaveProperties[key] = new SaveProperty<string>(PlayerPrefs.GetString(key));
            else if (typeof(T) == typeof(float))
                m_SaveProperties[key] = new SaveProperty<float>(PlayerPrefs.GetFloat(key));
            else if (typeof(T) == typeof(int))
                m_SaveProperties[key] = new SaveProperty<int>(PlayerPrefs.GetInt(key));
            else if (typeof(T) == typeof(bool))
                m_SaveProperties[key] = new SaveProperty<bool>((PlayerPrefs.GetInt(key)>0) ? true : false);
        }
        if(m_SaveProperties.ContainsKey(key))
            return ((SaveProperty<T>)m_SaveProperties[key]).GetValue();
        return default(T);
    }

    public bool keyExist(string key)
    {
        return m_SaveProperties.ContainsKey(key);
    }
}
