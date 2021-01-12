using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandClick : MonoBehaviour{

    
    private SpriteRenderer image;
    
    
    
    private void Awake()
    {
        this.image = this.GetComponent<SpriteRenderer>();
    }

    
    private void Update()
    {
        if (Input.GetButtonDown("Fire1") ){
            this.Close();
        }    
    }
    
    private void Close(){
        this.image.enabled = false;
    }
}
