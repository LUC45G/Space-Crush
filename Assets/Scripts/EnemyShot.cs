using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
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
            Debug.Log("Player hit");

            
            this.gameObject.SetActive(false);
            return;
        }
    }
}
