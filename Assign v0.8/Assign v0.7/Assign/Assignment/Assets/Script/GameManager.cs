using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    static int score = 0;

    private void Awake() {
        if (Instance == null)
            Instance = this;
        DontDestroyOnLoad(Instance);
    }

    public void AddScore() {
        score += 50;
        Debug.Log(score);
        Win();
    }

    public void Win() {
        if (score >= 400) {
            Debug.Log("Win");
        }
    }

    public void Play() {
        score = 0;
        SceneManager.LoadScene(1);
    }

    public void Exit() {
        Application.Quit();
    }

    public void NextScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
