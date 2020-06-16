using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{

  //  public Dictionary<string,bool> map = new Dictionary<string, bool>();
    public string[] activations;
    public static bool exists;
  //  public static bool exists;

    // Start is called before the first frame update
    void Start()
    {

      if(!exists){
        exists=true;
        DontDestroyOnLoad(transform.gameObject);
      }else{
        Destroy(gameObject);
      }
  /*      if(!exists){
          exists=true;
          DontDestroyOnLoad(transform.gameObject);
        }else{
          Destroy(gameObject);
        }*/
    /*    map.Add("Tree1",false);
        map.Add("Bird1",false);
        map.Add("Bird2",false);
        map.Add("Eye1",false);
        map.Add("Skert1",false);
        map.Add("Skert2",false);
        map.Add("Eye_BH", false);
        map.Add("TheCommander", false);*/
        activations=new string[0];
        DontDestroyOnLoad(gameObject);

        LoadEnemy();




    }

    // Update is called once per frame
    void Update()
    {

    }

    public void addActivation(string used){
      string[] temp = activations;
      activations=new string[activations.Length+1];
      for(int i = 0; i<activations.Length-1; i++)
        activations[i]=temp[i];
      activations[temp.Length]=used;
    }

    public void killEnemy(string activation){
      addActivation(activation);
      // THIS GETS SAVED WITH A BIGGER ENCOMPOSING SAVE OBJECT LATER
    }

    public void SaveEnemy(){
      SaveSystem.SaveEnemy(this);
    }
    public void LoadEnemy(){
      EnemyData data = SaveSystem.LoadEnemy();
    //  Debug.Log("1; "+data.musicCanPlay);
      //map=data.map;
      if(data!=null)
        activations=data.activations_Save;
    }

    public bool contains(string toBeChecked){
      bool answer=false;
      for(int i = 0; i<activations.Length; i++){
        if(activations[i]==toBeChecked){
          answer=true;
          break;
        }
      }
      return answer;
    }
}
