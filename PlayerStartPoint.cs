using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartPoint : MonoBehaviour
{
	private PlayerController thePlayer;
	private CameraController theCamera;
	public Vector2 startDirection;

	public string pointName;
    // Start is called before the first frame update
    void Start()
    {
		// searches the game world for object with this script (only one)
		thePlayer=FindObjectOfType<PlayerController>();
		if(thePlayer!=null){
			if(thePlayer.startPoint == pointName){
				thePlayer.transform.position=transform.position;
				thePlayer.lastMove= startDirection;
				theCamera=FindObjectOfType<CameraController>();
				theCamera.transform.position=new Vector3(transform.position.x, transform.position.y, theCamera.transform.position.z);
			}
		}else{
			thePlayer=FindObjectOfType<PlayerController>();
			if(thePlayer.startPoint == pointName){
				thePlayer.transform.position=transform.position;
				thePlayer.lastMove= startDirection;
				theCamera=FindObjectOfType<CameraController>();
				theCamera.transform.position=new Vector3(transform.position.x, transform.position.y, theCamera.transform.position.z);
			}
		}



		// moves player to start point

    }

    // Update is called once per frame
    void Update()
    {

    }
}
