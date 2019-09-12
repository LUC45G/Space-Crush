using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotPooler : MonoBehaviour {

    public static EnemyShotPooler sharedInstance;

    private List<GameObject> pooledObjects;
    [SerializeField] 
    private GameObject objectToPool;
    private int amountToPool = 5;

    void Awake() {
        sharedInstance = this;
    }

	// Use this for initialization
	void Start () {

        pooledObjects = new List<GameObject>();

        for (int i = 0; i < amountToPool; i++) {
            GameObject obj = (GameObject)Instantiate(objectToPool);
            obj.SetActive(false); 
            pooledObjects.Add(obj);
        }
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public GameObject GetPooledObject() {
        
        for (int i = 0; i < pooledObjects.Count; i++)
            if (!pooledObjects[i].activeInHierarchy)
                return pooledObjects[i];    
      
        return null;
    }

}
