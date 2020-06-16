using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNewArea : MonoBehaviour
{

	public string levelToLoad;

	public string exitPoint;


	private PlayerController thePlayer;
    // Start is called before the first frame update
    void Start()
    {
			thePlayer=FindObjectOfType<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {
			if(SceneManager.GetActiveScene().name=="1_9_PURPLE" && FindObjectOfType<EnemyBattleStart>()==null && levelToLoad=="1_3"){
				gameObject.SetActive(false);
			}
    }


	void OnTriggerEnter2D(Collider2D other){

		if(other.gameObject.name == "Player"){
			Application.LoadLevel(levelToLoad);
			thePlayer.startPoint=exitPoint;

		}
		Application.LoadLevel(levelToLoad);


	}


	public void manualLoad(){
		Application.LoadLevel(levelToLoad);
		thePlayer.startPoint=exitPoint;
	}

}
