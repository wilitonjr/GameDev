using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    private Transform playerTransform;

    public float offsetz;
    public float offsety;
    private Vector3 rotation;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        rotation = new Vector3(playerTransform.position.x, playerTransform.position.y + 8.0f, playerTransform.position.z + 7.0f);
    }

    void LateUpdate()
    {
        Vector3 temp = transform.position;
        temp.x = playerTransform.position.x;
        temp.y = playerTransform.position.y;
        temp.y += offsety;
        temp.z = playerTransform.position.z;
        temp.z += offsetz;

        rotation = Quaternion.AngleAxis (Input.GetAxis("Mouse X") * 4.0f, Vector3.up) * rotation;


        transform.position = temp + rotation;
        transform.LookAt(playerTransform.position);
    }
}
