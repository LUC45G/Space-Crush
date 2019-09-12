using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour {

	public void QuitGame() {
        Application.Quit();
    }

    public void PlayGame() {
        SceneManager.LoadScene(1);
    }
}
