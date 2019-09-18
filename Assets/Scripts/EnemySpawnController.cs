using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour {

    [SerializeField]
    private GameObject[] enemyList;
    [SerializeField]
    private UIController uiController;
    [SerializeField]
    private Sprite[] deadSprites, movementSpritesUp, movementSpritesDown;
    [SerializeField]
    private LayerMask layerToIgnore;
    private Sprite[] currentSprites;
    private GameObject[,] enemiesGO;
    private Enemy[,] enemies;
    private int columns, rows, totalEnemies, vert, hor;
    private System.Random r = new System.Random();
    private float animationTrigger = 0f, timeBetweenAnimation = 1.5f;
    private Vector3 initialPosition;

    void Awake() {
        initialPosition = this.transform.position;
    }

    void Init() {
        vert = (int) Camera.main.orthographicSize;
        hor = vert * (Screen.width / Screen.height);
        columns = 11; rows = 5;
        enemiesGO = new GameObject[columns, rows];
        enemies = new Enemy[columns, rows];
        totalEnemies = columns*rows;
        Physics2D.queriesStartInColliders = false;
        currentSprites = movementSpritesUp;
        this.transform.position = initialPosition;
    }
	
	void OnEnable () {

        Init();

        int auxIndex;

        for(int i = 0; i < columns; i++) {
            for(int j = 0; j < rows; j++) {
                auxIndex = r.Next(0, 4);
                
                enemiesGO[i, j] = (GameObject) ( Instantiate(enemyList[auxIndex], new Vector3( i - ( hor - 0.5f ) , j  + vert - 5.5f  , -10), Quaternion.identity) );
                enemiesGO[i, j].transform.parent = this.transform;

                enemies[i, j] = enemiesGO[i, j].GetComponent<Enemy>();
                enemies[i, j].SetCoordsAndType(i, j, auxIndex);
                
                
            }
        }
	}

    void Update() {
        if( Time.time > animationTrigger ) {
            animationTrigger = Time.time + timeBetweenAnimation;

            currentSprites = ( currentSprites == movementSpritesUp ) ? movementSpritesDown : movementSpritesUp ;

            for(int i = 0; i < columns; i++)
                for (int j = 0; j < rows; j++)
                    if(enemies[i, j] != null)
                        enemies[i, j].ChangeSprite(currentSprites);

        }

        
    }

    public void KillEnemies(int quantity) {
        totalEnemies -= quantity;

        if(totalEnemies <= 0)
            uiController.LevelUp();
            
    }

    public void ChainDestruction(int x, int y, int type, ref int quantity) {

        if ( enemies[x, y] == null ) return;

        if( x >= 0 && y >= 0 && x < columns && y < rows && enemies[x, y].getType() == type ) {
            Destroy(enemiesGO[x, y].gameObject, 0.3f);
            enemiesGO[x, y].GetComponent<SpriteRenderer>().sprite = deadSprites[type];
            enemiesGO[x, y] = null; 
            enemies[x, y] = null;

            quantity++;
        }


        /* Each if statement controls if there are adjoining enemies, i.e. current enemy is not on borders,
        *   and if they are the same type.
        *   If those conditions are true, then they recursively do the same.
        */
        if( y < rows && y >= 0 && x+1 < columns )
            if(  enemies[x+1, y] != null  &&  enemies[x+1, y].getType() == type ) 
                this.ChainDestruction(x+1, y, type, ref quantity);


        if( y < rows && y >= 0 && x-1 >= 0 )
            if(  enemies[x-1, y] != null  && enemies[x-1, y].getType() == type )
                this.ChainDestruction(x-1, y, type, ref quantity);

        if( x < columns && x >= 0 && y+1 < rows )
            if (  enemies[x, y+1] != null  &&  enemies[x, y+1].getType() == type ) 
                this.ChainDestruction(x, y+1, type, ref quantity);

        if( x < columns && x >= 0 && y-1 >= 0 )
            if (  enemies[x, y-1] != null && enemies[x, y-1].getType() == type ) 
                this.ChainDestruction(x, y-1, type, ref quantity);
    }

    public Sprite getDeadSprite(int type) {
        return deadSprites[type];
    }

    public LayerMask getLayerToIgnore() {
        return layerToIgnore;
    }
}
