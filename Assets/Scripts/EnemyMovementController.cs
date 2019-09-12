using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementController : MonoBehaviour {

    private GameObject[,] enemies;
    private bool moveToRight = true;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 p = this.transform.position;

        if(moveToRight) {
            this.transform.position = new Vector3(p.x+0.05f, p.y, p.z);
        } else {
            this.transform.position = new Vector3(p.x-0.05f, p.y, p.z);
        }
    
	}



    public void EnemiesGoDown() {
        Vector3 p;
		
        p = this.transform.position;
        this.transform.position = new Vector3(p.x, p.y - 0.1f, p.z);
    }

    public void EnemiesGoRight() { moveToRight = true; }
    public void EnemiesGoLeft() { moveToRight = false; }

    

    public void setEnemies(GameObject[,] g) {
        enemies = g;
    }

}
