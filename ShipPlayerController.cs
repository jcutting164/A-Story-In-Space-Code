using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipPlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D myRigidBody;
    public GameObject attack;
    public GameObject player;
    private Vector3 startCoords;
    private PlayerStats pStats;
    void Start()
    {
        myRigidBody=GetComponent<Rigidbody2D>();

        GetComponent<PlayerHealthManager>().playerMaxHealth=FindObjectOfType<PlayerHealthManager>().GetComponent<PlayerHealthManager>().playerMaxHealth;
        GetComponent<PlayerHealthManager>().playerCurrentHealth=FindObjectOfType<PlayerHealthManager>().GetComponent<PlayerHealthManager>().playerCurrentHealth;
        GetComponent<PlayerHealthManager>().flashLength=FindObjectOfType<PlayerHealthManager>().GetComponent<PlayerHealthManager>().flashLength;
        player=FindObjectOfType<PlayerController>().gameObject;
      //  FindObjectOfType<PlayerController>().gameObject.SetActive(false);
    //    gameObject.SetActive(false);
        enabled=false;
        startCoords=new Vector3(-6.28f, -.02f, 9.0078f);

        pStats=FindObjectOfType<PlayerStats>();


    }

    // Update is called once per frame
    void Update()
    {





      Debug.Log("test");
      if(Input.GetKey("left")){
        myRigidBody.velocity=new Vector3(pStats.currentShipSpeed*-1, myRigidBody.velocity.y, 0);

      }
      if(Input.GetKey("right")){
        myRigidBody.velocity=new Vector3(pStats.currentShipSpeed, myRigidBody.velocity.y, 0);

      }
      if(Input.GetKey("up")){
        myRigidBody.velocity=new Vector3(myRigidBody.velocity.x, pStats.currentShipSpeed, 0);

      }
      if(Input.GetKey("down")){
        myRigidBody.velocity=new Vector3(myRigidBody.velocity.x, -1*pStats.currentShipSpeed, 0);

      }
      if(!Input.GetKey("up") && !Input.GetKey("down") && !Input.GetKey("left") && !Input.GetKey("right")){
        myRigidBody.velocity=Vector3.zero;
      }
      if(!Input.GetKey("left") && !Input.GetKey("right")){
        myRigidBody.velocity=new Vector3(0, myRigidBody.velocity.y, 0);

      }
      if(!Input.GetKey("up") && !Input.GetKey("down")){
        myRigidBody.velocity=new Vector3(myRigidBody.velocity.x, 0, 0);

      }

      if(Input.GetKeyDown("space")){
        Instantiate(attack, new Vector3(transform.position.x,transform.position.y,transform.position.z), Quaternion.identity);
      }

    }

    public Vector3 getStartCoords(){
      return startCoords;
    }
    public void resetLocation(){
      gameObject.transform.position = startCoords;
    }




}
