using UnityEngine;
using UnityEditor;
using System.Collections;

public class FireballSpell : Spell {

    private GameObject fireBall;

    private GameObject master;

    public FireballSpell(GameObject boss)
    {
        master = boss;
    }

    public override void init () {
        GameObject[] gameobjects = (GameObject[])(Resources.FindObjectsOfTypeAll(typeof(GameObject)));
        foreach (GameObject gmeobj in gameobjects)
        {
            print("GameObject :" + gmeobj.name + "found in assets Ressources folder");
            if(gmeobj.name == "Fireball")
            {
                fireBall = gmeobj;
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

    protected override void ProjectileBehaviour()
    {
        m_Timer = Time.time;
        m_InCooldown = true;
        float facingCoeff = 1;
        GameObject ball = Instantiate(fireBall, new Vector3(master.transform.position.x, master.transform.position.y, master.transform.position.z), Quaternion.identity) as GameObject;
        if (master.transform.localScale.x > 0)
        {
            facingCoeff = -1;
        }
        ball.transform.localScale = new Vector3(facingCoeff * ball.transform.localScale.x, ball.transform.localScale.y, ball.transform.localScale.z);

        Rigidbody2D ballRb = ball.GetComponent<Rigidbody2D>();
        ballRb.velocity = new Vector2(-facingCoeff*5, 0);
    }
}
