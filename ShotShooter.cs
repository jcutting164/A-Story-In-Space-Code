using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotShooter : MonoBehaviour
{
    // Start is called before the first frame update

    public float spawnTime;
    public int spawnCount;
    private float spawnCounter;
    public float lowSpeed;
    public float highSpeed;
    public int currentCount;

    private BattleEnemy Enemy;
    private GameObject EnemyGameObject;
    private BattleEnemy bEnemy;

    public GameObject ShotPrefab;


    void Start()
    {
      bEnemy=FindObjectOfType<BattleEnemy>();
      //EnemyGameObject=Enemy.BattleEnemy;
    //  bEnemy=EnemyGameObject.GetComponent<BattleEnemy>();
      spawnTime=bEnemy.spawnTime;
      spawnCount=bEnemy.spawnCount;
      lowSpeed=bEnemy.lowSpeed;
      highSpeed=bEnemy.highSpeed;
      spawnCounter=0;
    }

    // Update is called once per frame
    void Update()
    {
      spawnCounter+=Time.deltaTime;
      if(spawnCounter>=spawnTime && currentCount<spawnCount){
        spawnCounter=0;
        currentCount++;
        // make instance of a ball to yeet with correct speed

      //  ShotPrefab.GetComponent<Rigidbody2D>().velocity=new Vector3(Random.Range(lowSpeed,highSpeed),0,0);
        Instantiate(ShotPrefab, new Vector3(12,Random.Range(-1.5f,2.0f),transform.position.z), Quaternion.identity);
      }
      // check for amount launched or time taken... then make inactive then transfer to DEFENSE
    }
}
