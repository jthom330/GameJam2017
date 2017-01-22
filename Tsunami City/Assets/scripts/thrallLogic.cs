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
    private GameObject resourceTrigger;
    private int stamina;
	private int yieldInt;

	private bool isWalking;
	private bool isWorking;
	private bool isBeingDragged;
	private bool isDraggable;
    private bool isTriggered;

    float grav;
    Vector2 homePos;
    public GameObject corps;

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
        isTriggered = false;

        homePos = home.transform.position;
    }
	
	// Update is called once per frame
	private void Update()
	{
        

        if (stamina <= 0 && isWorking == true)
		{

            if (home == null)
            {
                Destroy(gameObject);

                //GetComponent(thrallLogic).enabled = false;
            }

            isWorking = false;
			stamina = maxStam;
			anchor = home;
			//teleport home
			transform.position = new Vector2 (anchor.transform.position.x, anchor.transform.position.y);
			isDraggable = true;

            foreach (Transform child in transform)
            {
                child.GetComponent<SpriteRenderer>().enabled = true;
            }
        }
		else if (isWorking == true)
		{
			stamina -= 1;
			if (stamina % yieldInt == 0)
			{
				//give dactyl
				GameObject toDrop = anchor.GetComponent<ResourceVariables>().getRandomDrop();
				GameObject drop = Instantiate(toDrop, new Vector2(anchor.transform.position.x - 15, anchor.transform.position.y + 20), Quaternion.identity) as GameObject;
			}
		}

		//wander around anchor logic
		if (isWalking == false)
		{
			StartCoroutine(wander());
		}
	}

    private void OnMouseDown()
    {
        if (isDraggable == true)
        {
            isBeingDragged = true;
            grav = rigidbody.gravityScale;
            rigidbody.gravityScale = 0;
        }
    }

    private void OnMouseDrag()
    {
        if (isDraggable == true)
        {
            Vector2 temp = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            transform.position = temp;
        }
    }

    private void OnMouseUp()
    {
        if (isDraggable == true)
        {
            rigidbody.gravityScale = grav;
            Vector3 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 dir = (MousePos - transform.position) / 5;
            rigidbody.velocity = new Vector2(rigidbody.velocity.x + dir.x * 100f, rigidbody.velocity.y + dir.y * 100f);
            isBeingDragged = false;
        }
        if (isTriggered == true)
        {
            anchor = resourceTrigger;
            isWorking = true;
            isDraggable = false;

            foreach (Transform child in transform)
            {
                child.GetComponent<SpriteRenderer>().enabled = false;
            }
        }
    }


    void OnTriggerEnter2D(Collider2D other)
	{
        if (other.gameObject.CompareTag("Resource"))
        {
            isTriggered = true;
            resourceTrigger = other.gameObject;
        }
	}

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Resource"))
        {
            isTriggered = false;
            resourceTrigger = null;
        }
    }

    IEnumerator wander()
	{
        if (isBeingDragged == false)
        {
            isWalking = true;

            float moveTime = Random.Range(0f, 2f);
            float idleTime = Random.Range(0f, 1f);

            int direction = (Random.value < 0.5f) ? -1 : 1;

            gameObject.transform.localScale = new Vector2(gameObject.transform.localScale.x * direction, gameObject.transform.localScale.y);

            GetComponent<Rigidbody2D>().velocity = new Vector2(direction * speed, GetComponent<Rigidbody2D>().velocity.y);
            yield return new WaitForSeconds(moveTime);

            GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
            yield return new WaitForSeconds(idleTime);

            isWalking = false;
        }
	}

	//This function is called when the behaviour becomes disabled or inactive.
	private void OnDestroy()
	{
        //Instantiate(corps, homePos, Quaternion.identity);
        Instantiate(corps, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
    }
}