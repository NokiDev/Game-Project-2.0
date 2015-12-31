using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    private Spell[] spells = { null, null, null };  //Tableau des 3 sorts que le joueur peut utiliser (initialiser a null)

    //public Rigidbody2D fireBall;

    // Use this for initialization
    void Awake ()
    {
        //Mise en place des références
        spells[0] = new FireballSpell(this.gameObject);//TEST : initialisation d'un premier sort boule de feu
        spells[0].init();// On initialise le script (Start() et Awake() ne fonctionne pas car le script n'est pas dans la scene)
    }

    void FixedUpdate()
    {
        
    }

    //Utilise le sort à l'emplacement [id] du tableau
    public void useSpell(int id)
    {
        spells[id].onUse();
    }	
}
