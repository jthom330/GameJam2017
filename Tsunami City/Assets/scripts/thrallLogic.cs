using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thrallLogic : MonoBehaviour {

	public GameObject home;
	public GameObject[] drops;
	public int maxStam;
	public float speed;
	public int yieldPerJob;

	private Rigidbody2D rigidbody;
	//private Animator animator;

	private GameObject anchor;
	private int stamina;
	private int yieldInt;

	private bool isWalking;
	private bool isWorking;
	private bool isBeingDragged;
	private bool isDraggable;

	// Use this for initialization
	private void Start()
	{
		rigidbody = GetComponent<Rigidbody2D>();
		//animator = GetComponent<Animator>();
		anchor = home;
		yieldInt = Mathf.RoundToInt(maxStam / yieldPerJob);
		isWorking = false;
		stamina = maxStam;
		isDraggable = true;
		isBeingDragged = false;
	}
	
	// Update is called once per frame
	private void Update()
	{
		if (stamina <= 0 && isWorking == true)
		{
			isWorking = false;
			stamina = maxStam;
			anchor = home;
			//teleport home
			transform.position = new Vector2 (anchor.transform.position.x, anchor.transform.position.y);
			isDraggable = true;
		}
		else if (isWorking == true)
		{
			stamina -= 1;
			if (stamina % yieldInt == 0)
			{
				//give dactyl
				GameObject toDrop = anchor.GetComponent<ResourceVariables>().getRandomDrop();
				GameObject drop = Instantiate(toDrop, new Vector2(transform.position.x, transform.position.y + 1), Quaternion.identity) as GameObject;
			}
		}

		//wander around anchor logic
		if (isWalking == false)
		{
			StartCoroutine(wander());
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (isBeingDragged == true && other.gameObject.CompareTag("Resource"))
		{
			anchor = other.gameObject;
			isWorking = true;
			isBeingDragged = false;
			isDraggable = false;
		}
	}

	IEnumerator wander()
	{
		isWalking = true;

		float moveTime = Random.Range(0f, 2f);
		float idleTime = Random.Range(0f, 1f);

		int direction = (Random.value < 0.5f) ? -1 : 1;

		GetComponent<Rigidbody2D>().velocity = new Vector2(direction*speed, 0);
		yield return new WaitForSeconds(moveTime);

		GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
		yield return new WaitForSeconds(idleTime);

		isWalking = false;
	}

	//This function is called when the behaviour becomes disabled or inactive.
	private void OnDisable()
	{
		GameObject drop = Instantiate(drops[Random.Range(0, drops.Length)], new Vector2(transform.position.x, transform.position.y), Quaternion.identity) as GameObject;
	}
}