using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AppStartManager : MonoBehaviour
{
    public GameObject AppStartCanvas;
    public GameObject QuitCanvas;
    public GameObject CreditsCanvas;
    public GameObject AfterStartCanvas;
    public GameObject TutorialCanvas;
    public GameObject Apple;
    public GameObject AfterTutorialCanvas;
    public GameObject WhatToDoCanvas;
    public GameObject GoToGameCanvas;
    public GameObject MovementCanvas;

    private void Awake()
    {
        Camera.main.backgroundColor = Color.black;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void YouSure()
    {
        AppStartCanvas.SetActive(false);
        QuitCanvas.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void NoQuitButton()
    {
        QuitCanvas.SetActive(false);
        AppStartCanvas.SetActive(true);
        AfterTutorialCanvas.SetActive(false);
        GoToGameCanvas.SetActive(false);
    }

    public void Credits()
    {
        QuitCanvas.SetActive(false);
        AppStartCanvas.SetActive(false);
        CreditsCanvas.SetActive(true);
    }

    public void BackButton()
    {
        AppStartCanvas.SetActive(true);
        CreditsCanvas.SetActive(false);
    }

    public void StartButton()
    {
        AppStartCanvas.SetActive(false);
        AfterStartCanvas.SetActive(true);
    }

    public void YesTutorial()
    {
        AfterStartCanvas.SetActive(false);
        WhatToDoCanvas.SetActive(true);
    }

    public void SpawnApple()
    {
        Apple.SetActive(true);
    }

    public void Next()
    {
        AfterTutorialCanvas.SetActive(true);
        TutorialCanvas.SetActive(false);
    }

    public void WhatToNext()
    {
        WhatToDoCanvas.SetActive(false);
        MovementCanvas.SetActive(true);
    }

    public void AfterMovement()
    {
        MovementCanvas.SetActive(false);
        TutorialCanvas.SetActive(true);
    }

    public void NoTutorial()
    {
        AfterStartCanvas.SetActive(false);
        GoToGameCanvas.SetActive(true);
    }
}
