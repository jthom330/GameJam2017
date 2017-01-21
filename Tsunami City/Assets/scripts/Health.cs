using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	public int maxHealth;
    
    
    public void ApplyDamage()
    {
        maxHealth--;

        if(maxHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
