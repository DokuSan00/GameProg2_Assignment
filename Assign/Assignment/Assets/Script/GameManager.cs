using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    int curScore;
    int lastCheckedScore = 0;
    

    private void Awake() {
        if (Instance == null)
            Instance = this;
        DontDestroyOnLoad(Instance);
    }

    public void AddScore() {
        curScore += 50;
        Debug.Log(curScore);
        Win();
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
}
