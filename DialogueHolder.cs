using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogueHolder : MonoBehaviour
{

    public string dialogue;

    public bool walkable;
    private DialogueManager dMan;

    public string[] dialogLines;
    public string[] duringConditionLines;

    public string[] postConditionLines;


    public GameObject presetFace;

    public string activation;

    // reward objects
    public GameObject Mission1_REWARD;
    public bool carrotChecker;


    // Start is called before the first frame update
    void Start()
    {
        dMan = FindObjectOfType<DialogueManager>();
    }

    // Update is called once per frame
    void Update()
    {
    }
// stay is used so its while the player is intersecting not the moment it enters the box!
    void OnTriggerStay2D(Collider2D other){
      if(other.gameObject.name == "Player"){
        if((Input.GetKeyUp(KeyCode.Space) && !walkable) || (walkable && !FindObjectOfType<PlayerController>().GetComponent<PlayerController>().hasBeenWalked(activation))){
          //dMan.ShowBox(dialogue);
          if(!dMan.dialogActive){

            // exception checking for side missions

            // explanation of how this works
            // checks for the correct dialog box and if the reqs match. Must have the item to give and NOT have the item to receive.
            if(activation=="1_3_Mission1" && FindObjectOfType<InventoryManager>().checkForItem("Black Flower") && (!FindObjectOfType<InventoryManager>().checkForItem("The Sword of Jurat") || !(FindObjectOfType<PlayerController>().checkWeapon("The Sword of Jurat")))){
              dMan.dialogLines=duringConditionLines;
              FindObjectOfType<InventoryManager>().removeItem("Black Flower");
              FindObjectOfType<InventoryManager>().addItem(Mission1_REWARD.GetComponent<ItemController>());
              Mission1_REWARD.gameObject.transform.parent=FindObjectOfType<InventoryManager>().gameObject.transform;

            }else if(activation=="1_3_Mission1" && (FindObjectOfType<InventoryManager>().checkForItem("The Sword of Jurat") || (FindObjectOfType<PlayerController>().checkWeapon("The Sword of Jurat")))){
              dMan.dialogLines=postConditionLines;

            }else{
              if(carrotChecker)
                dialogLines[3]="YOU HAVE: "+FindObjectOfType<InventoryManager>().FindAll("Carrot")+" CARROTS!";

              dMan.dialogLines=dialogLines;
            }
            dMan.currentLine=0;

            // ^^^ add else if for other missions of similar variety

          //  dMan.face.GetComponent<SpriteRenderer>().sprite=presetFace.GetComponent<SpriteRenderer>().sprite;
          //  if(presetFace=null)
          //    presetFace=ParentGameObject.transform.GetChild(0).gameObject;
            dMan.ShowDialogue(presetFace);

          }
          // transform.parent is the parent object's transfrom of who its attached to
          // if the object is a villager (via the movement script)
          if(transform.parent!=null){
            if(transform.parent.GetComponent<VillagerMovement>() != null){
              // accessing that object and its public attributes
              transform.parent.GetComponent<VillagerMovement>().canMove=false;
            }
          }

          if(walkable && !FindObjectOfType<PlayerController>().GetComponent<PlayerController>().hasBeenWalked(activation)){
            FindObjectOfType<PlayerController>().GetComponent<PlayerController>().addUsedWalkable(activation);
          }



        }
      }
    }
}
