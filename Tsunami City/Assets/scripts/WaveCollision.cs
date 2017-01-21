using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveCollision : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D other)
    {
       if (other.tag != "ground")
       {
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();

           //TODO: multiply by wave number scaler
           rb.velocity = new Vector2(20f, 0);

            //TODO: apply damage to block tags
            other.GetComponent<Health>().ApplyDamage();

            Vector2 currentVelocity = GetComponent<Rigidbody2D>().velocity;
           GetComponent<Rigidbody2D>().velocity = Vector2.Lerp(currentVelocity, new Vector2(currentVelocity.x - 4f, currentVelocity.y - 5f), .1f);
        }
        
    }


    private void OnTriggerStay2D(Collider2D other)
    {

        if (other.tag != "ground")
        {
            if ((other.GetComponent<Rigidbody2D>().velocity.x < GetComponent<Rigidbody2D>().velocity.x) )
            {
                Vector2 currentVelocity = other.GetComponent<Rigidbody2D>().velocity;

                //TODO: scaler from wave generator
                other.GetComponent<Rigidbody2D>().velocity = Vector2.Lerp(currentVelocity, new Vector2(currentVelocity.x + 100f, 0), .05f);


            }
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {

    }
}
