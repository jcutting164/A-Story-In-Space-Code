using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoKey : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isWhiteKey;
    public string input;
    public AudioSource toBePlayed;
    private KeyCode keycode;
    void Start()
    {
      if(input=="A"){
        keycode=KeyCode.A;
      }else if(input=="S"){
        keycode=KeyCode.S;
      }else if(input=="D"){
        keycode=KeyCode.D;
      }else if(input=="F"){
        keycode=KeyCode.F;
      }else if(input=="G"){
        keycode=KeyCode.G;
      }else if(input=="H"){
        keycode=KeyCode.H;
      }else if(input=="J"){
        keycode=KeyCode.J;
      }else if(input=="K"){
        keycode=KeyCode.K;
      }else if(input=="W"){
        keycode=KeyCode.W;
      }else if(input=="E"){
        keycode=KeyCode.E;
      }else if(input=="T"){
        keycode=KeyCode.T;
      }else if(input=="Y"){
        keycode=KeyCode.Y;
      }else if(input=="U"){
        keycode=KeyCode.U;
      }else if(input=="O"){
        keycode=KeyCode.O;
      }



    }


    // Update is called once per frame
    void Update()
    {
      if(Input.GetKeyDown(keycode)){
        toBePlayed.Play();
        GetComponent<SpriteRenderer>().enabled=false;
        if(FindObjectOfType<PianoPuzzleManager>()!=null)
          FindObjectOfType<PianoPuzzleManager>().testKey(input);
      }else if(Input.GetKeyUp(keycode)){
        GetComponent<SpriteRenderer>().enabled=true;

      }
    }
}
