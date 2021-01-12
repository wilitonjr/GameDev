using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class howToPlay : MonoBehaviour
{
    public GameObject howtoplay;

    Scene currScene;
    string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        currScene = SceneManager.GetActiveScene();
        sceneName = currScene.name;
        howtoplay.gameObject.SetActive(false);
        if (sceneName == "SampleScene")
        {
            StartCoroutine(guide());
        }

        IEnumerator guide()
        {
            howtoplay.gameObject.SetActive(true);
            Time.timeScale = .1f;
            yield return new WaitForSeconds(3f);
            howtoplay.gameObject.SetActive(false);
            Time.timeScale = 1f;
        }
            
    }

}
