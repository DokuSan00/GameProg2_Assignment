using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInteractionManager : MonoBehaviour
{
    public void MainMenu() {
        GameManager.Instance.MainMenu();
    }

    public void Play() {
        GameManager.Instance.Play();
    }

    public void Exit() {
        GameManager.Instance.Exit();
    }
}
