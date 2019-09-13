using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnProtectionsController : MonoBehaviour {

    [SerializeField]
    private GameObject protection;

	void OnEnable () {
        for(int i = 0; i < 4; i++)
            ( (GameObject) Instantiate(protection, new Vector3( (-6) + 4*i , -3.7f , 0f) , Quaternion.identity) ).transform.parent = this.transform;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
