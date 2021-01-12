using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//
// Class to control the gameover screen.
// This screen/image appears when Freddy crashes the plane
//
public class GameOverInterface : MonoBehaviour
{
    [SerializeField]
    private Text bestScoreValue;

    [SerializeField]
    private GameObject gameOverImage; //wordArt GameOver image


    public void ShowGameOverInterface(){
        this.UpdateInterface();
        this.gameOverImage.SetActive(true);
    }


    public void HideGameOverInterface(){
        this.gameOverImage.SetActive(false);
    }

    private void UpdateInterface(){
        int bestScore = PlayerPrefs.GetInt("bestscore");
        this.bestScoreValue.text = bestScore.ToString();
    }
}
