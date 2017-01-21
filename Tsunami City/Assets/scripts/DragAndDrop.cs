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


    bool selected = false;
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
        Vector3 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 dir = MousePos - transform.position;

        dir.Normalize();

        objRB.gravityScale = grav;
        objRB.velocity = new Vector2(objRB.velocity.x + dir.x * 10f, objRB.velocity.y + dir.y * 10f);
    }
}
