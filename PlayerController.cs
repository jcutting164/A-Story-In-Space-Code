using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{


  public float moveSpeed=5;
  private float currentMoveSpeed;
  public float diagonalMoveModifier;
  private Animator anim;
	private Rigidbody2D myRigidBody;

	private bool isMoving;
	public Vector2 lastMove;

	private static bool playerExists;

  private bool attacking;
  public float attackTime;
  private float attackTimeCounter;

  public string startPoint;

  public bool canMove;

  private SFXManager sfxMan;

  private Vector2 moveInput;

  public GameObject EnemyDestroyer;

  public ItemController weapon;
  public ItemController armor;

// NEEDS TO BE ADDED TO SAVE
  public string[] usedWalkableDialogs;
  public string[] foundItems;

  public bool tutorialDone;
    // Start is called before the first frame update
    void Start()
    {
        usedWalkableDialogs=new string[0];
        foundItems=new string[0];
        anim=GetComponent<Animator>();
		    myRigidBody=GetComponent<Rigidbody2D>();
        sfxMan = FindObjectOfType<SFXManager>();

		// keeps instance for changing rooms
    		if(!playerExists){
    			playerExists=true;
    			DontDestroyOnLoad(transform.gameObject);
    		}else{
    			Destroy(gameObject);
    		}
        //lastMove=new Vector2(0,-1f);
        FindObjectOfType<PlayerStats>().LoadPlayer();

    }


    // Update is called once per frame
    void Update()
    {


      if(weapon!=null){
        Debug.Log(weapon.attackFactor);
      }
      if((FindObjectOfType<BattleUIManager>()!=null || FindObjectOfType<UIManager>().invActive) || (SceneManager.GetActiveScene().name=="TitleScreen" || SceneManager.GetActiveScene().name=="OpeningScene")){
        canMove=false;
        GetComponent<SpriteRenderer>().enabled=false;
      }else if(!FindObjectOfType<DialogueManager>().dialogActive){
        canMove=true;
        GetComponent<SpriteRenderer>().enabled=true;

      }
      if(FindObjectOfType<DialogueManager>().dialogActive){
        canMove=false;

      }
		isMoving=false;

    if(!canMove){
      myRigidBody.velocity=Vector2.zero;
      anim.SetBool("playerMoving", false);
      return;
    }

    if(!attacking){

/*


      if(Input.GetAxisRaw("Horizontal") > 0.5f  || Input.GetAxisRaw("Horizontal") < -0.5f){
             // transform.Translate(Input.GetAxisRaw("Horizontal")*moveSpeed*Time.deltaTime,0f,0f);

  			myRigidBody.velocity= new Vector2(Input.GetAxisRaw("Horizontal")*currentMoveSpeed, myRigidBody.velocity.y);
  			isMoving=true;
  			lastMove=new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
          }
  		if(Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f){
             // transform.Translate(0f,Input.GetAxisRaw("Vertical")*moveSpeed*Time.deltaTime*1,0f);

  			myRigidBody.velocity= new Vector2(myRigidBody.velocity.x, Input.GetAxisRaw("Vertical")*currentMoveSpeed);

  			isMoving=true;
  			lastMove=new Vector2(0f, Input.GetAxisRaw("Vertical"));
          }

  		// stops the player from moving
  		if(Input.GetAxisRaw("Horizontal") <0.5f && Input.GetAxisRaw("Horizontal") > -.05f){
  			myRigidBody.velocity=new Vector2(0f, myRigidBody.velocity.y);

  		}

  		if(Input.GetAxisRaw("Vertical") <0.5f && Input.GetAxisRaw("Vertical") > -.05f){
  			myRigidBody.velocity=new Vector2(myRigidBody.velocity.x, Input.GetAxisRaw("Vertical"));

  		}*/



      moveInput=new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
      if(moveInput != Vector2.zero){
        myRigidBody.velocity=new Vector2(moveInput.x*moveSpeed, moveInput.y*moveSpeed);
        isMoving=true;
        lastMove=moveInput;
      }else{
        myRigidBody.velocity=Vector2.zero;
        isMoving=false;
      }

      // init of attacking with J
    /*  if(Input.GetKeyDown(KeyCode.J)){
        attackTimeCounter = attackTime;
        attacking=true;
        myRigidBody.velocity=Vector2.zero;
        // accesses the animators parameter
        anim.SetBool("Attack", true);
        sfxMan.playerAttacks.Play();
      }*/

      // fix faster diagonal moveSpeed
/*
      if(Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.5f && Mathf.Abs(Input.GetAxisRaw("Vertical"))>0.5f) {
        currentMoveSpeed= moveSpeed*diagonalMoveModifier;
      }else{
        currentMoveSpeed=moveSpeed;
      }


*/
  }


  if(attackTimeCounter > 0){
    attackTimeCounter-= Time.deltaTime;
  }
  if(attackTimeCounter<=0){
    attacking=false;
    anim.SetBool("Attack",false);
  }

    anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
		anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
		anim.SetBool("playerMoving", isMoving);
		anim.SetFloat("LastMoveX", lastMove.x);
		anim.SetFloat("LastMoveY", lastMove.y);


    }

    public void addUsedWalkable(string used){
      string[] temp = usedWalkableDialogs;
      usedWalkableDialogs=new string[usedWalkableDialogs.Length+1];
      for(int i = 0; i<usedWalkableDialogs.Length-1; i++)
        usedWalkableDialogs[i]=temp[i];
      usedWalkableDialogs[temp.Length]=used;
    }
    public void addFoundItem(string used){
      string[] temp = foundItems;
      foundItems=new string[foundItems.Length+1];
      for(int i = 0; i<foundItems.Length-1; i++)
        foundItems[i]=temp[i];
      foundItems[temp.Length]=used;
    }

    public bool hasBeenWalked(string toBeChecked){
      bool answer=false;
      for(int i = 0; i<usedWalkableDialogs.Length; i++){
        if(usedWalkableDialogs[i]==toBeChecked){
          answer=true;
          break;
        }
      }
      return answer;
    }

    public void setWeapon(ItemController newWeapon){
      if(weapon==null){
        weapon=newWeapon;
      }else{
        FindObjectOfType<InventoryManager>().addItem(weapon);
        weapon=newWeapon;
      }
    }
    public void setArmor(ItemController newArmor){
      if(armor==null){
        armor=newArmor;
      }else{
        FindObjectOfType<InventoryManager>().addItem(armor);
        armor=newArmor;
      }
    }

    public bool checkWeapon(string toBeChecked){
      if(weapon==null)
        return false;
      else
        return toBeChecked==weapon.name;
    }
    public bool checkArmor(string toBeChecked){
      if(armor==null)
        return false;
      else
        return toBeChecked==armor.name;
    }

    public bool hasBeenFound(string activation){
      bool answer=false;
      for(int i =0; i<foundItems.Length; i++){
        if(foundItems[i]==activation){
          answer=true;
          break;
        }
      }
      return answer;
    }





}
