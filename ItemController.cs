using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemController : MonoBehaviour
{
    // Start is called before the first frame update

    public string name;
    public string description;
    public int healFactor;
    public int attackFactor;
    public int defenseFactor;
    public int specialFactor;
    public bool extra;
    public bool isWeapon;
    public bool isArmor;
    public string activation;

    private float counter;
    public float cooldown;
    // also have sprite and box collider to be turned off by collection

    void Start()
    {
      counter=0;
    }

    // Update is called once per frame
    void Update()
    {
      if(GetComponent<SpriteRenderer>()!=null){
        if(GetComponent<SpriteRenderer>().enabled){
          if(FindObjectOfType<PlayerController>()!=null)
          if(FindObjectOfType<PlayerController>().hasBeenFound(activation) && activation!="NULL"){
            GetComponent<SpriteRenderer>().enabled=false;
            GetComponent<BoxCollider2D>().enabled=false;
          }
        }

        }

      

    }

    void OnTriggerEnter2D(Collider2D other){
      if(other.tag=="Player" || other.name=="Wizard"){
        FindObjectOfType<InventoryManager>().addItem(this);
        GetComponent<BoxCollider2D>().enabled=false;
        GetComponent<SpriteRenderer>().enabled=false;
        FindObjectOfType<PlayerController>().addFoundItem(activation);
        gameObject.transform.parent=FindObjectOfType<InventoryManager>().gameObject.transform;
        DontDestroyOnLoad(gameObject);

        if(name=="Carrot")
          counter=0;
      }
    }

    public void use(PlayerHealthManager playerHealth, PlayerStats player){
        // basic universal usage (if none then all are 0 and extra is PROBABLY true)
        if(playerHealth==null)
          playerHealth=FindObjectOfType<PlayerHealthManager>();
        playerHealth.playerCurrentHealth+=healFactor;
        player.currentAttack+=attackFactor;
        player.currentDefence+=defenseFactor;

        if(extra){

        }
        if(isWeapon){
          FindObjectOfType<PlayerController>().GetComponent<PlayerController>().setWeapon(this);
        }
        if(isArmor){
          FindObjectOfType<PlayerController>().GetComponent<PlayerController>().setArmor(this);


        }

    }


    public ItemController(string givenName,string givenDescription, int givenHealFactor, int givenAttackFactor, int givenDefenseFactor, int givenSpecialFactor, bool givenExtra, bool givenIsWeapon, bool givenIsArmor, string givenActivation){
      name=givenName;
      description=givenDescription;
      healFactor=givenHealFactor;
      attackFactor=givenAttackFactor;
      defenseFactor=givenDefenseFactor;
      specialFactor=givenSpecialFactor;
      extra=givenExtra;
      isWeapon=givenIsWeapon;
      isArmor=givenIsArmor;
      activation=givenActivation;

    }
}
