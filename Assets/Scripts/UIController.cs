using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    [SerializeField]
    private Text scoreText;
    private int currentScore = 0;
    [SerializeField]
    private Text livesText;
    private int lives = 3;

	// Use this for initialization
	void Start () {
		scoreText.text = "Score: " + currentScore;
        livesText.text = lives + "";
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LevelUp() {
        lives = 3;
        livesText.text = lives + "";
    }

    public void UpdateScore(int newScore) {
        currentScore += newScore;
        scoreText.text = "Score: " + currentScore;
    }

    public void HPLost() {
        lives--;
        livesText.text = lives + "";
    }
}
