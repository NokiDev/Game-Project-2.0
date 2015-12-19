using UnityEngine;
using System.Collections;

public class Spell : MonoBehaviour {

    public enum SpellType{PROJECTILE, HEAL, BUFF};

    protected float m_CoolDown;
    protected bool m_InCooldown;

    protected float m_Timer;

    protected string m_Name;
    protected SpellType m_Type;

    public virtual void setPrefab(Rigidbody2D body){}

    public virtual void init() { }

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
            print("In CoolDown");
        }
    }

    protected virtual void ProjectileBehaviour() { }

    protected virtual void HealBehaviour() { }

    protected virtual void BuffBehaviour() { }
}
