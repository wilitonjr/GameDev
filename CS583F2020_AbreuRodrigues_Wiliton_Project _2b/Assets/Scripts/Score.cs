using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//
// Class to handle the score when obstacle passes
// through  plane. Also saves Best Score.
//
public class Score : MonoBehaviour{
    
    [SerializeField]
    private Text scoreText;

    private int score;
    private AudioSource scoreSound;
    
    private void Awake(){
        this.scoreSound = this.GetComponent<AudioSource>();
    }
    
    
    // increases score when pass an obstacle
    public void AddScore(){
        Debug.Log("Score: "+ this.score);
        this.score++;
        this.scoreText.text = this.score.ToString();
        this.scoreSound.Play();
        
    }
    
    // restarts the current score
    // --> call when gameover
    public void RestartScore(){
        Debug.Log("Score restarted");
        this.score = 0;
         this.scoreText.text = this.score.ToString();
    }

    // save my best score ever
    public void SaveBestScore(){
        int currentBestScore = PlayerPrefs.GetInt("bestscore");

        // compares my current score with the best score recorded
        if (this.score > currentBestScore){
            PlayerPrefs.SetInt("bestscore", this.score);
        }
        
        Debug.Log("Best Score (saved): "+PlayerPrefs.GetInt("bestscore"));
    }
    
    
   
}
