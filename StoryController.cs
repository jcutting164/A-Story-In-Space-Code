using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StoryController : MonoBehaviour
{
    // Start is called before the first frame update



    public Dictionary<string, bool> completions;
    public Dictionary<string, float> waitTimes;
    public Dictionary<string, string[]> lines;

    private DialogueManager dMan;
    public GameObject player;
    public GameObject loader;
    public static bool exists;





    // HOW TO ACTIVATE A "SCENE"
    // 1: be in a certain scene 2: activation media

    //def: activation media...
      // interaction of a player, key press, scene startup

    void Start()
    {
      if(player==null)
        player=FindObjectOfType<PlayerController>().gameObject;
      if(!exists){
        exists=true;
        DontDestroyOnLoad(transform.gameObject);
      }else{
        Destroy(gameObject);
      }
      completions = new Dictionary<string, bool>();
      waitTimes = new Dictionary<string, float>();
      lines = new Dictionary<string, string[]>();

      completions.Add("OpeningScene",false);
      waitTimes.Add("OpeningScene",3f);
      lines.Add("OpeningScene",new string[] {"Well hello there.", "You may be asking who I am. But first, can I tell you a story?", "Ok good, it may help explain who I am and maybe who you are.", "Ok. Here we go. There once was a space bounty hunter living on a planet, Hakarr..."});



      dMan=FindObjectOfType<DialogueManager>();
    }

    // Update is called once per frame
    void Update()
    {
      if(player==null){
        player=FindObjectOfType<PlayerController>().gameObject;
      }


      if(SceneManager.GetActiveScene().name=="OpeningScene" && !completions["OpeningScene"]){
        if(waitTimes["OpeningScene"]>0){
          waitTimes["OpeningScene"]-=Time.deltaTime;
        }else{
          if(!dMan.dialogActive){
            dMan.dialogLines=lines["OpeningScene"];
            dMan.currentLine=0;
            dMan.ShowDialogue();
            completions["OpeningScene"]=true;

          }
        }

      }else if(SceneManager.GetActiveScene().name=="OpeningScene" && completions["OpeningScene"]){
        Debug.Log(!dMan.isActive());
        if(completions["OpeningScene"] && !dMan.isActive()){
          FindObjectOfType<MusicController>().musicCanPlay=true;
          Application.LoadLevel("TitleScreen");
          FindObjectOfType<PlayerStats>().openingDone=true;
          FindObjectOfType<PlayerStats>().SavePlayer();


        }
      }else if((SceneManager.GetActiveScene().name=="TitleScreen" || SceneManager.GetActiveScene().name=="GameOver") && Input.GetKeyDown(KeyCode.Return)){
        if(SceneManager.GetActiveScene().name=="GameOver"){
          FindObjectOfType<PlayerStats>().LoadPlayer();
          FindObjectOfType<EnemyStats>().LoadEnemy();
        }
        player.GetComponent<PlayerController>().canMove=true;
      //  loader.GetComponent<LoadNewArea>().manualLoad();
        Application.LoadLevel(FindObjectOfType<PlayerStats>().lastScene);
        if(FindObjectOfType<PlayerStats>().lastScene=="1_1"){
          FindObjectOfType<PlayerController>().gameObject.transform.position=new Vector3(0.5446f, 1.073f, 0f);

        }else{
          //FindObjectOfType<PlayerController>().gameObject.transform.position=FindObjectOfType<PlayerStats>().transform.position;

        }
        //FindObjectOfType<PlayerController>().GetComponent<SpriteRenderer>().enabled=true;

        FindObjectOfType<MusicController>().stopCurrent();
        FindObjectOfType<MusicController>().currentTrack=-999;
        exists=false;

        Destroy(gameObject);


      }


    }
}
