using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleEnemy : MonoBehaviour
{
    // Start is called before the first frame update

    public float spawnTime;
    public int spawnCount;
    public float lowSpeed;
    public float highSpeed;
    public int HP;
    public int MaxHP;
    public int defense;
    public int attack;
    public int maxHP;
    public string enemyName;
    public EnemyAttack[] attacks;
    public EnemyAttack[] bossAttacks;
    public GameObject presetFace;
    public string[] bossLines1;
    public string[] bossLines2;
    public string[] bossLines3;
    public string[] bossLines4;
    public bool bossLine1;
    public bool bossLine2;
    public bool bossLine3;
    public bool bossLine4;


    public int expToGive;

    public int song;
    public bool isBoss;





    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
