using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleResetManager : MonoBehaviour
{
    // Start is called before the first frame update

    public string[] activations;

    void Start()
    {
    //  Debug.Log("resets");
  //    resetALL();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void resetALL(){
      for(int i = 0; i<activations.Length; i++){
        PlayerPrefs.SetInt(activations[i], 0);
      }
    }

    void Awake(){
      if(PlayerPrefs.GetInt("Launch")==0){
        Debug.Log("resets");

        resetALL();
      }

      PlayerPrefs.SetInt("Launch", 1);

    }
    void OnApplicationQuit(){
      PlayerPrefs.SetInt("Launch",0);
    }

}
