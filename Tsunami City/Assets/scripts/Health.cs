using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	public int maxHealth;
    private int spriteNum = 0;
    public Sprite[] sprites;
    
    
    public void ApplyDamage()
    {
        maxHealth--;

        //TODO: switch sprites


        if (maxHealth <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            this.GetComponent<SpriteRenderer>().sprite = sprites[spriteNum];
            spriteNum++;
        }
    }
}
