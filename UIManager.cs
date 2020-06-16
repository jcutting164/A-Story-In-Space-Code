using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider healthBar;
    public Text HPText;


    public PlayerHealthManager playerHealth;

    public Slider expBar;
    public Text EXPText;
    public PlayerStats playerStats;

    public Text LVLText;
    public Slider healthBarUI;
    public Text HPTextUI;



    public Slider expBarUI;
    public Text EXPTextUI;
    public Text LVLTextUI;


    public InventoryManager theInventory;
    public GameObject inv;
    public bool invActive;
    public GameObject equipped;
    public GameObject desc;
    public Text descriptionText;
    public Text equippedWeapon;
    public Text equippedArmor;
    public int pageCount;
    public int maxPageCount;
    public GameObject[] options;
    public Text pages;
    public Text[] currentOptions;

    public GameObject HealthEXP;

    public bool start=true;
    //public bool[] selections;

    public int invSelection;


    private static bool UIExists;




    void Start()
    {
      if(!UIExists){
  			UIExists=true;
  			DontDestroyOnLoad(transform.gameObject);
  		}else{
  			Destroy(gameObject);
  		}

    }

    // Update is called once per frame
    void Update()
    {

      if(FindObjectOfType<WizardController>()!=null){
        healthBar.gameObject.SetActive(false);
        expBar.gameObject.SetActive(false);
        HPText.enabled=false;
        EXPText.enabled=false;
        LVLText.enabled=false;
        expBarUI.gameObject.SetActive(false);
        healthBarUI.gameObject.SetActive(false);
        invActive=false;
        FindObjectOfType<PlayerController>().GetComponent<SpriteRenderer>().enabled=false;
        FindObjectOfType<PlayerController>().canMove=false;

      }else{
        FindObjectOfType<PlayerController>().GetComponent<SpriteRenderer>().enabled=true;
        FindObjectOfType<PlayerController>().canMove=true;
      }

      if(SceneManager.GetActiveScene().name=="OpeningScene" || SceneManager.GetActiveScene().name=="TitleScreen" || SceneManager.GetActiveScene().name=="GameOver" && FindObjectOfType<WizardController>()==null){
        healthBar.gameObject.SetActive(false);
        expBar.gameObject.SetActive(false);
        HPText.enabled=false;
        EXPText.enabled=false;
        LVLText.enabled=false;
        expBarUI.gameObject.SetActive(false);
        healthBarUI.gameObject.SetActive(false);
        invActive=false;
      }else{
        healthBar.gameObject.SetActive(true);
        expBar.gameObject.SetActive(true);
        HPText.enabled=true;
        EXPText.enabled=true;
        LVLText.enabled=true;
        expBarUI.gameObject.SetActive(true);
        healthBarUI.gameObject.SetActive(true);

      }

        if(Input.GetKeyDown("i") && (SceneManager.GetActiveScene().name!="ChoiceScreen" && SceneManager.GetActiveScene().name!="OpeningScene" && SceneManager.GetActiveScene().name!="TitleScreen" && SceneManager.GetActiveScene().name!="GameOver") && !FindObjectOfType<DialogueManager>().dialogActive && FindObjectOfType<WizardController>()==null){
          turnOnInv();
        }
        inv.SetActive(invActive);
        equipped.SetActive(invActive);
        desc.SetActive(invActive);
        HealthEXP.SetActive(invActive);

        if(inv.activeSelf){
          if(theInventory.inv.Length!=0){

            if(pageCount*4+invSelection >= theInventory.inv.Length){

              invSelection--;
              if(invSelection==-1){
                invSelection=3;
                pageCount--;
              }
            }

            if(invSelection<0)
              invSelection=0;
            if(invSelection>3)
              invSelection=3;

            // start of display
            for(int i = 0; i<4; i++){
              options[i].SetActive(false);
            }
            options[invSelection].SetActive(true);

            if(Input.GetKeyDown("up")){
              invSelection--;

            }else if(Input.GetKeyDown("down")){
              if(invSelection+1==4){
                  invSelection++;
              }else{
                if(currentOptions[invSelection+1].text!=" ")
                  invSelection++;
              }
            }
            if(invSelection>3 && pageCount+1==maxPageCount)
              invSelection=3;
            if(invSelection<0 && pageCount==0)
                invSelection=0;

            if(invSelection>3){
              invSelection=0;
              pageCount++;
            }
            if(invSelection<0){
              invSelection=3;
              pageCount--;
            }

            if(theInventory.inv.Length==invSelection*(pageCount+1))
              invSelection--;

            pages.text = pageCount+1+"/"+maxPageCount;
            for(int i = 0; i<4; i++){
              if(!((pageCount*4)+i >=theInventory.inv.Length))
                currentOptions[i].text=theInventory.inv[(pageCount*4)+i].name;
              else
                currentOptions[i].text=" ";
            }


            // end of display
            // start of usage
            if(Input.GetKeyDown(KeyCode.X) && theInventory.inv.Length!=0){
              // make a remove item function that takes int as parameter
              if(theInventory.inv[pageCount*4+invSelection].name!="The Blue Orb"){
                if(FindObjectOfType<BattleUIManager>()==null){
                  theInventory.inv[pageCount*4+invSelection].use(playerHealth, playerStats);
                }else{
                  theInventory.inv[pageCount*4+invSelection].use(FindObjectOfType<ShipPlayerController>().GetComponent<PlayerHealthManager>(), playerStats);
                }
                theInventory.removeItem(pageCount*4+invSelection);
                // updates page count after usage
                maxPageCount=theInventory.inv.Length / 4;
                if(theInventory.inv.Length%4!=0)
                  maxPageCount++;
              }



            }

            if(Input.GetKeyDown(KeyCode.T) && theInventory.inv.Length!=0){
              // make a remove item function that takes int as parameter
              //theInventory.inv[pageCount*4+invSelection].use(playerHealth, playerStats);
              theInventory.removeItem(pageCount*4+invSelection);
              // updates page count after usage
              maxPageCount=theInventory.inv.Length / 4;
              if(theInventory.inv.Length%4!=0)
                maxPageCount++;


            }

          }else{
            maxPageCount=0;
            pageCount=0;
            pages.text = pageCount+"/"+maxPageCount;
            for(int i = 0; i<4; i++){
              if(!((pageCount*4)+i >=theInventory.inv.Length))
                currentOptions[i].text=theInventory.inv[(pageCount*4)+i].name;
              else
                currentOptions[i].text=" ";
            }
          }
        //  if(FindObjectOfType<BattleUIManager>()==null){
            if(FindObjectOfType<PlayerController>().GetComponent<PlayerController>().weapon!=null)
              equippedWeapon.text="Weapon: "+FindObjectOfType<PlayerController>().GetComponent<PlayerController>().weapon.name;
            else
              equippedWeapon.text="Weapon: (not equipped)";
            if(FindObjectOfType<PlayerController>().GetComponent<PlayerController>().armor!=null)
              equippedArmor.text="Armor: "+FindObjectOfType<PlayerController>().GetComponent<PlayerController>().armor.name;
            else
              equippedArmor.text="Armor: (not equipped)";
      //    }
          if(theInventory.inv.Length!=0 && pageCount*4+invSelection<theInventory.inv.Length)
            descriptionText.text=theInventory.inv[(pageCount*4+invSelection)].description;
          else
            descriptionText.text="No item selected";


        }


        if(FindObjectOfType<ShipPlayerController>()!=null && start){

          playerHealth=FindObjectOfType<PlayerHealthManager>();
          playerHealth.playerCurrentHealth=(int)healthBar.value;
          playerHealth.playerMaxHealth=(int)healthBar.maxValue;

          start=false;

        }
        if(FindObjectOfType<PlayerController>()!=null){
          playerHealth=FindObjectOfType<PlayerHealthManager>();
          start=true;
        }
        if(playerHealth!=null){
          if(FindObjectOfType<BattleUIManager>()==null){
            playerHealth=FindObjectOfType<PlayerController>().GetComponent<PlayerHealthManager>();
          }else{
            if(FindObjectOfType<ShipPlayerController>()!=null)
              playerHealth=FindObjectOfType<ShipPlayerController>().GetComponent<PlayerHealthManager>();
            else
            playerHealth=FindObjectOfType<PlayerController>().GetComponent<PlayerHealthManager>();

          }
          healthBar.maxValue = playerHealth.playerMaxHealth;
          healthBar.value = playerHealth.playerCurrentHealth;
          HPText.text = "HP: "+playerHealth.playerCurrentHealth+" / "+playerHealth.playerMaxHealth;

          expBar.maxValue = playerStats.toLevelUp[playerStats.currentLevel];
          expBar.value = playerStats.currentExp;
          EXPText.text = "EXP: "+playerStats.currentExp+" / "+playerStats.toLevelUp[playerStats.currentLevel];

          LVLText.text= "LVL: "+playerStats.currentLevel;



          healthBarUI.maxValue = playerHealth.playerMaxHealth;
          healthBarUI.value = playerHealth.playerCurrentHealth;
          HPTextUI.text = "HP: "+playerHealth.playerCurrentHealth+" / "+playerHealth.playerMaxHealth;

          expBarUI.maxValue = playerStats.toLevelUp[playerStats.currentLevel];
          expBarUI.value = playerStats.currentExp;
          EXPTextUI.text = "EXP: "+playerStats.currentExp+" / "+playerStats.toLevelUp[playerStats.currentLevel];

          LVLTextUI.text= "LVL: "+playerStats.currentLevel;
        }





    }
    public void turnOffInv(){
      FindObjectOfType<MusicController>().musicTracks[7].Play();

      HealthEXP.SetActive(false);

      inv.SetActive(false);
      equipped.SetActive(false);
      desc.SetActive(false);
      HealthEXP.SetActive(false);
      invActive=false;
      if(SceneManager.GetActiveScene().name!="ChoiceScreen")
        FindObjectOfType<PlayerController>().GetComponent<PlayerController>().canMove=true;
    }

    public void turnOnInv(){
      // also going to show HP / XP / LEVELS
      if(SceneManager.GetActiveScene().name!="ChoiceScreen");
        HealthEXP.SetActive(true);


      invActive=!invActive;
      if(!invActive){
        HealthEXP.SetActive(false);

        FindObjectOfType<MusicController>().musicTracks[7].Play();

      }else{
        FindObjectOfType<MusicController>().musicTracks[6].Play();

      }

      if(SceneManager.GetActiveScene().name!="ChoiceScreen"){
        FindObjectOfType<PlayerController>().GetComponent<PlayerController>().canMove=!FindObjectOfType<PlayerController>().GetComponent<PlayerController>().canMove;
      }
      invSelection=0;
      maxPageCount=theInventory.inv.Length / 4;
      if(theInventory.inv.Length%4!=0)
        maxPageCount++;
      pageCount=0;
    }

  }
