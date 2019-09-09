using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    private float movementSpeed = 0.3f;
    [SerializeField]
    private float shootForce = 25f;
    private bool canMoveToLeft = true, canMoveToRight = true;

    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    private GameObject shot;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Move();

        if ( Input.GetKey(KeyCode.K))
            Shoot();
	}

    private void Move() {
        float temp = Input.GetAxis("Horizontal");
        Vector3 move = new Vector3(temp, 0, 0);

        if ( canMoveToLeft && temp < 0) {
            transform.position += move * movementSpeed;
            canMoveToRight = true;
        }
        if ( canMoveToRight && temp > 0) {
            transform.position += move * movementSpeed;
            canMoveToLeft = true;
        }
        
    }

    private void Shoot() {
        GameObject auxGO = (GameObject) Instantiate(shot, this.transform.position, Quaternion.identity);
        Rigidbody2D auxRB = auxGO.GetComponent<Rigidbody2D>();
        auxRB.AddForce(Vector2.up * shootForce, ForceMode2D.Force);
        
    }

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.CompareTag("L_Limit")) 
            canMoveToLeft = false;
        else if ( col.gameObject.CompareTag("R_Limit"))
            canMoveToRight = false;
    }
}
