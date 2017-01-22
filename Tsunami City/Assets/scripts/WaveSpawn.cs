using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawn : MonoBehaviour {

    public float seconds;
    public static float multiplier = 1.2f;
    public GameObject wave;

	// Use this for initialization
	void Start () {
        StartCoroutine(SpawnWave());
	}

    IEnumerator SpawnWave()
    {
        yield return new WaitForSeconds(seconds);

        GameObject inst = Instantiate(wave, new Vector2(transform.position.x, transform.position.y), Quaternion.identity) as GameObject;
       
        inst.GetComponent<Rigidbody2D>().velocity = new Vector2(20f * multiplier, -1f);

        inst.transform.localScale = new Vector3(inst.GetComponent<Rigidbody2D>().velocity.x/20f, inst.GetComponent<Rigidbody2D>().velocity.x / 20f, 1f);

        multiplier = multiplier * multiplier;

        StartCoroutine(SpawnWave());
    }

    public float GetMultiplier()
    {
        return multiplier;
    }
	
	
}
