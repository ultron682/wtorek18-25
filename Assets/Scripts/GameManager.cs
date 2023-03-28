using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager Instance;

    [SerializeField]
    int timeToEnd;
    public int Points;

    public int redKeys = 0;
    public int greenKeys = 0;
    public int goldKeys = 0;


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
        PickUpCheck();
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

    void PickUpCheck() {
        if (Input.GetKeyDown(KeyCode.L)) {
            Debug.Log("Time: " + timeToEnd);
            Debug.Log("Points: " + Points);
            Debug.Log("Red Keys: " + redKeys + "GreenKeys: " + greenKeys + "GoldKeys: " + goldKeys);
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

    public void AddPoints(int points) {
        Points += points;
    }

    public void AddTime(int timeToAdd) {
        timeToEnd = timeToAdd;
    }
    public void FreezTime(int freez) {
        CancelInvoke("Stopper");
        InvokeRepeating("Stopper", freez, 1);
    }

    public void AddKey(KeyColor keyColor) {
        if (keyColor == KeyColor.Red) {
            redKeys++;
        }
        else if (keyColor == KeyColor.Green) {
            greenKeys++;
        }
        else {
            goldKeys++;
        }
    }
}
