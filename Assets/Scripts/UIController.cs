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
    private GameObject mainCamera, LevelUpText, GameOverText, scoreTextGO, HPTextGO, enemiesController, enemiesGO;

    [SerializeField]
    private PlayerController player;
    [SerializeField]
    private GameObject protectionsController;

	// Use this for initialization
	void Start () {
		scoreText.text = "Score: " + currentScore;
        livesText.text = 3 + "";
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LevelUp() {
        StartCoroutine("DelayLevelUp");
    }

    public void RestartGame() {
        StartCoroutine("DelayRestart");
    }

    IEnumerator DelayRestart() {
        
        HPTextGO.SetActive(false);
        scoreTextGO.SetActive(false);
        GameOverText.SetActive(true);
        enemiesGO.SetActive(false);
        Time.timeScale = 0f;

        yield return new WaitForSecondsRealtime(1.5f);

        Time.timeScale = 1f;

        HPTextGO.SetActive(true);
        scoreTextGO.SetActive(true);
        GameOverText.SetActive(false);
        
        SceneManager.LoadScene(0);
    }

    IEnumerator DelayLevelUp() {
        
        HPTextGO.SetActive(false);
        scoreTextGO.SetActive(false);
        LevelUpText.SetActive(true);
        Time.timeScale = 0f;

        yield return new WaitForSecondsRealtime(1.5f);

        Time.timeScale = 1f;
        
        HPTextGO.SetActive(true);
        scoreTextGO.SetActive(true);
        LevelUpText.SetActive(false);

        livesText.text = 3 + "";
        enemiesController.SetActive(false);
        protectionsController.SetActive(false);
        enemiesController.SetActive(true);
        protectionsController.SetActive(true);
        player.RestartPositionAndLives();
    }

    public void UpdateScore(int newScore) {
        currentScore += newScore;
        scoreText.text = "Score: " + currentScore;
    }

    public void HPLost(int lives) {
        livesText.text = lives + "";
    }
}
