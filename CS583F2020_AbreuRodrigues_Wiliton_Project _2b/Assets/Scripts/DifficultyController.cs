using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//
// Controlls  difficulty
//

public class DifficultyController : MonoBehaviour
{
    [SerializeField]
    private float timeToReachMaxSpeed;

    private float timePassed;
    public float Difficulty {get; private set;} // read-only variable

    // Update is called once per frame
    void Update()
    {
        this.timePassed += Time.deltaTime; // increases my timer
        this.Difficulty = this.timePassed / this.timeToReachMaxSpeed;
        this.Difficulty = Mathf.Min(1, this.Difficulty); //limit my difficulty to Max of 1. btw 0 and 1
        Debug.Log("difficulty: " + this.Difficulty);
        
    }

    public void RestartDifficulty()
    {
        this.timePassed = 0.0f;
        this.Difficulty = 0.0f;
        Debug.Log("difficulty restarted");
        
    }
}
