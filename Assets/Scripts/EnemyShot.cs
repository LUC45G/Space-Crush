using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour {
    
    private PlayerController player;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D col) {

        if ( col.gameObject.CompareTag("T_Limit") ) {
            this.gameObject.SetActive(false);
            return;
        }

        if( col.gameObject.CompareTag("Player")) {
            player.Hit();
            this.gameObject.SetActive(false);
            return;
        }

        if( col.gameObject.CompareTag("Shot")) {
            Destroy(col.gameObject);
            this.gameObject.SetActive(false);
            return;
        }
    }
}
