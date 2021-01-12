using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//
// Class to control what happens in the game/scene
//
public class GameDirector : MonoBehaviour
{
    
    
    
    private Plane plane;
    private Score score;
    private GameOverInterface gameOverInterface;
    private DifficultyController difficultyController;
    
    
    public void Start(){
        Debug.Log("GameDirector | Start");
        this.plane = GameObject.FindObjectOfType<Plane>();
        this.score = GameObject.FindObjectOfType<Score>();
        this.gameOverInterface = GameObject.FindObjectOfType<GameOverInterface>();
        this.difficultyController = GameObject.FindObjectOfType<DifficultyController>();
    }
    


    // Defines what to do when plane crashes
   public void EndGame(){
       Time.timeScale = 0;
       this.score.SaveBestScore();
       this.gameOverInterface.ShowGameOverInterface();
       
    //    this.gameOverInterface.UpdateInterface();
   }
   
   // All things needed to restart game
   public void RestartGame(){
       Time.timeScale = 1;
       this.gameOverInterface.HideGameOverInterface();
       this.plane.RestartPosition();
       this.DestroyObstacles();
       this.score.RestartScore();
       this.difficultyController.RestartDifficulty();
    }
    
    // Destroy all obstacles before restart
    private void DestroyObstacles(){
        Obstacle [] obstacles = GameObject.FindObjectsOfType<Obstacle>();
        foreach(Obstacle obstacle in obstacles){
            obstacle.Destroy();
        }
    }
    
     public void BackToMenu(){
         this.RestartGame(); // reset game to return correctly
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        Debug.Log("Back to Menu pressedf");
    }
}
