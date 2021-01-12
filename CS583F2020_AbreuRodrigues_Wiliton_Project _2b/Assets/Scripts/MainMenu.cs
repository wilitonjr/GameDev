using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    private int sceneNumber;

    IEnumerator Start() {
        sceneNumber = SceneManager.GetActiveScene().buildIndex;
        
        if(sceneNumber == 0){
            yield return new WaitForSeconds(3);
            Debug.Log("sceneNumber: " + sceneNumber.ToString());
            SceneManager.LoadScene(1);
            

        }
        

    }

    // IEnumerator ToMainMenu(){
        
    //     yield return new WaitForSeconds(3);
    //     SceneManager.LoadScene(1);
    // }



    public void PlayGame()
    {
        SceneManager.LoadScene(2);
        Debug.Log("PLAY GAME btn pressed");
    }

    //     public void BackToMenu(){
    //         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    //         Debug.Log("Back to Menu pressedf");
    //     }

    public void QuitGame()
    {
        #if UNITY_EDITOR
                    UnityEditor.EditorApplication.isPlaying = false; //set playmode to stop
        #else
                Application.Quit();
        #endif
                Debug.Log("Quit pressed");
    }
}
