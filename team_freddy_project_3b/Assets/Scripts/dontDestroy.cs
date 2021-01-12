using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class dontDestroy : MonoBehaviour
{
    Scene currScene;
    string sceneName;

    void Update()
    {
        currScene = SceneManager.GetActiveScene();
        sceneName = currScene.name;
        if (sceneName == "MenuScene")
        {
            Destroy(this);
        }
    }
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
