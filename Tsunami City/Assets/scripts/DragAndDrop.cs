using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour {

    Rigidbody2D objRB;
    float grav; 

    private void Awake()
    {
        objRB = GetComponent<Rigidbody2D>();
        
    }


    Vector2 mouseVel;
    

    private void OnMouseDown()
    {
       grav = objRB.gravityScale;
       objRB.gravityScale = 0;
    }

    private void OnMouseDrag()
    {
        Vector2 temp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        transform.position = temp;
    }

    private void OnMouseUp()
    {
        objRB.gravityScale = grav;
        Vector3 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 dir = (MousePos - transform.position)/5;

        Debug.Log(dir);

        objRB.velocity = new Vector2(objRB.velocity.x + dir.x * 100f, objRB.velocity.y + dir.y * 100f);
        
        
    }
}
