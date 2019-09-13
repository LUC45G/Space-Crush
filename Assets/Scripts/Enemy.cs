using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    private EnemySpawnController enemySpawnController;
    private EnemyMovementController enemyMovementController;
    private UIController uiController; 
    private CameraController mainCamera;
    private SpriteRenderer spriteRenderer;
    private GameObject auxGO;
    private System.Random rng = new System.Random(); // Generates random number used for random shooting
    private int auxRandom; // Random Integer used for random shooting
    private float fireRate = 0f, attackSpeed = 10f;
    private int type ; // Represents color, for chain destruction. Will be refactored to different classes probably.
    private int x, y; // coords on two dimmension array.



    // Use this for initialization
    void Start () {

        GameObject auxHolder = GameObject.FindGameObjectWithTag("Holder");
        GameObject auxEnemyHolder = GameObject.FindGameObjectWithTag("EnemyHolder");
        // Cant use SeralizeField because Enemies are prefabs
        enemyMovementController = auxEnemyHolder.GetComponent<EnemyMovementController>();
        enemySpawnController = auxEnemyHolder.GetComponent<EnemySpawnController>();
        uiController = auxHolder.GetComponent<UIController>();
        mainCamera = auxHolder.GetComponent<CameraController>();
        spriteRenderer = this.GetComponent<SpriteRenderer>();
	}
	
	void FixedUpdate () {
        
        if (Physics2D.Raycast(transform.position, transform.TransformDirection(Vector3.down), 1f)) {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) , Color.green);
        }
        else {
            Attack();
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) , Color.red);
        }


	}

    private void Attack() {
        auxRandom = rng.Next(1, 101);
        auxGO = EnemyShotPooler.sharedInstance.GetPooledObject(); 

        if ( auxRandom % 20 == 0 && auxGO != null && Time.time > fireRate) {

            fireRate = Time.time + attackSpeed;

            auxGO.transform.position = this.transform.position;
            auxGO.transform.rotation = this.transform.rotation;
            auxGO.SetActive(true);
            auxGO.GetComponent<Rigidbody2D>().AddForce(Vector2.down*250, ForceMode2D.Force);
        }

    }

    void OnTriggerEnter2D(Collider2D col) {
        if ( col.gameObject.CompareTag("Shot") ) {

            int quantity = 0;
            Destroy(col.gameObject);
            enemySpawnController.ChainDestruction(x, y, type, ref quantity);

            uiController.UpdateScore( fib(quantity+1) * quantity * 10 );
            enemySpawnController.KillEnemies(quantity);
            mainCamera.Shake(0.03f * quantity, 0.2f * quantity);

            return;
        }
        if ( col.gameObject.CompareTag("L_Limit")) {
            enemyMovementController.EnemiesGoDown();
            enemyMovementController.EnemiesGoRight();
            return;
        }

        if ( col.gameObject.CompareTag("R_Limit") ) {
            enemyMovementController.EnemiesGoDown();
            enemyMovementController.EnemiesGoLeft();
            return;
        }
    }

    public void ChangeSprite(Sprite[] s) {
        spriteRenderer.sprite = s[type];
    }
    public int getType() { 
        return type; 
    }
    public void SetCoordsAndType(int a, int b, int t) {
        x = a; y = b; type = t;
    }
    private int fib(int x) {
        int aux, a = 0, b = 1;
        for (int i = 0; i < x; i++) {
            aux = a;
            a = b; 
            b = aux + a; 
        }
        return a;
    }
}
