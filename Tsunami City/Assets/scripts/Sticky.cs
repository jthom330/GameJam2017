using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sticky : MonoBehaviour {

    public AudioClip[] sounds;

    void OnCollisionEnter2D(Collision2D other)
    {
        int rand = Random.Range(0, sounds.Length);
        this.GetComponent<AudioSource>().PlayOneShot(sounds[rand]);       
    }

    void OnCollisionStay2D(Collision2D other)
    {
        
            Rigidbody2D rb = GetComponent<Rigidbody2D>();

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
