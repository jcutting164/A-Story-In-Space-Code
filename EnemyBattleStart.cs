using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyBattleStart : MonoBehaviour
{

    public GameObject BattleEnemy;
    public int song;
    public string activation;

    public bool isBoss;

    public EnemyStats enemyStats;

    public GameObject presetFace;
    // Start is called before the first frame update
    void Start()
    {

      if(enemyStats!=null){
        gameObject.SetActive(!(FindObjectOfType<EnemyStats>().contains(activation)));


      }

    }

    // Update is called once per frame
    void Update()
    {
      if(enemyStats==null){
        enemyStats=FindObjectOfType<EnemyStats>();
        gameObject.SetActive(!(FindObjectOfType<EnemyStats>().contains(activation)));

      }

    //  gameObject.SetActive(!(enemyStats.map[activation]));

    }

    void OnTriggerEnter2D(Collider2D other){
      if(other.tag=="Player"){
        if(enemyStats==null)
          enemyStats=FindObjectOfType<EnemyStats>();
        if(!FindObjectOfType<EnemyStats>().contains(activation)){
          FindObjectOfType<MusicController>().switchTrack(song);

          // start the Fight
          //other.gameObject.SetActive(false);
          GetComponent<VillagerMovement>().battleWalk=true;
          if(enemyStats!=null)
            enemyStats.killEnemy(activation);
          else{
            enemyStats=FindObjectOfType<EnemyStats>();
            enemyStats.killEnemy(activation);
          }
          DontDestroyOnLoad(gameObject);
          FindObjectOfType<UIManager>().GetComponent<UIManager>().turnOffInv();
          PlayerPrefs.SetString("lastLoadedScene", SceneManager.GetActiveScene().name);
          PlayerPrefs.SetFloat("PlayerX", FindObjectOfType<PlayerController>().gameObject.transform.position.x);
          PlayerPrefs.SetFloat("PlayerY", FindObjectOfType<PlayerController>().gameObject.transform.position.y);
          gameObject.GetComponent<BoxCollider2D>().enabled=false;

          if(!FindObjectOfType<PlayerController>().GetComponent<PlayerController>().tutorialDone){
            string[] lines = new string[4];
            lines[0]="Hey man, looks like your in your first battle in awhile, let me help you out.";
            lines[1]="Ok so what you're gonna have some options on your left. Use the ARROWS and ENTER to select one of these choices. Just remember, use 'z' to go back.";
            lines[2]="Most likely you're going to want to FIGHT or RUN. If you fight, you have to try to hit a target to do damage. You can try to run sometimes but it won't always work.";
            lines[3]="Plus if you win fights, you'll gain experience and possibly find some space units lying around! Good luck! Also on defense, hit SPACE to increase your odds of success!";


            FindObjectOfType<DialogueManager>().dialogLines=lines;
            FindObjectOfType<DialogueManager>().currentLine=0;
          //  dMan.face.GetComponent<SpriteRenderer>().sprite=presetFace.GetComponent<SpriteRenderer>().sprite;
          //  if(presetFace=null)
          //    presetFace=ParentGameObject.transform.GetChild(0).gameObject;
            FindObjectOfType<DialogueManager>().ShowDialogue(presetFace);
            FindObjectOfType<PlayerController>().GetComponent<PlayerController>().tutorialDone=true;

          }

          Application.LoadLevel("ChoiceScreen");



        }else{
          gameObject.SetActive(false);
        }

        //cam.GetComponent<AudioListener>().SetActive(false);



      }
    }

}
