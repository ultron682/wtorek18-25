using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager Instance;

    [SerializeField]
    int timeToEnd;
    bool gamePaused = false;

    bool endGame = false;
    bool win = false;

    void Start() {
        if (Instance == null)
            Instance = this;

        if (timeToEnd <= 0) {
            timeToEnd = 100;
        }

        InvokeRepeating("Stopper", 2, 1);
    }

    void Update() {
        PauseCheck();
    }

    void Stopper() {
        timeToEnd--;

        if (timeToEnd <= 0) {
            endGame = true;
            timeToEnd = 0;
        }

        if (endGame) {
            EndGame();
        }


        Debug.Log("TIme: " + timeToEnd);
    }

    public void PauseGame() {
        Debug.Log("Pause game");
        Time.timeScale = 0f;
        gamePaused = true;
    }

    public void ResumeGame() {
        Debug.Log("Resume game");
        Time.timeScale = 1f;
        gamePaused = false;
    }

    void PauseCheck() {
        if (Input.GetKeyDown(KeyCode.P)) {
            if (gamePaused) {
                ResumeGame();
            }
            else {
                PauseGame();
            }
        }
    }


    public void EndGame() {
        CancelInvoke("Stopper");

        if (win) {
            Debug.Log("You win!!");
        }
        else {
            Debug.Log("You Lose!!");
        }
    }

}
