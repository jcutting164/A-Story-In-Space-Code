using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddleController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D myRigidBody;
    void Start()
    {
        myRigidBody=GetComponent<Rigidbody2D>();
        myRigidBody.velocity=Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("down")){
          myRigidBody.velocity=new Vector3(0,-6,0);
        }else if(Input.GetKey("up")){
          myRigidBody.velocity=new Vector3(0,6,0);

        }else{
          myRigidBody.velocity=Vector3.zero;

        }
    }
}
