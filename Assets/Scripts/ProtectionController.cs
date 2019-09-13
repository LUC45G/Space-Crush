using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class ProtectionController : MonoBehaviour {

    

    [SerializeField]
    private BoxCollider2D myBoxCollider;
    private BoxCollider2D auxBoxCollider, givenByDummy;
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    private int health = 5;
	// Use this for initialization
	void Start () {
		
	}

    void OnCollisionEnter2D(Collision2D col) {
        if(col.gameObject.CompareTag("EnemyShot")) {

            if(health > 1) {

                col.gameObject.SetActive(false); // Disable enemy shot

                auxBoxCollider = (BoxCollider2D) this.gameObject.AddComponent<BoxCollider2D>(); // Adds a new BoxCollider
                givenByDummy = DummyProtectionController.Instance.getHitboxByHP(--health); // Gets desired component values

                auxBoxCollider.size = givenByDummy.size; 
                auxBoxCollider.offset = givenByDummy.offset; // Modify component values

                Destroy(myBoxCollider); // Destroys current BoxCollider
                myBoxCollider = auxBoxCollider; // Sets reference to new BoxCollider

                spriteRenderer.sprite = DummyProtectionController.Instance.getSpriteByHP(health); // Changes sprite
                
            }
            else {
                Destroy(this.gameObject);
                col.gameObject.SetActive(false); // Disable enemy shot
            }

            return;

        }

        if(col.gameObject.CompareTag("Shot")) {
            Destroy(col.gameObject);
            return;
        }

    }

    
	
	
}
