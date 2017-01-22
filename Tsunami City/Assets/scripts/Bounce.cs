using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour {

    private int count = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("people"))
        {
            count++;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("people"))
        {
            count--;
        }
    }

    // Update is called once per frame
    void Update () {

        if(count > 0)
        {
            gameObject.GetComponent<Animator>().SetBool("working", true);
        }
        else
        {
            gameObject.GetComponent<Animator>().SetBool("working", false);
        }
		
	}
}
