using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotController : MonoBehaviour
{
    // Start is called before the first frame update
    private ShotShooter SS;
    private Rigidbody2D rb;
    private bool hitPaddle;
    private SFXManager sfxMan;
    private BattleEnemy battleEnemy;
    void Start()
    {
      sfxMan=FindObjectOfType<SFXManager>();
      rb = GetComponent<Rigidbody2D>();

      SS=FindObjectOfType<ShotShooter>();

      rb.velocity=new Vector3(Random.Range(SS.lowSpeed, SS.highSpeed),0,0);
      battleEnemy=FindObjectOfType<BattleEnemy>();
    }

    // Update is called once per frame
    void Update()
    {
      if(gameObject.transform.position.x<=-12f){
        Destroy(gameObject);
      }
    }
    void OnTriggerEnter2D(Collider2D other){
      if(other.tag=="Paddle"){
        sfxMan.paddleHit.Play();
        hitPaddle=true;
        rb.velocity=new Vector3(rb.velocity.x*-1, Random.Range(SS.highSpeed, -1*SS.highSpeed),0);

      }else if(other.tag=="PaddleBounds"){
        rb.velocity=new Vector3(rb.velocity.x, rb.velocity.y*Random.Range(-1.5f,-1f),0);

      }else if(other.tag=="ScoreBox" && hitPaddle){
        sfxMan.offenseHit.Play();
        battleEnemy.HP-= FindObjectOfType<PlayerStats>().GetComponent<PlayerStats>().getAttackPower();
        Destroy(gameObject);
      }
    }
}
