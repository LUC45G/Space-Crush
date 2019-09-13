using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private float movementSpeed = 0.3f;
    private float shootForce = 500f;
    private bool canMoveToLeft = true, canMoveToRight = true;


    [SerializeField]
    private GameObject shot;
    [SerializeField]
    private CameraController mainCamera;
    [SerializeField]
    private UIController uiController;
    
    private float attackSpeed = 0.5f;
    private float fireRate = 0f;
    private int lives = 3;
    private Vector3 initialPosition;


	// Use this for initialization
	void Start () {
        initialPosition = this.transform.position;
		
	}
	
	// Update is called once per frame
	void Update () {
        Move();

        if ( Input.GetKey(KeyCode.K) && Time.time > fireRate) {
            fireRate = Time.time + attackSpeed;
            Shoot();
        }
	}

    private void Move() {
        float temp = Input.GetAxis("Horizontal");
        Vector3 move = new Vector3(temp, 0, 0);

        if ( canMoveToLeft && temp < 0) {
            transform.position += move * movementSpeed;
            canMoveToRight = true;
            return;
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

    public void Hit() {
        lives--;
        mainCamera.Shake(0.5f, 0.7f);
        
        if(lives > 0)
            uiController.HPLost(lives);
        else
            uiController.RestartGame();
    }

    public void RestartPositionAndLives() {
        this.transform.position = initialPosition;
        lives = 3;
    }
}
