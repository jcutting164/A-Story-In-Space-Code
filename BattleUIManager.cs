using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BattleUIManager : MonoBehaviour
{
    // Start is called before the first frame update
/*    public Slider healthBar;
    public Text HPText;
    public PlayerHealthManager playerHealth;

    public Slider expBar;
    public Text EXPText;
    public PlayerStats playerStats;

    public Text LVLText;
*/

    public Slider enemyHealthBar;
    public BattleEnemy enemyHealth;
    public ShipPlayerController shipPlayer;
    public BattleController bc;
    private string name;
    private int expToGive;
  //  private bool isReady;


    void Start()
    {
      bc=FindObjectOfType<BattleController>();

      enemyHealth=FindObjectOfType<BattleEnemy>();



    }

    // Update is called once per frame
    void Update()
    {

      

      if(bc.enemyBattleStart!=null){
        name = bc.enemyBattleStart.name;
        bc.enemyBattleStart.gameObject.SetActive(false);
      }

      if(enemyHealth==null){
        enemyHealth=FindObjectOfType<BattleEnemy>();
        expToGive=enemyHealth.expToGive;
      }



      //  healthBar.maxValue = playerHealth.playerMaxHealth;
      //  healthBar.value = playerHealth.playerCurrentHealth;
      //  HPText.text = "HP: "+playerHealth.playerCurrentHealth+" / "+playerHealth.playerMaxHealth;

      //  expBar.maxValue = playerStats.toLevelUp[playerStats.currentLevel];
      //  expBar.value = playerStats.currentExp;
      //  EXPText.text = "EXP: "+playerStats.currentExp+" / "+playerStats.toLevelUp[playerStats.currentLevel];

    //    LVLText.text= "LVL: "+playerStats.currentLevel;

        enemyHealthBar.maxValue=enemyHealth.maxHP;


        enemyHealthBar.value=enemyHealth.HP;

        if(FindObjectOfType<UIManager>()!=null){
          if(FindObjectOfType<UIManager>().invActive){
            enemyHealthBar.gameObject.SetActive(false);

          }else
            enemyHealthBar.gameObject.SetActive(true);
        }else
          enemyHealthBar.gameObject.SetActive(true);

        if(enemyHealthBar.value<=0){
          endBattle(expToGive);
        //  FindObjectOfType<PlayerController>().EnemyDestroyer.SetActive(true);

        }else if(FindObjectOfType<ShipPlayerController>().GetComponent<PlayerHealthManager>().playerCurrentHealth<=0){
          endBattleLoss();
        }



    }

    public void endBattle(int expToAdd){
      int newHealth = FindObjectOfType<UIManager>().GetComponent<UIManager>().playerHealth.playerCurrentHealth;
      shipPlayer.player.SetActive(true);
      Application.LoadLevel(PlayerPrefs.GetString("lastLoadedScene"));
      FindObjectOfType<CameraController>().GetComponent<CameraController>().followTarget=FindObjectOfType<PlayerController>().gameObject;
      Debug.Log(FindObjectOfType<PlayerController>());
      Debug.Log(FindObjectOfType<UIManager>());
      FindObjectOfType<PlayerController>().GetComponent<PlayerHealthManager>().playerCurrentHealth=newHealth;
      FindObjectOfType<PlayerController>().GetComponent<PlayerController>().startPoint="PostBattle";
      FindObjectOfType<PlayerController>().gameObject.transform.position=new Vector3(PlayerPrefs.GetFloat("PlayerX"),PlayerPrefs.GetFloat("PlayerY"),0f);
      FindObjectOfType<PlayerStats>().GetComponent<PlayerStats>().AddExperience(expToAdd);
      FindObjectOfType<MusicController>().stopCurrent();
      FindObjectOfType<MusicController>().currentTrack=-999;
    }

    public void endBattleLoss(){
      Application.LoadLevel("GameOver");
      FindObjectOfType<MusicController>().stopCurrent();
      FindObjectOfType<MusicController>().currentTrack=-999;
      FindObjectOfType<PlayerController>().startPoint="START";


    }

  }
