using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    [SerializeField]
    private Text scoreText;
    private int currentScore = 0;
    [SerializeField]
    private Text livesText;
    [SerializeField]
    private GameObject esc;
    [SerializeField]
    private PlayerController player;

	// Use this for initialization
	void Start () {
		scoreText.text = "Score: " + currentScore;
        livesText.text = 3 + "";
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LevelUp() {
        livesText.text = 3 + "";
        esc.SetActive(false);
        esc.SetActive(true);
        player.RestartPosition();
    }

    public void RestartGame() {
        SceneManager.LoadScene(0);
    }

    public void UpdateScore(int newScore) {
        currentScore += newScore;
        scoreText.text = "Score: " + currentScore;
    }

    public void HPLost(int lives) {
        livesText.text = lives + "";
    }
}
