using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Persistance : MonoBehaviour
{
    // Start is called before the first frame update

    public float spawnTime;
    public int spawnCount;
    public float lowSpeed;
    public float highSpeed;
    public int HP;
    public int defense;
    public int attack;
    public int maxHP;
    public string enemyName;
    public EnemyAttack[] attacks;

    public SpriteRenderer sprite;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
