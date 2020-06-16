using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleController : MonoBehaviour
{
    // Start is called before the first frame update

    private EnemyBattleStart Enemy;
    public GameObject EnemyGameObject;
    public Text enemyName;
  //  private GameObject EnemyGameObject;
    public BattleEnemy battleEnemy;
    public GameObject enemyBattleStart;

    void Start()
    {
        battleEnemy=FindObjectOfType<BattleEnemy>();

        Enemy=FindObjectOfType<EnemyBattleStart>();
        EnemyGameObject=Enemy.BattleEnemy;
        enemyBattleStart=FindObjectOfType<EnemyBattleStart>().gameObject;
        //Destroy(enemyBattleStart);
        EnemyGameObject.SetActive(true);

        Instantiate(EnemyGameObject, new Vector3(6f,-2.5f,0f), Quaternion.identity);
        enemyBattleStart=FindObjectOfType<EnemyBattleStart>().gameObject;


    }

    // Update is called once per frame
    void Update()
    {
      if(battleEnemy==null){

        battleEnemy=FindObjectOfType<BattleEnemy>();
        enemyName.text= FindObjectOfType<BattleEnemy>().enemyName;

      //  FindObjectOfType<MusicController>().switchTrack(battleEnemy.song);

      }
    }
}
