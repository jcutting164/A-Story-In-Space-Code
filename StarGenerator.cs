using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject star;
    public BattleEnemy battleEnemy;
    public float spawnTime;
    public float spawnCounter;
    public float lowY;
    public float highY;
    public float lowX;
    public float highX;
    public bool isAttackGen;
    public bool isOn;
    public int objectCounter;

    public int currentOption;
    void Start()
    {
      if(isAttackGen)
        battleEnemy=FindObjectOfType<BattleEnemy>();
      objectCounter=0;
    }

    // Update is called once per frame
    void Update()
    {
      if(isOn){
        if(isAttackGen && battleEnemy==null)
          battleEnemy=FindObjectOfType<BattleEnemy>();

          if(isAttackGen && battleEnemy==null){
            battleEnemy=FindObjectOfType<BattleEnemy>();
          }
          if(battleEnemy!=null){
            if(battleEnemy.isBoss && battleEnemy.HP <= battleEnemy.MaxHP/2){
              spawnCounter+=Time.deltaTime;
              if(spawnCounter>=spawnTime && !isAttackGen){
                Instantiate(star, new Vector3(Random.Range(lowX, highX),Random.Range(lowY,highY),transform.position.z), Quaternion.identity);

                spawnCounter=0;
              }else if(spawnCounter>=spawnTime && isAttackGen && objectCounter<battleEnemy.bossAttacks[currentOption].count){
                Instantiate(battleEnemy.bossAttacks[currentOption], new Vector3(Random.Range(lowX, highX),Random.Range(lowY,highY),transform.position.z), Quaternion.identity);
                spawnCounter=0;
                objectCounter++;
              }

            }else{
              spawnCounter+=Time.deltaTime;
              if(spawnCounter>=spawnTime && !isAttackGen){
                Instantiate(star, new Vector3(Random.Range(lowX, highX),Random.Range(lowY,highY),transform.position.z), Quaternion.identity);

                spawnCounter=0;
              }else if(spawnCounter>=spawnTime && isAttackGen && objectCounter<battleEnemy.attacks[currentOption].count){
                Instantiate(battleEnemy.attacks[currentOption], new Vector3(Random.Range(lowX, highX),Random.Range(lowY,highY),transform.position.z), Quaternion.identity);
                spawnCounter=0;
                objectCounter++;
              }
            }
          }else{
            spawnCounter+=Time.deltaTime;
            if(spawnCounter>=spawnTime && !isAttackGen){
              Instantiate(star, new Vector3(Random.Range(lowX, highX),Random.Range(lowY,highY),transform.position.z), Quaternion.identity);

              spawnCounter=0;
            }
          }
      }
        // end of is on
        if(isAttackGen && battleEnemy!=null){

          if(battleEnemy.isBoss && battleEnemy.HP <= battleEnemy.MaxHP*.75 && FindObjectOfType<ChoiceManager>().currentState=="START" && !battleEnemy.bossLine1){
            FindObjectOfType<DialogueManager>().dialogLines=battleEnemy.bossLines1;
            FindObjectOfType<DialogueManager>().currentLine=0;
            FindObjectOfType<DialogueManager>().ShowDialogue(battleEnemy.presetFace);
            battleEnemy.bossLine1=true;
          }else if(battleEnemy.isBoss && battleEnemy.HP <= battleEnemy.MaxHP*.50 && FindObjectOfType<ChoiceManager>().currentState=="START" && !battleEnemy.bossLine2){
            FindObjectOfType<DialogueManager>().dialogLines=battleEnemy.bossLines2;
            FindObjectOfType<DialogueManager>().currentLine=0;
            FindObjectOfType<DialogueManager>().ShowDialogue(battleEnemy.presetFace);
            battleEnemy.bossLine2=true;

          }else if(battleEnemy.isBoss && battleEnemy.HP <= battleEnemy.MaxHP*.30 && FindObjectOfType<ChoiceManager>().currentState=="START" && !battleEnemy.bossLine3){
            FindObjectOfType<DialogueManager>().dialogLines=battleEnemy.bossLines3;
            FindObjectOfType<DialogueManager>().currentLine=0;
            FindObjectOfType<DialogueManager>().ShowDialogue(battleEnemy.presetFace);
            battleEnemy.bossLine3=true;

          }else if(battleEnemy.isBoss && battleEnemy.HP <= battleEnemy.MaxHP*.10 && FindObjectOfType<ChoiceManager>().currentState=="START" && !battleEnemy.bossLine4){
            FindObjectOfType<DialogueManager>().dialogLines=battleEnemy.bossLines4;
            FindObjectOfType<DialogueManager>().currentLine=0;
            FindObjectOfType<DialogueManager>().ShowDialogue(battleEnemy.presetFace);
            battleEnemy.bossLine4=true;

          }

        }





    }

    public void changeOption(){
      if(isAttackGen && battleEnemy==null)
        battleEnemy=FindObjectOfType<BattleEnemy>();


      System.Random random = new System.Random();
      currentOption = random.Next(0, battleEnemy.attacks.Length);
    }
}
