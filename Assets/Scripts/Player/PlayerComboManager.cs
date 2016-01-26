using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerComboManager : MonoBehaviour {

    private float m_totalDamageMultiplier = 0;
    private float m_intervalMin = 0.30f;
    private Combos m_lastCombo;
    private int m_nbCombos = 0;

    // Use this for initialization
    void Start () {
    }

    public void addCombo(Combos combo){
        float demultiplier = 1f;
        m_nbCombos += 1;
        if (m_intervalMin > 2.0f)
        {
            demultiplier = 0f;
            m_nbCombos = 0;
            m_totalDamageMultiplier = 0.0f;
        }
        else if(m_intervalMin > 1.5f)
        {
            demultiplier = 0.3f;
        }
        else if (m_intervalMin > 0.7f)
        {
            demultiplier = 0.7f;
        }
        else if (m_intervalMin == 0.30f)
        {
            demultiplier = 1f;
        }
        m_intervalMin = 0f;
        m_totalDamageMultiplier += (combo.DamageMultiplier)*demultiplier;
    }

    // Update is called once per frame
    void Update() {
        if (m_nbCombos > 0)
        {
            m_intervalMin += Time.deltaTime;
            if (m_intervalMin >= 2.0f)
                m_nbCombos = 0;
        }
    }
}
