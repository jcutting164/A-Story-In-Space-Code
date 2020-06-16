using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public int damageToGive;
    public GameObject damageNumber;
    private PlayerStats thePlayerStats;
    private int currentDamage;
    void Start()
    {
      thePlayerStats=FindObjectOfType<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter2D(Collision2D other){
    	if(other.gameObject.name == "Player"){
        currentDamage =(damageToGive - thePlayerStats.currentDefence);
        if(currentDamage<=0)
          currentDamage=1;
        other.gameObject.GetComponent<PlayerHealthManager>().HurtPlayer(currentDamage);


        var clone=(GameObject)Instantiate(damageNumber, other.transform.position, Quaternion.Euler (Vector3.zero));
        clone.GetComponent<FloatingNumbers>().damageNumber=currentDamage;

      }

    }

}
