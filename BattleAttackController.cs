using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleAttackController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    private Rigidbody2D myRigidBody;
    void Start()
    {
      myRigidBody=GetComponent<Rigidbody2D>();
      myRigidBody.velocity=new Vector3(speed,0,0);
    }

    // Update is called once per frame
    void Update()
    {

    }


}
