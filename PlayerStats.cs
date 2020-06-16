using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    // Start is called before the first frame update
    public int currentLevel;
    public int currentExp;

    public int[] toLevelUp;
    public int[] HPLevels;
    public int[] attackLevels;
    public int[] defenceLevels;
    public int[] shipSpeedLevels;


    public int currentMaxHP;
    public int currentAttack;
    public int currentDefence;
    public int currentShipSpeed;

    private PlayerHealthManager thePlayerHealth;

    public string lastScene;
    public bool openingDone;

    void Start()
    {
      currentMaxHP= HPLevels[0];
      currentAttack = attackLevels[0];
      currentDefence = defenceLevels[0];
      currentShipSpeed=shipSpeedLevels[0];
      lastScene="1_1";
      openingDone=false;
      LoadPlayer();
      thePlayerHealth=FindObjectOfType<PlayerHealthManager>();



    }

    // Update is called once per frame
    void Update()
    {
      if(currentExp >= toLevelUp[currentLevel]){
        LevelUp();

      }
      if(thePlayerHealth.playerMaxHealth!=currentMaxHP){
        thePlayerHealth.playerMaxHealth=currentMaxHP;
        thePlayerHealth.playerCurrentHealth=currentMaxHP;
      }

    }


    public void AddExperience(int experienceToAdd){
      currentExp+=experienceToAdd;
    }

    public void LevelUp(){
      currentLevel++;
      currentExp=0;
      currentMaxHP=HPLevels[currentLevel];
      currentDefence=defenceLevels[currentLevel];
      currentAttack=attackLevels[currentLevel];
      currentShipSpeed=shipSpeedLevels[currentLevel];

    //  if(currentLevel!=1){
    //    thePlayerHealth.playerMaxHealth=currentMaxHP;
  //      thePlayerHealth.playerCurrentHealth += currentHP - HPLevels[currentLevel-1];
  //    }






    }
    public void SavePlayer(){
      Debug.Log("The game is being saved...");
      SaveSystem.SavePlayer(this);
    }
    public void LoadPlayer(){
      PlayerData data = SaveSystem.LoadPlayer();
      if(data!=null){
        currentLevel=data.level;
        currentExp=data.xp;
        currentMaxHP=data.health;
        currentAttack=data.attack;
        currentDefence=data.defense;
        currentShipSpeed=data.shipSpeed;
        lastScene=data.scene;
        openingDone=data.openDone;
        if(thePlayerHealth==null)
          thePlayerHealth=FindObjectOfType<PlayerHealthManager>();
        thePlayerHealth.playerMaxHealth=currentMaxHP;
        thePlayerHealth.playerCurrentHealth=currentMaxHP;

        Vector3 position;

        position.x=data.position[0];
        position.y=data.position[1];
        position.z=data.position[2];
        FindObjectOfType<PlayerController>().gameObject.transform.position=position;
        Debug.Log("YEET: "+data.usedWalkableDialogs_Save.Length);
        FindObjectOfType<PlayerController>().usedWalkableDialogs=new string[0];

        for(int i = 0; i<data.usedWalkableDialogs_Save.Length; i++){
          FindObjectOfType<PlayerController>().addUsedWalkable(data.usedWalkableDialogs_Save[i]);
        }
        Debug.Log("YEET2: "+data.usedWalkableDialogs_Save.Length);
        FindObjectOfType<PlayerController>().foundItems=new string[0];

        for(int i = 0; i<data.foundItems_Save.Length; i++){
          FindObjectOfType<PlayerController>().addFoundItem(data.foundItems_Save[i]);
        }
        FindObjectOfType<PlayerController>().tutorialDone=data.tutorialDone_Save;



        FindObjectOfType<InventoryManager>().Reconstruction(data.names_Save,data.descriptions_Save,data.healFactors_Save,data.attackFactors_Save,data.defenseFactors_Save,data.specialFactors_Save,data.extras_Save,data.isWeapons_Save,data.isArmors_Save,data.activations_Save);




      }

      if(!openingDone){
        Debug.Log("This is where opening is happening");
        Application.LoadLevel("OpeningScene");
        openingDone=true;
      }



    }
    public int getAttackPower(){
      if(FindObjectOfType<PlayerController>().weapon!=null)
        return currentAttack + FindObjectOfType<PlayerController>().weapon.attackFactor;
      else
        return currentAttack;
    }
    public int getDefensePower(){
      if(FindObjectOfType<PlayerController>().armor!=null)
        return currentDefence + FindObjectOfType<PlayerController>().armor.defenseFactor;
      else
        return currentDefence;
    }

    public void resetAllValues(){
      currentLevel=1;
      currentExp=0;

      currentMaxHP= HPLevels[0];
      currentAttack = attackLevels[0];
      currentDefence = defenceLevels[0];
    }
}
