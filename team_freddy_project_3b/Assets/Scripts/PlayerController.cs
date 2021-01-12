using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public float movementSpeed = 4;
    public float jumpForce = 300;
    public float timeBeforeNextJump = 1.2f;
    private float canJump = 0f;
    public float _rotationSpeed = 180;
    private bool boneFound = false;
    Animator anim;
    Rigidbody rb;
    private AudioSource boneFoundSound, nextLevelSound;
    public static bool endLevel = false;
    private Vector3 rotation;
    private GameObject bone;  

     private void Awake(){
        this.boneFoundSound = this.GetComponent<AudioSource>();
    }
    
    
    void Start()
    {
        var aSounds = GetComponents<AudioSource>();
        boneFoundSound = aSounds[0];
        nextLevelSound = aSounds[1];

        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        // this.bone = GameObject.FindObjectOfType<Bone>();
        this.bone = GameObject.Find("Bone");
        // this.bone.transform.SetParent(Player);
    }

    void Update()
    {
        ControllPlayer();
    }

    void ControllPlayer()
    {
        //movement
        float moveVertical = Input.GetAxisRaw("Vertical");
        Vector3 movement = new Vector3(0.0f, 0.0f, moveVertical);
        movement = this.transform.TransformDirection(movement);    
        transform.Translate(movement * movementSpeed * Time.deltaTime, Space.World);
        
        
        //rotation
        this.rotation = new Vector3(0, Input.GetAxisRaw("Horizontal") * _rotationSpeed * Time.deltaTime, 0);
        this.transform.Rotate(this.rotation);
        
        
        
        // Movement/rotation animation
        if ((movement != Vector3.zero) || (rotation != Vector3.zero)) {
            anim.SetInteger("Walk", 1);
        }
        else {
            anim.SetInteger("Walk", 0);
        }

        // Jump
        if (Input.GetButtonDown("Jump") && Time.time > canJump) {
                rb.AddForce(0, jumpForce, 0);
                canJump = Time.time + timeBeforeNextJump;
                anim.SetTrigger("jump");
        }

        if (boneFound == true){
            this.bone.transform.localPosition = this.transform.localPosition + (this.transform.up * 1) + (this.transform.forward * 1.0f);
            // this.transform.position = this.initialPosition + Vector3.left * movement;
            this.bone.transform.Rotate(this.rotation);
            
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "Bone")
        {
            Debug.Log("Bone found!");
            this.boneFoundSound.Play();
            boneFound = true;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "endLevel")
        {
            if (boneFound == true){
                StartCoroutine (finishLevel());           
            }
        }
    }

    IEnumerator finishLevel()
    {
        Time.timeScale = 0f;
        this.nextLevelSound.Play();
        yield return new WaitWhile (()=> this.nextLevelSound.isPlaying);
        Time.timeScale = 1f;
        endLevel = true;
    }
}