using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StarController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D myRigidBody;
    public int directionSpeed;
    private ChoiceManager cm;
    void Start()
    {
      myRigidBody = GetComponent<Rigidbody2D>();
      myRigidBody.velocity=new Vector2(directionSpeed, 0);
      cm=FindObjectOfType<ChoiceManager>();
    }

    // Update is called once per frame
    void Update()
    {
    //  myRigidBody.velocity=new Vector2(directionSpeed, 0);
      if(SceneManager.GetActiveScene().name=="ChoiceScreen"){
        if(cm.currentState!="START"){
          Destroy(gameObject);
        }
      }


    }
}
