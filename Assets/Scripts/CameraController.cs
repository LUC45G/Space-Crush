using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    private GameObject mainCamera;
    private float shakeDuration, shakeMagnitude, dampingSpeed;
    private Vector3 initialPosition;

	// Use this for initialization
	void Start () {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        shakeDuration = 0f;
        shakeMagnitude = 0.7f;
        dampingSpeed = 1f;
        initialPosition = mainCamera.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (shakeDuration > 0) {
            mainCamera.transform.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude;
            
            shakeDuration -= Time.deltaTime * dampingSpeed;
        }
        else {
            shakeDuration = 0f;
            mainCamera.transform.localPosition = initialPosition;
        }
	}

    public void Shake(float duration, float magnitude) {
        shakeDuration = duration;
        shakeMagnitude = magnitude;
    }
}
