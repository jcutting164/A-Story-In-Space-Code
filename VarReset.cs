using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VarReset : MonoBehaviour
{
    // Start is called before the first frame update
    public string[] resetVars;
    void Start()
    {
    //  PlayerPrefs.SetInt("Alive",0);
      RESET();


    }

    // Update is called once per frame
    void Update()
    {

    }

    void RESET(){
      Debug.Log("reset");
      for(int i = 0; i<resetVars.Length; i++){
        PlayerPrefs.SetInt(resetVars[i],0);
      }
    }



}
