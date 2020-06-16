using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    private Rigidbody2D myRigidBody;
    //public LevelManager theLM;
    //public SFXManager sfx;
    void Start()
    {
      myRigidBody= GetComponent<Rigidbody2D>();
      myRigidBody.velocity=new Vector2(speed,0);
    //  theLM = FindObjectOfType<LevelManager>();
      //sfx=FindObjectOfType<SFXManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other){
      if(other.gameObject.tag=="Enemy"){
        Destroy(other.gameObject);
        Destroy(gameObject);
      //  theLM.currentScore+=50;
      //  sfx.playerAttacks.Play();
      }
    }
}
