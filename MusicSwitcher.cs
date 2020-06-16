using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSwitcher : MonoBehaviour
{
    // Start is called before the first frame update

    private MusicController theMC;
    public int newTrack;

    public bool switchOnStart;
    void Start()
    {
        theMC = FindObjectOfType<MusicController>();
        if(switchOnStart){
          if(newTrack!=1){
            theMC.switchTrack(newTrack);
            gameObject.SetActive(false);
          }

        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other){
      if(other.gameObject.name == "Player"){
        theMC.switchTrack(newTrack);
        gameObject.SetActive(false);
      }
    }
}
