using UnityEngine;
using System.Collections;

public class PlayerSpell : MonoBehaviour {

    Spell[] spells = { null, null, null };

	// Use this for initialization
	void Start () {
        //spells = SpellManager.loadSpells();
        spells[0] = new FireballSpell(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetButton("Fire3"))
        {
            spells[0].onUse();
        }
	}

    void FixedUpdate()
    {

    }


}
