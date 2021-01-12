using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class quitButton : MonoBehaviour
{
    public GameObject quitConfirm;
    public GameObject UI;
    public GameObject quit;
    public GameObject WinUI;

   void Start()
    {
        quit.gameObject.SetActive(true);
        quitConfirm.gameObject.SetActive(false);
    }

   public void quitClick()
    {
        Time.timeScale = 0f;
        quitConfirm.gameObject.SetActive(true);
    }

    public void yesClick()
    {
        SceneManager.LoadScene("MenuScene");
        UI.gameObject.SetActive(false);
        WinUI.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    public void noClick()
    {
        quitConfirm.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
}
