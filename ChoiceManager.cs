using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceManager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject FightS;
    public GameObject SpecialS;
    public GameObject ItemsS;
    public GameObject RunS;

    public GameObject Fight;
    public GameObject Special;
    public GameObject Items;
    public GameObject Run;

    public GameObject paddlePlayer;
    public ShotShooter shotShooter;
    public GameObject target;
    public GameObject shipPlayer;
    public StarGenerator EnemyAttackGenerator;

    public GameObject enemyHealthBar;
    private float offenseTime;
    private float defenseTime;



    public int currentChoice;
    public string currentState;

  //  public PlayerHealthManager thePHM;
    // states available: START, OFFENSE, DEFENSE, END

    void Start()
    {
      currentState="START";
      currentChoice=0;


    }

    // Update is called once per frame
    void Update()
    {
      if(!FindObjectOfType<DialogueManager>().dialogActive){
        if(currentState=="START"){
          if(Input.GetKeyDown("up")){
            currentChoice--;
          }
          if(Input.GetKeyDown("down")){
            currentChoice++;
          }
          if(currentChoice<0)
            currentChoice=0;
          if(currentChoice>3)
            currentChoice=3;

          FightS.SetActive(true);
          SpecialS.SetActive(true);
          ItemsS.SetActive(true);
          RunS.SetActive(true);

          if(currentChoice==0){
            FightS.SetActive(false);
          }else if(currentChoice==1){
            SpecialS.SetActive(false);
          }else if(currentChoice==2){
            ItemsS.SetActive(false);
          }else if(currentChoice==3){
            RunS.SetActive(false);
          }
          // FIGHT
          if(Input.GetKeyDown(KeyCode.Return) && currentChoice==0){
            currentState="OFFENSE";
            Fight.SetActive(false);
            Special.SetActive(false);
            Items.SetActive(false);
            Run.SetActive(false);
            offenseTime=0;
          }

          // undecided SPECIAL OPTION
          if(Input.GetKeyDown(KeyCode.Return) && currentChoice==1){

          }

          // ITEMS
          if(Input.GetKeyDown(KeyCode.Return) && currentChoice==2){
            FindObjectOfType<UIManager>().GetComponent<UIManager>().turnOnInv();
            Fight.SetActive(false);
            Special.SetActive(false);
            Items.SetActive(false);
            Run.SetActive(false);
            currentState="ItemsPick";
          }

          // Run
          // eventually add exception for boss battles
          if(Input.GetKeyDown(KeyCode.Return) && currentChoice==3){

            int currentEnemyHealth = (int)(FindObjectOfType<BattleUIManager>().enemyHealthBar.value);
            int currentEnemyMax = (int)(FindObjectOfType<BattleUIManager>().enemyHealthBar.maxValue);

            System.Random rnd = new System.Random();

            if(currentEnemyHealth==currentEnemyMax){
              // certain chance
              if((int)(rnd.Next(52))==0)
                FindObjectOfType<BattleUIManager>().endBattle(0);
              else{
                toDEFENSE();
              }

            }else if(currentEnemyMax/2 >= currentEnemyHealth){
              // certain chance
              if((int)(rnd.Next(4))==0)
                FindObjectOfType<BattleUIManager>().endBattle(0);
              else{
                toDEFENSE();
              }
            }else if(currentEnemyMax/4 >= currentEnemyHealth){
              if((int)(rnd.Next(2))==0)
                FindObjectOfType<BattleUIManager>().endBattle(0);
              else{
                toDEFENSE();
              }
            }


            //FindObjectOfType<BattleUIManager>().endBattle(0);
          }



        }else if(currentState=="OFFENSE"){

          offenseTime+=Time.deltaTime;

          // counter idea? time = shotCount*3 seconds? what about shot velocity???

          // set active the paddlePlayer
          // set active shotShooter
          // handle collisions in their own respective controllers
          enemyHealthBar.SetActive(true);
          paddlePlayer.SetActive(true);
          shotShooter.gameObject.SetActive(true);
          target.SetActive(true);
          EnemyAttackGenerator.isOn=false;



          if(FindObjectOfType<ShotController>()==null && offenseTime>=5f){
            // end offense and now to defense bc there are no more balls that exist
            // allows for 5 seconds to make sure that balls have been shot in offense
            toDEFENSE();

          }


        }else if(currentState=="DEFENSE"){
          defenseTime+=Time.deltaTime;

          EnemyAttackGenerator.isOn=true;
          if(FindObjectOfType<EnemyAttack>()==null && defenseTime>=5f){
            toSTART();




          }



        }else if(currentState=="ItemsPick"){
          if(Input.GetKeyDown(KeyCode.Z)){
            currentState="START";
            FindObjectOfType<UIManager>().GetComponent<UIManager>().turnOffInv();
            Fight.SetActive(true);
            Special.SetActive(true);
            Items.SetActive(true);
            Run.SetActive(true);
          }else if(Input.GetKeyDown(KeyCode.X)){
            // item uage is taken care of in UIManager!

            toDEFENSE();
          }
        }

      }








    }

    public void toOFFENSE(){

    }
    public void toDEFENSE(){
      EnemyAttackGenerator.changeOption();
      currentState="DEFENSE";
      FindObjectOfType<UIManager>().GetComponent<UIManager>().turnOffInv();
      enemyHealthBar.SetActive(false);
      shotShooter.gameObject.SetActive(false);
      target.SetActive(false);
      shotShooter.currentCount=0;
      defenseTime=0;
      paddlePlayer.SetActive(false);
      Debug.Log("here amigo");
      shipPlayer.GetComponent<SpriteRenderer>().enabled=true;
      shipPlayer.GetComponent<BoxCollider2D>().enabled=true;
      shipPlayer.GetComponent<ShipPlayerController>().enabled=true;
      shipPlayer.GetComponent<ShipPlayerController>().resetLocation();

    //  shipPlayer.SetActive(true);
      Debug.Log("here amigo");
      Fight.SetActive(false);
      Special.SetActive(false);
      Items.SetActive(false);
      Run.SetActive(false);
    }
    public void toSTART(){
      currentState="START";
      Fight.SetActive(true);
      Special.SetActive(true);
      Items.SetActive(true);
      Run.SetActive(true);

      enemyHealthBar.SetActive(false);
      paddlePlayer.SetActive(false);
      shotShooter.gameObject.SetActive(false);
      target.SetActive(false);
      EnemyAttackGenerator.objectCounter=0;

      EnemyAttackGenerator.isOn=false;
    //  shipPlayer.SetActive(false);
      shipPlayer.GetComponent<SpriteRenderer>().enabled=false;
      shipPlayer.GetComponent<BoxCollider2D>().enabled=false;
      shipPlayer.GetComponent<ShipPlayerController>().enabled=false;


      currentChoice=0;
    }


}
