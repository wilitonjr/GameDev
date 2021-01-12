using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressedKey : MonoBehaviour
{
    private Plane plane;

    [SerializeField]
    private KeyCode key;

    
    private void Start()
    {
        this.plane = this.GetComponent<Plane>();
    }

    // gameloop 
    private void Update()
    {
        if (Input.GetKeyDown(this.key) || Input.GetButtonDown("Fire1")){
            this.plane.ImpulseUp();
        }
    }
}
