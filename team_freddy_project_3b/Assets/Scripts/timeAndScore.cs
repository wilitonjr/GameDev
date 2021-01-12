using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class timeAndScore : MonoBehaviour
{
    public Text timerText;
    public static float timer = 0f;
    Scene currScene;
    string sceneName;
    public GameObject WinUI;
    float startTime;

    public Text bestTime;
    float currentBestTime = 999f;
    float roundedTime = 0f;
    float finalTimer;

    void Start()
    {
        Time.timeScale = 1f;
        startTime = Time.time;
        roundedTime = 0f;
        WinUI.gameObject.SetActive(false);
        float tempTimer = PlayerPrefs.GetFloat("besttime");
        if(tempTimer == 0f){
            PlayerPrefs.SetFloat("besttime", 999f);
        }
    }
    
    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (sceneName == "MenuScene")
        {
            Destroy(this);
        }
        currScene = SceneManager.GetActiveScene();
        sceneName = currScene.name;

        timer = Time.time - startTime;
        
        roundedTime = (Mathf.Round(timer * 1f)) / 1f;
        timerText.text = "Timer: " + roundedTime + " Seconds";
        
        finalTimer = (float)roundedTime;
        

        if (PlayerController.endLevel == true)
        {
            
            if (sceneName == "SceneLevel3")
            {
                
                Time.timeScale = 0f;
                currentBestTime = PlayerPrefs.GetFloat("besttime");

                Debug.Log("Final Timer: " + finalTimer);
                Debug.Log("currentBestTime: " + currentBestTime);

                if (finalTimer < currentBestTime)
                {
                    PlayerPrefs.SetFloat("besttime", finalTimer);
                    
                }
                currentBestTime = PlayerPrefs.GetFloat("besttime");
                bestTime.text = "Best Time: " + currentBestTime + " Seconds";
                WinUI.gameObject.SetActive(true);
                PlayerController.endLevel = false;
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                PlayerController.endLevel = false;
            }
        }
    }
}
