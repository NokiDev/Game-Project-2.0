using UnityEngine;
using System.Collections;

public class Spell {

    public enum SpellType{PROJECTILE, HEAL, BUFF};

    protected float m_CoolDown;  //Nombre de temps avant de pouvoir relancer le sort
    protected bool m_InCooldown;//Si le sort à été utilisé

    protected float m_Timer; //Timer pour savoir si 'lon peut lancer le sort

    protected string m_Name; // Nom du sort
    protected SpellType m_Type; // Type du sort

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
        else
        {
          
        }
    }

    //Comportement pour un projectile
    protected virtual void ProjectileBehaviour() { }

    //Comportement pour un heal
    protected virtual void HealBehaviour() { }

    //Comportement pour un buff
    protected virtual void BuffBehaviour() { }
}
