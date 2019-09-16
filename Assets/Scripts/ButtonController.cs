using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour {
    bool fPressed = false;
    [SerializeField]
    private Text text;
    void Update() {
        if(Input.GetKeyDown(KeyCode.F) && !fPressed) {
            text.text = "Controls:\nA-D / Arrow keys to move\nK to shoot\nI appreciate that";
        }
    }

	public void QuitGame() {
        Application.Quit();
    }

    public void PlayGame() {
        SceneManager.LoadScene(1);
    }
}
