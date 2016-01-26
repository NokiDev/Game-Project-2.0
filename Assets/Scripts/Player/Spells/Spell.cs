using UnityEngine;
using System.Collections;

public class Spell {

    public enum SpellType{PROJECTILE, HEAL, BUFF};
    public enum Elements {NONE, FEU, EAU, TERRE, ELECTRICITE, ALL}

    protected float m_CoolDown;  //Nombre de temps avant de pouvoir relancer le sort
    protected bool inCooldown;//Si le sort à été utilisé

    protected float m_Timer; //Timer pour savoir si 'lon peut lancer le sort

    protected string m_Name; // Nom du sort
    protected SpellType m_Type; // Type du sort

    protected Elements m_Element;

    protected float staminaCost; //Cout du lancé de sort sur la barre de combos
    protected float comboDamageMultiplier; //Montant incrémenté au multiplicateur de dégats dans un combo
    protected Combos combo;

    public float StaminaCost
    {
        get
        {
            return staminaCost;
        }

        set
        {
            staminaCost = value;
        }
    }

    public Combos Combo
    {
        get
        {
            return combo;
        }
    }

    public float ComboDamageMultiplier
    {
        get
        {
            return comboDamageMultiplier;
        }

        set
        {
            comboDamageMultiplier = value;
        }
    }

    public bool InCooldown
    {
        get
        {
            return (Time.time - m_Timer >= m_CoolDown ? false : true);
        }

        set
        {
            inCooldown = value;
        }
    }

    public Elements Element
    {
        get
        {
            return m_Element;
        }

        set
        {
            m_Element = value;
        }
    }

    public virtual void init() { }

    //Lorsque l'on utilise le sort
    public void onUse()
    {
        if (Time.time - m_Timer >= m_CoolDown) { 
            switch (m_Type)
            {
                case SpellType.PROJECTILE:
                    ProjectileBehaviour();
                    break;
                case SpellType.HEAL:
                    HealBehaviour();
                    break;
                case SpellType.BUFF:
                    BuffBehaviour();
                    break;
            }
        }
    }

    //Comportement pour un projectile
    protected virtual void ProjectileBehaviour() { }

    //Comportement pour un heal
    protected virtual void HealBehaviour() { }

    //Comportement pour un buff
    protected virtual void BuffBehaviour() { }
}
