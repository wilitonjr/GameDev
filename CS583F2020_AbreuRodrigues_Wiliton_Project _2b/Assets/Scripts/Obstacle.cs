using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    
    [SerializeField]
    private SharedVariableTypeFloat speed;
    
    [SerializeField]
    private float range;
    
    private Vector3 planePosition;
    private bool scored;
    private Score score;
        
    private void Awake (){
        this.transform.Translate(Vector3.up * Random.Range(-range, range));
        Debug.Log("Obstacle created");
    }
    
    private void Start (){
        this.planePosition = GameObject.FindObjectOfType<Plane>().transform.position;
        this.score = GameObject.FindObjectOfType<Score>();
    }


    // GameLoop
    private void Update()
    {
        
        this.transform.Translate(Vector3.left * this.speed.value * Time.deltaTime);
        
        // if obstacle position is less then plane position, SCORE!
        if (!this.scored && this.transform.position.x < this.planePosition.x){
            this.scored = true;
            this.score.AddScore();
            Debug.Log("Score++");
        }
    }
    
    // detects the collision to destroy the obstacle
    // call to destroy them
    private void OnTriggerEnter2D (Collider2D collision){
        this.Destroy();
    }
    
    // destroy the obstacle when it leaves the screen
    public void Destroy(){
        Debug.Log("Obstacle colided and destroyed");
        GameObject.Destroy(this.gameObject);
    }
}