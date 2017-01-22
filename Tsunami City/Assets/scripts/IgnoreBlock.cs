using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreBlock : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "block")
        {
           // Physics.IgnoreCollision(other.collider, collider);
        }
    }
	
}
