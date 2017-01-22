using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsEffects : MonoBehaviour {

    public AudioClip[] sounds;

    void OnCollisionEnter2D(Collision2D other)
    {
        int rand = Random.Range(0, sounds.Length);
        this.GetComponent<AudioSource>().PlayOneShot(sounds[rand]);
    }

    
}

