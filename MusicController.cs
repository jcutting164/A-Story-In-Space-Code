using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MusicController : MonoBehaviour
{
    // Start is called before the first frame update

    public static bool mcExists;
    public AudioSource[] musicTracks;

    public int currentTrack;

    public bool musicCanPlay;

    void Start()
    {

      if(!mcExists){
        mcExists=true;
        DontDestroyOnLoad(transform.gameObject);
      }else{
        Destroy(gameObject);
      }


    }

    // Update is called once per frame
    void Update()
    {
      if(musicCanPlay && currentTrack==-999 && SceneManager.GetActiveScene().name!="1_1"){
        if(FindObjectOfType<MusicSwitcher>()!=null)
          switchTrack(FindObjectOfType<MusicSwitcher>().newTrack);
      }
      if(musicCanPlay && SceneManager.GetActiveScene().name!="1_1"){
        if(!musicTracks[currentTrack].isPlaying)
          musicTracks[currentTrack].Play();
      }else{
        if(currentTrack!=-999)
        musicTracks[currentTrack].Stop();
      }


      musicCanPlay=!(SceneManager.GetActiveScene().name=="1_1");

      if(!(SceneManager.GetActiveScene().name=="TitleScreen")){
        stopSpec(1);
      }
    }

    public void switchTrack(int newTrack){
      if(currentTrack!=-999)
        musicTracks[currentTrack].Stop();
      currentTrack=newTrack;
      musicTracks[currentTrack].Play();
    }

    public void stopCurrent(){
      musicTracks[currentTrack].Stop();
    }
    public void stopSpec(int spec){
      musicTracks[spec].Stop();
    }
}
