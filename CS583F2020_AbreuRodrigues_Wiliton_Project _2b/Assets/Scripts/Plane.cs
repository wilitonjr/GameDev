using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//
// Freddy's plane controller
//

public class Plane : MonoBehaviour
{
    //variables
    private Rigidbody2D physics;
    private GameDirector gameDirector;
    private Vector3 initialPosition;
    private bool applyImpulse;
    private Animator animator;
    
    
    [SerializeField]
    private float force;

    
    private void Awake (){
        this.initialPosition = this.transform.position; // get initial position
        this.physics = this.GetComponent<Rigidbody2D>();
        this.animator = this.GetComponent<Animator>();
        
    }
    
    private void Start (){
        this.gameDirector =  GameObject.FindObjectOfType<GameDirector>(); 
        
    }
    
    
    // GameLoop
    private void Update()
    {
        // if (Input.GetButtonDown("Fire1")  || Input.GetKeyDown("space") ){
            
            // this.applyImpulse = true;
        // }
        this.animator.SetFloat("SpeedY", this.physics.velocity.y);
    }


    //
    // ****** use FixeddUpdate when dealing with force ***** 
    // physics update
    //
    void FixedUpdate() {
        if (this.applyImpulse){
            this.ApplyImpulse();
            Debug.Log("Button Pressed");
        }
    }

    public void ImpulseUp(){
        this.applyImpulse = true;

    }
    
    // do it after restart
    public void RestartPosition(){
        this.transform.position = this.initialPosition;
        this.physics.simulated = true;
    }
    
    
    //makes the plane go up
    private void ApplyImpulse(){
        this.physics.velocity = Vector2.zero;
        this.physics.AddForce(Vector2.up * this.force, ForceMode2D.Impulse);
        this.applyImpulse = false;
    }
    
    //detects the crash
    private void OnCollisionEnter2D(Collision2D collision){
        this.physics.simulated = false;
        this.gameDirector.EndGame();
    }
}
