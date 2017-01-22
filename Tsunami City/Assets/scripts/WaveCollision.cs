using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveCollision : MonoBehaviour {

    float multiplier;
    public GameObject rightBound;
    public GameObject rock;
    public GameObject wood;
    public GameObject corps;

    private void OnTriggerEnter2D(Collider2D other)
    {
       if (other.tag != "ground")
       {
            if (other.tag == "block")
            {
                multiplier = WaveSpawn.multiplier;

                Rigidbody2D rb = other.GetComponent<Rigidbody2D>();

                //TODO: multiply by wave number scaler
                rb.velocity = new Vector2(20f * multiplier, 0);

                //TODO: apply damage to block tags
                other.GetComponent<Health>().ApplyDamage();

                Vector2 currentVelocity = GetComponent<Rigidbody2D>().velocity;
                GetComponent<Rigidbody2D>().velocity = Vector2.Lerp(currentVelocity, new Vector2(currentVelocity.x - 10f, currentVelocity.y - 10f), .1f);

                gameObject.transform.localScale = Vector3.Lerp(gameObject.transform.localScale, new Vector3(GetComponent<Rigidbody2D>().velocity.x / 20f, GetComponent<Rigidbody2D>().velocity.x / 20f, 1f), .1f);
            }
            else if (other.tag == "people")
            {
                //may want to apply force on collision later
                GameObject temp = Instantiate(corps, new Vector2(other.transform.position.x, other.transform.position.y), other.transform.rotation);

                Destroy(other.gameObject);
            }
            else if (other.tag == "Resource")
            {
                
                GameObject temp = Instantiate(wood, new Vector2(other.transform.position.x, other.transform.position.y), Quaternion.identity);
                temp = Instantiate(wood, new Vector2(other.transform.position.x, other.transform.position.y), Quaternion.identity);
                temp = Instantiate(wood, new Vector2(other.transform.position.x, other.transform.position.y), Quaternion.identity);
                temp = Instantiate(wood, new Vector2(other.transform.position.x, other.transform.position.y), Quaternion.identity);
                temp = Instantiate(wood, new Vector2(other.transform.position.x, other.transform.position.y), Quaternion.identity);
                temp = Instantiate(wood, new Vector2(other.transform.position.x, other.transform.position.y), Quaternion.identity);
                temp = Instantiate(rock, new Vector2(other.transform.position.x, other.transform.position.y), Quaternion.identity);
                temp = Instantiate(rock, new Vector2(other.transform.position.x, other.transform.position.y), Quaternion.identity);
                temp = Instantiate(rock, new Vector2(other.transform.position.x, other.transform.position.y), Quaternion.identity);
                temp = Instantiate(rock, new Vector2(other.transform.position.x, other.transform.position.y), Quaternion.identity);
                temp = Instantiate(rock, new Vector2(other.transform.position.x, other.transform.position.y), Quaternion.identity);

                Destroy(other.gameObject);
            }
            else if (other.tag == "house")
            {

                GameObject temp = Instantiate(wood, new Vector2(other.transform.position.x, other.transform.position.y), Quaternion.identity);
                temp = Instantiate(wood, new Vector2(other.transform.position.x, other.transform.position.y), Quaternion.identity);
                temp = Instantiate(wood, new Vector2(other.transform.position.x, other.transform.position.y), Quaternion.identity);
                temp = Instantiate(wood, new Vector2(other.transform.position.x, other.transform.position.y), Quaternion.identity);
                temp = Instantiate(wood, new Vector2(other.transform.position.x, other.transform.position.y), Quaternion.identity);
                temp = Instantiate(wood, new Vector2(other.transform.position.x, other.transform.position.y), Quaternion.identity);
                temp = Instantiate(rock, new Vector2(other.transform.position.x, other.transform.position.y), Quaternion.identity);
                temp = Instantiate(rock, new Vector2(other.transform.position.x, other.transform.position.y), Quaternion.identity);
                temp = Instantiate(rock, new Vector2(other.transform.position.x, other.transform.position.y), Quaternion.identity);
                temp = Instantiate(rock, new Vector2(other.transform.position.x, other.transform.position.y), Quaternion.identity);
                temp = Instantiate(rock, new Vector2(other.transform.position.x, other.transform.position.y), Quaternion.identity);


                Destroy(other.gameObject);
            }
         
        }
        
    }


    /*private void OnTriggerStay2D(Collider2D other)
    {

        if (other.tag != "ground")
        {
            if ((other.GetComponent<Rigidbody2D>().velocity.x < GetComponent<Rigidbody2D>().velocity.x) )
            {
                Vector2 currentVelocity = other.GetComponent<Rigidbody2D>().velocity;

                //TODO: scaler from wave generator
               // other.GetComponent<Rigidbody2D>().velocity = Vector2.Lerp(currentVelocity, new Vector2((currentVelocity.x + 50f)* multiplier, 0), .05f);


            }
        }
    }*/


    private void Update()
    {
        if(transform.position.x > rightBound.transform.position.x)
        {
            Destroy(gameObject);
        }
           
    }
}
