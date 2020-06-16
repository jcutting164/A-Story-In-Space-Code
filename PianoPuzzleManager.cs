using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoPuzzleManager : MonoBehaviour
{
    // Start is called before the first frame update
    // the code is in keyboard keys
    public string[] puzzleCode;
    public bool[] progress;
    private int currentSpot;

    public GameObject[] toDestroy;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void resetPuzzle(){
      currentSpot=0;

      for(int i = 0; i<progress.Length; i++)
        progress[i]=false;
    }

    public void testKey(string key){
      if(puzzleCode[currentSpot]==key){
        progress[currentSpot]=true;
        currentSpot++;
        if(isDone()){
          for(int i = 0; i<toDestroy.Length; i++){
            toDestroy[i].SetActive(false);
          }
          gameObject.SetActive(false);
        }
      }else{
        resetPuzzle();
      }
    }
    public bool isDone(){
      bool result=true;
      for(int i = 0; i<progress.Length; i++){
        if(!progress[i]){
          result=false;
          break;
        }
      }
      return result;
    }
}
