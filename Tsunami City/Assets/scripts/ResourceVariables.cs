using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceVariables : MonoBehaviour {

	public GameObject[] drops;

	public GameObject[] getDrops()
	{
		return drops;
	}

	public GameObject getRandomDrop()
	{
		GameObject drop = drops[Random.Range (0, drops.Length)];
		return drop;
	}
}
