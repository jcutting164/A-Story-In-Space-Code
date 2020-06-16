using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]

public class PlayerData
{
  public int level;
  public int xp;
  public int health;
  public int attack;
  public int defense;
  public int shipSpeed;
  public float[] position;
  public string scene;
  public bool openDone;

  public string[] usedWalkableDialogs_Save;
  public string[] foundItems_Save;

  public bool tutorialDone_Save;

  // start of inv info in order

  public string[] names_Save;
  public string[] descriptions_Save;
  public int[] healFactors_Save;
  public int[] attackFactors_Save;
  public int[] defenseFactors_Save;
  public int[] specialFactors_Save;
  public bool[] extras_Save;
  public bool[] isWeapons_Save;
  public bool[] isArmors_Save;
  public string[] activations_Save;

  // end of inv info in order

  //equppied items for saving


  public ItemController[] inv_save;
  public PlayerData(PlayerStats player){
    level=player.currentLevel;
    xp=player.currentExp;
    health=player.currentMaxHP;
    attack=player.currentAttack;
    defense=player.currentDefence;
    shipSpeed=player.currentShipSpeed;
    if(SceneManager.GetActiveScene().name!="OpeningScene")
      scene=SceneManager.GetActiveScene().name;
    else
      scene="1_1";
    openDone=player.openingDone;

    position=new float[3];
    position[0]=GameObject.FindObjectOfType<PlayerController>().gameObject.transform.position.x;
    position[1]=GameObject.FindObjectOfType<PlayerController>().gameObject.transform.position.y;
    position[2]=GameObject.FindObjectOfType<PlayerController>().gameObject.transform.position.z;

    usedWalkableDialogs_Save=GameObject.FindObjectOfType<PlayerController>().usedWalkableDialogs;
    foundItems_Save=GameObject.FindObjectOfType<PlayerController>().foundItems;
    tutorialDone_Save=GameObject.FindObjectOfType<PlayerController>().tutorialDone;

    names_Save=GameObject.FindObjectOfType<InventoryManager>().getNames();
    descriptions_Save=GameObject.FindObjectOfType<InventoryManager>().getDescriptions();
    healFactors_Save=GameObject.FindObjectOfType<InventoryManager>().getHealFactors();
    attackFactors_Save=GameObject.FindObjectOfType<InventoryManager>().getAttackFactors();
    defenseFactors_Save=GameObject.FindObjectOfType<InventoryManager>().getDefenseFactors();
    specialFactors_Save=GameObject.FindObjectOfType<InventoryManager>().getSpecialFactors();
    extras_Save=GameObject.FindObjectOfType<InventoryManager>().getExtras();
    isWeapons_Save=GameObject.FindObjectOfType<InventoryManager>().getIsWeapons();
    isArmors_Save=GameObject.FindObjectOfType<InventoryManager>().getIsArmors();
    activations_Save=GameObject.FindObjectOfType<InventoryManager>().getActivations();


  }


}
