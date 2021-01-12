using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//
// Handles the creation of obstacles
//
public class ObstaclesGenerator : MonoBehaviour
{

    [SerializeField]
    private float timeBetweenObstaclesMin;

    [SerializeField]
    private float timeBetweenObstaclesMax;

    [SerializeField]
    private GameObject instructions;  

    private float timer;
    private DifficultyController difficultyController;

    private void Awake (){
        this.timer = this.timeBetweenObstaclesMin;
    }


    private void Start() {
        this.difficultyController = GameObject.FindObjectOfType<DifficultyController>();

    }


    // GameLoop
    void Update()
    {
        this.timer -= Time.deltaTime;
        if (this.timer < 0){
            
            
            GameObject.Instantiate(this.instructions, this.transform.position, Quaternion.identity);

            //time btw Min and Max
            this.timer = Mathf.Lerp(this.timeBetweenObstaclesMin, this.timeBetweenObstaclesMax, this.difficultyController.Difficulty);
        }
    }
}
