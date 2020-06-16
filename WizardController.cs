using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardController : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed;
    public float jumpSpeed;
    private float currentMoveSpeed;
    private Animator anim;
  	private Rigidbody2D myRigidBody;

  	private bool isMoving;
    private float lastMove;




    void Start()
    {
      anim=GetComponent<Animator>();
      myRigidBody=GetComponent<Rigidbody2D>();
      myRigidBody.velocity=Vector3.zero;
      lastMove=1;
      isMoving=false;
    }

    // Update is called once per frame
    void Update()
    {
      if(Input.GetKey("left")){
        myRigidBody.velocity=new Vector3(moveSpeed*-1,myRigidBody.velocity.y,0);
        isMoving=true;
        lastMove=-1f;
      }else if(Input.GetKey("right")){
        myRigidBody.velocity=new Vector3(moveSpeed,myRigidBody.velocity.y,0);
        isMoving=true;
        lastMove=1f;


      }else{
        myRigidBody.velocity=new Vector3(0,myRigidBody.velocity.y,0);
      }
      if(Input.GetKeyDown("up") && myRigidBody.velocity.y==0){
        myRigidBody.velocity=new Vector3(myRigidBody.velocity.x,jumpSpeed,0);

      }
      if(myRigidBody.velocity.x==0)
        isMoving=false;

      anim.SetFloat("moveX", myRigidBody.velocity.x);
      anim.SetBool("isMoving",isMoving);
      anim.SetFloat("lastMove",lastMove);

    }
}
