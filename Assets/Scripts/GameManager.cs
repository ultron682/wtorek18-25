using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    // Canvas
    public Text Text_time;
    public Text Text_redKey;
    public Text Text_greenKey;
    public Text Text_goldKey;
    public Image Image_snowFlake;
    public Text Text_crystal;
    public GameObject Text_PressE;

    public GameObject Panel_info;
    public Text Text_textInfo;



    void Start() {
        if (Instance == null)
            Instance = this;

        if (timeToEnd <= 0) {
            timeToEnd = 100;
        }

        Image_snowFlake.enabled = false;
        Text_time.text = timeToEnd.ToString();
        Panel_info.SetActive(false);
        Text_textInfo.text = "";
        Text_redKey.text = redKeys.ToString();
        Text_greenKey.text = greenKeys.ToString();
        Text_goldKey.text = goldKeys.ToString();
        Text_PressE.SetActive(false);

        InvokeRepeating("Stopper", 2, 1);
    }

    void Update() {
        PauseCheck();
        PickUpCheck();
    }

    void Stopper() {
        timeToEnd--;
        Text_time.text = timeToEnd.ToString();
        Image_snowFlake.enabled = false;

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
        MusicManager.Instance.ChangeMusic(MusicManager.Instance.pauseClip);
    }

    public void ResumeGame() {
        Debug.Log("Resume game");
        Time.timeScale = 1f;
        gamePaused = false;
        MusicManager.Instance.ChangeMusic(MusicManager.Instance.resumeClip);
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
            MusicManager.Instance.PlayClip(MusicManager.Instance.winClip);
        }
        else {
            Debug.Log("You Lose!!");
            MusicManager.Instance.PlayClip(MusicManager.Instance.loseClip);
        }
    }

    public void AddPoints(int points) {
        Points += points;
        Text_crystal.text = points.ToString();
    }

    public void AddTime(int timeToAdd) {
        timeToEnd += timeToAdd;
        Text_time.text = timeToEnd.ToString();
    }
    public void FreezTime(int freez) {
        CancelInvoke("Stopper");
        Image_snowFlake.enabled = true;
        InvokeRepeating("Stopper", freez, 1);
    }

    public void AddKey(KeyColor keyColor) {
        if (keyColor == KeyColor.Red) {
            redKeys++;
            Text_redKey.text = redKeys.ToString();
        }
        else if (keyColor == KeyColor.Green) {
            greenKeys++;
            Text_greenKey.text = greenKeys.ToString();
        }
        else {
            goldKeys++;
            Text_goldKey.text = goldKeys.ToString();
        }
    }
}
