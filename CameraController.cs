using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
	public float moveSpeed;
	public GameObject followTarget;
	private Vector3 targetPos;
	private static bool exists;
	public BoxCollider2D boundBox;
	private Vector3 minBounds;
	private Vector3 maxBounds;

	private Camera theCamera;
	private float halfHeight;
	private float halfWidth;
    void Start()
    {
		if(!exists){
			exists=true;
			//DontDestroyOnLoad(transform.gameObject);
		}else{

			//Destroy(gameObject);
		}
		if(boundBox==null)
			boundBox=FindObjectOfType<BoundsScript>().GetComponent<BoxCollider2D>();

		minBounds= boundBox.bounds.min;
		maxBounds= boundBox.bounds.max;
		theCamera = GetComponent<Camera>();
		halfHeight = theCamera.orthographicSize;
		halfWidth = halfHeight * Screen.width / Screen.height;

	}

    // Update is called once per frame
    void LateUpdate()
    {
			if(followTarget==null && FindObjectOfType<PlayerController>()!=null && FindObjectOfType<WizardController>()==null){
				followTarget=FindObjectOfType<PlayerController>().gameObject;
			}
			if(followTarget==null && FindObjectOfType<WizardController>()!=null){
				followTarget=FindObjectOfType<WizardController>().gameObject;
			}
				if(followTarget!=null){
					targetPos=new Vector3(followTarget.transform.position.x, followTarget.transform.position.y, transform.position.z);
					transform.position= Vector3.Lerp(transform.position, targetPos, moveSpeed*Time.deltaTime);
				}


			if(boundBox==null){
				boundBox=FindObjectOfType<BoundsScript>().GetComponent<BoxCollider2D>();

				minBounds= boundBox.bounds.min;
				maxBounds= boundBox.bounds.max;
			}

			float clampedX = Mathf.Clamp(transform.position.x, minBounds.x+halfWidth, maxBounds.x-halfWidth);
			float clampedY = Mathf.Clamp(transform.position.y, minBounds.y+halfHeight, maxBounds.y-halfHeight);
			transform.position = new Vector3(clampedX, clampedY, transform.position.z);
	}

	public void setBounds(BoxCollider2D newBounds){
		boundBox=newBounds;
		minBounds= boundBox.bounds.min;
		maxBounds= boundBox.bounds.max;
	}

}
