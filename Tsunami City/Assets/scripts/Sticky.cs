using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sticky : MonoBehaviour {

    float oldDrag;
    float oldAngDrag;

    void OnCollisionStay2D(Collision2D other)
    {

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        oldDrag = rb.drag;
        oldAngDrag = rb.angularDrag;

        rb.drag = 25;
        rb.angularDrag = 25;
    }

    void OnCollisionExit2D(Collision2D other)
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        rb.drag = 0f;
        rb.angularDrag = .05f;
    }
}
