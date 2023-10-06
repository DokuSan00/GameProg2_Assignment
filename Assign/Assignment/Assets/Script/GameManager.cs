using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    int curScore;
    int lastCheckedScore = 0;

    Text scoreText;

    private void Awake() {
        if (Instance != null && Instance != this) 
        {
            Destroy(this); 
        }
        else 
        { 
            Instance = this; 
        }

        if (SceneManager.GetActiveScene().buildIndex == 0) return;
        DontDestroyOnLoad(Instance);
        updateText();
    }

    void Update() {
        updateText();
    }

    void refText() {
        if (scoreText == null)
            scoreText = GameObject.Find("Score").GetComponent<Text>();
    }

    public void AddScore(int score) {
        curScore += score;
        Win();
    }

    void updateText() {
        if (SceneManager.GetActiveScene().buildIndex == 0) return;
        refText();
        scoreText.text = "Score: " + curScore;
    }

    public void Win() {
        if (curScore >= 400) {
            Debug.Log("Win");
        }
    }

    public void Play() {
        lastCheckedScore = 0;
        curScore = lastCheckedScore;
        SceneManager.LoadScene(1);
    }

    public void Exit() {
        Application.Quit();
    }

    public void NextScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        lastCheckedScore = curScore;
    }

    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        curScore = lastCheckedScore;
    }

    public void MainMenu() {
        SceneManager.LoadScene(0);
    }
}
