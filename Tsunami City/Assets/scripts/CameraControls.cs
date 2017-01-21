using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour {

    float X;
    float Y;

    float speed = .2f;

    public Transform left;
    public Transform right;
    public Transform up;
    public Transform down;

    float minX;
    float maxX;
    float minY;
    float maxY;
    private void Awake()
    {
        X = 0;
        Y = 0;

        minX = left.position.x;
        maxX = right.position.x;
        minY = down.position.y;
        maxY = up.position.y;
    }

    private void Update()
    {
        X = 0;
        Y = 0;

        //Left
        if (Input.GetAxis("Horizontal") < 0)
        {
            X = -speed;            
        }
        //Right
        else if (Input.GetAxis("Horizontal") > 0)
        {
            X = speed;
        }
        //Down
        if (Input.GetAxis("Vertical") < 0)
        {
            Y = -speed;
        }
        //Up
        else if (Input.GetAxis("Vertical") > 0)
        {
            Y = speed;
        }

       
        transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x + X, transform.position.y + Y, transform.position.z), 0.9f);

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, minX, maxX),
            Mathf.Clamp(transform.position.y, minY, maxY),
            Mathf.Clamp(transform.position.z, -10f, -10f)
            );
               
    }
        
    
}
