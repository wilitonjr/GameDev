using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//
// Class to contorll   floor and backgorund move
//
public class Carousel : MonoBehaviour
{
    [SerializeField]
    private SharedVariableTypeFloat speed;
    
    private Vector3 initialPosition;
    private float realSize;
    
    private void Awake(){
        this.initialPosition = this.transform.position;
        float size = this.GetComponent<SpriteRenderer>().size.x;
        float scale = this.transform.localScale.x;
        this.realSize = size * scale;
    } 


    // Gameloop
    void Update()
    {
        float movement = Mathf.Repeat(this.speed.value * Time.time, this.realSize);
        this.transform.position = this.initialPosition + Vector3.left * movement;
    }
}
