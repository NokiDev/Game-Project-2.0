using UnityEngine;
using UnityEditor;
using System.Collections;

public class FireballSpell : Spell {

    private GameObject m_FireBall; //Préfab de la boule de feu

    private GameObject m_Master; // GameObject maitre de la boule de feu (celui qui possede le sort)

    public FireballSpell(GameObject boss)
    {
        m_Master = boss;
    }

    public override void init () {
        //Methode très très moche, pour récupérer le préfab de la boule de feu (Ressource.Load() ne fonctionne pas)
        GameObject[] gameobjects = (GameObject[])(Resources.FindObjectsOfTypeAll(typeof(GameObject)));
        foreach (GameObject gmeobj in gameobjects)
        {
            if(gmeobj.name == "Fireball")
            {
                m_FireBall = gmeobj;
            }
        } 
        m_Name = "Fireball";
        m_Type = SpellType.PROJECTILE;
        m_CoolDown = 2f;
        m_InCooldown = false;
        m_Timer = 0f;
	}

    // Update is called once per frame
    void Update () {
	}

    //Comportement de la boule de feu
    protected override void ProjectileBehaviour()
    {
        m_Timer = Time.time;
        m_InCooldown = true;
        float facingCoeff = 1;
        GameObject ball = GameObject.Instantiate(m_FireBall, new Vector3(m_Master.transform.position.x, m_Master.transform.position.y, m_Master.transform.position.z), Quaternion.identity) as GameObject;
        if (m_Master.transform.localScale.x > 0)
        {
            facingCoeff = -1;
        }
        ball.transform.localScale = new Vector3(facingCoeff * ball.transform.localScale.x, ball.transform.localScale.y, ball.transform.localScale.z);
    }
}
