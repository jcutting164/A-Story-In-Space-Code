using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int MaxHealth;
    public int CurrentHealth;
    private PlayerStats thePlayerStats;
    public int expToGive;

    public string enemyQuestName;
    private QuestManager theQM;


    void Start()
    {
        CurrentHealth=MaxHealth;
        thePlayerStats=FindObjectOfType<PlayerStats>();
        theQM=FindObjectOfType<QuestManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if(CurrentHealth<=0){
          Destroy(gameObject);
          thePlayerStats.AddExperience(expToGive);
          theQM.enemyKilled=enemyQuestName;
        }
    }

    public void HurtEnemy(int amt){
      CurrentHealth-=amt;

    }

    public void SetMaxHealth(){
      CurrentHealth=MaxHealth;
    }

}
