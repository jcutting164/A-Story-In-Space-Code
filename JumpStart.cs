using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpStart : MonoBehaviour
{
    // Start is called before the first frame update
    public int difficulty;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay2D(Collider2D other){
      if(other.name=="Player" && Input.GetKeyDown(KeyCode.Space)){
        // opens wizard jump
        if(difficulty==0){
          FindObjectOfType<PlayerController>().startPoint="2";
        //  FindObjectOfType<allMainObjects>().gameObject.SetActive(false);
          Application.LoadLevel("BLUE_1");

        }
      }
    }
}
