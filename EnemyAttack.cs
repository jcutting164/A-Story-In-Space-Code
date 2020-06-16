using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    // Start is called before the first frame update
    public string mID;
    public int life;
    public float velX;
    public float velY;
    private Rigidbody2D myRigidBody;
    public int count;
    public PlayerHealthManager thePHM;

    public float waitTime;
    private float currentTime;
    private bool extra;
    public int attackPower;


    // used to make more of itself with new values (for ex: velocity)
    public EnemyAttack extraSpawn;


    public float speed=0.8f;

    void Start()
    {
        myRigidBody=GetComponent<Rigidbody2D>();

        if(mID=="Basic" || mID=="BirdA1"){
          myRigidBody.velocity=new Vector3(velX, velY, 0);
          count=4;
        }else if(mID=="BirdA2"){
          myRigidBody.velocity=new Vector3(velX, velY, 0);
          count=5;
        }else if(mID=="TreeA1"){
          myRigidBody.velocity=new Vector3(velX, velY, 0);
          count=3;
        }else if(mID=="TreeA2"){
          myRigidBody.velocity=new Vector3(velX, velY, 0);
          count=8;
        }else if(mID=="EyeA1"){
          myRigidBody.velocity=new Vector3(velX, velY, 0);
          count=2;
        }else if(mID=="EyeA2"){
          myRigidBody.velocity=new Vector3(velX, velY, 0);
          count=2;
        }else if(mID=="SkertA1"){
          myRigidBody.velocity=new Vector3(velX, velY, 0);
          count=2;
        }else if(mID=="SkertA2"){
          myRigidBody.velocity=new Vector3(velX, velY, 0);
          count=2;
        }else if(mID=="TheCommanderA1"){
          myRigidBody.velocity=new Vector3(velX, velY, 0);
          count=2;
        }else{
          myRigidBody.velocity=new Vector3(velX, velY, 0);

        }


        //thePHM=FindObjectOfType<PlayerHealthManager>();

    }

    // Update is called once per frame
    void Update()
    {
      if(mID=="BirdA2"){
        myRigidBody.velocity=new Vector3((float)(myRigidBody.velocity.x-.08), velY, 0);
      }else if(mID=="TreeA1"){

        if(transform.position.y >= 0){
          myRigidBody.velocity=new Vector3(velX,(float)(myRigidBody.velocity.y-0.09), 0);

        }else if(transform.position.y <=-1.5){
          myRigidBody.velocity=new Vector3(velX,(float)(myRigidBody.velocity.y+0.09), 0);
        }

      }else if(mID=="TreeA2"){
        if(transform.position.y >= 0){
          myRigidBody.velocity=new Vector3(velX,(float)(myRigidBody.velocity.y-0.2), 0);

        }else if(transform.position.y <=-1.5){
          myRigidBody.velocity=new Vector3(velX,(float)(myRigidBody.velocity.y+0.2), 0);
        }
      }else if(mID=="EyeA1"){
        currentTime+=Time.deltaTime;
        if(currentTime>=waitTime && !extra){
          Instantiate(this, new Vector3((float)transform.position.x,(float)(transform.position.y+.3),transform.position.z), Quaternion.identity);
          Instantiate(this, new Vector3((float)transform.position.x,(float)(transform.position.y+.6),transform.position.z), Quaternion.identity);
          Instantiate(this, new Vector3((float)transform.position.x,(float)(transform.position.y-.3),transform.position.z), Quaternion.identity);
          Instantiate(this, new Vector3((float)transform.position.x,(float)(transform.position.y-.6),transform.position.z), Quaternion.identity);
          currentTime=0;
          extra=true;
        }
      }else if(mID=="EyeA2"){
        currentTime+=Time.deltaTime;
        if(currentTime>=waitTime && !extra){
          extraSpawn.velX=-8;
          Instantiate(extraSpawn, new Vector3((float)(transform.position.x-.5),transform.position.y,transform.position.z), Quaternion.identity);
          currentTime=0;
          extra=true;
        }
      }else if(mID=="SkertA1"){
        transform.localScale += new Vector3(0.0002f, 0.0002f, 0.0002f);
      }else if(mID=="SkertA2"){
        currentTime+=Time.deltaTime;
        if(currentTime>=waitTime){
          extra=!extra;
          currentTime=0;
          myRigidBody.velocity=new Vector3(myRigidBody.velocity.x*2, velY, 0);

        }

        if(!extra){
          transform.localScale += new Vector3(0.0005f, 0.0005f, 0.0005f);

        }else{
          transform.localScale += new Vector3(-0.0005f, -0.0005f, -0.0005f);

        }

      }else if(mID=="TheCommanderA1" || mID=="TheCommanderA5"){
        myRigidBody.velocity=new Vector3((float)(myRigidBody.velocity.x*1.02), velY, 0);
      }else if(mID=="TheCommanderA2" || mID=="TheCommanderA6"){
        currentTime+=Time.deltaTime;
        if(currentTime>=waitTime){
          extra=!extra;
          currentTime=0;
          myRigidBody.velocity=new Vector3((float)(myRigidBody.velocity.x*2), velY, 0);

        }

        if(!extra){
          transform.localScale += new Vector3(0.001f, 0.001f, 0.0005f);

        }else{
          transform.localScale += new Vector3(-0.001f, -0.001f, -0.0005f);

        }
      }else if(mID=="TheCommanderA3" || mID=="TheCommanderA7"){
        if(transform.position.y >= 0){
          myRigidBody.velocity=new Vector3(myRigidBody.velocity.x,(float)(myRigidBody.velocity.y-0.8), 0);

        }else if(transform.position.y <=-1.5){
          myRigidBody.velocity=new Vector3(myRigidBody.velocity.x,(float)(myRigidBody.velocity.y+0.8), 0);

        }

        myRigidBody.velocity=new Vector3((float)(myRigidBody.velocity.x*1.03), myRigidBody.velocity.y, 0);

      }else if(mID=="TheCommanderA4" || mID=="TheCommanderA8"){
        currentTime+=Time.deltaTime;
        if(currentTime>=waitTime && !extra){
          Instantiate(this, new Vector3((float)transform.position.x+1,(float)(transform.position.y+1),transform.position.z), Quaternion.identity);
          Instantiate(this, new Vector3((float)transform.position.x+1,(float)(transform.position.y-1),transform.position.z), Quaternion.identity);
          Instantiate(this, new Vector3((float)transform.position.x-1,(float)(transform.position.y+1),transform.position.z), Quaternion.identity);
          Instantiate(this, new Vector3((float)transform.position.x-1,(float)(transform.position.y-1),transform.position.z), Quaternion.identity);
          currentTime=0;
          extra=true;
        }
      }else if(mID=="HandsA1"){
        currentTime+=Time.deltaTime;
        if(currentTime>=waitTime){
          Instantiate(extraSpawn, new Vector3((float)transform.position.x,(float)(transform.position.y),transform.position.z), Quaternion.identity);
          currentTime=0;
        }
      }else if(mID=="HandsA2_extra"){

        currentTime+=Time.deltaTime;
        if(currentTime>=waitTime){
          velY=-5;
          myRigidBody.velocity=new Vector3(velX, velY, 0);

        }
      }
    }

    void OnTriggerEnter2D(Collider2D other){
      if(other.gameObject.tag=="ShipPlayer"){
        Destroy(gameObject);
        Debug.Log("Is cm on?: "+FindObjectOfType<ChoiceManager>());
        Debug.Log("the phm: "+FindObjectOfType<ChoiceManager>().GetComponent<PlayerHealthManager>());
        // damage calculation:

        int damage = attackPower - FindObjectOfType<UIManager>().GetComponent<PlayerStats>().getDefensePower();
        if(damage<0){
          System.Random rnd = new System.Random();

          damage=rnd.Next(1,6);
        }

        FindObjectOfType<ShipPlayerController>().GetComponent<PlayerHealthManager>().HurtPlayer(damage);
        //Resources.FindObjectOfTypeAll<PlayerHealthManager>().HurtPlayer(5);

      //  if(thePHM==null)
      //    thePHM=FindObjectOfType<PlayerHealthManager>();
      //  thePHM.HurtPlayer(5);
      }else if(other.tag=="PlayerAttack"){
        Debug.Log("HITHITHITHITHITHTLTHIT");
        transform.localScale += new Vector3((float)(-.005), (float)(-.005), -0.01f);
        Destroy(other.gameObject);

      }

    }
}
