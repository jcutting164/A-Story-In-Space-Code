using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeController : MonoBehaviour
{
    // Start is called before the first frame update
	public float moveSpeed;
	private bool isMoving;
	private Rigidbody2D myRigidBody;
	public float timeBetweenMove;
	private float timeBetweenMoveCounter;
	public float timeToMove;
	private float timeToMoveCounter;
	private Vector3 moveDirection;

	public float waitToReload;
	private bool isReloading;

	private GameObject player;

    void Start()
    {
		myRigidBody= GetComponent<Rigidbody2D>();

        timeBetweenMoveCounter= timeBetweenMove;
		timeToMoveCounter=timeToMove;
    }

    // Update is called once per frame
    void Update()
    {

		if(isReloading){
			waitToReload-=Time.deltaTime;
			if(waitToReload<0f){
				isReloading=false;
				Application.LoadLevel(Application.loadedLevel);
				player.SetActive(true);
			}

		}

		if(isMoving){
			timeToMoveCounter-= Time.deltaTime;
			myRigidBody.velocity=moveDirection;

			if(timeToMoveCounter < 0f){

				isMoving=false;
				timeBetweenMoveCounter=Random.Range(timeBetweenMove*.75f,timeBetweenMove*1.25f);
			}

		}else{

			timeBetweenMoveCounter -= Time.deltaTime;
			myRigidBody.velocity= new Vector2(0,0);


			if(timeBetweenMoveCounter<0f){
				isMoving=true;
				timeToMoveCounter=Random.Range(timeToMove*.75f,timeToMove*1.25f);

				moveDirection=new Vector3(Random.Range(-1f,1f)*moveSpeed, Random.Range(-1f,1f)*moveSpeed,0f);
			}
		}
    }


	void OnCollisionEnter2D(Collision2D other){
	/*	if(other.gameObject.name == "Player"){
			other.gameObject.SetActive(false);
			isReloading=true;
			player=other.gameObject;

		}
	*/
	}

}
