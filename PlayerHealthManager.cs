﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int playerMaxHealth;
    public int playerCurrentHealth;
    private bool flashActive;
    public float flashLength;
    private float flashCounter;

    private SpriteRenderer playerSprite;
    void Start()
    {
        if(!(SceneManager.GetActiveScene().name=="ChoiceScreen"))
          playerCurrentHealth=playerMaxHealth;

        playerSprite = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if(playerCurrentHealth<=0){
        //  gameObject.SetActive(false);
        }
        if(flashActive){

          if(flashCounter > flashLength * .66f){
            playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);

          }else if(flashCounter > flashLength * .33f){
            playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);

          }else if(flashCounter > 0){
            playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0);

          }else{
            playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
            flashActive=false;
          }

          flashCounter -= Time.deltaTime;

        }
        if(playerCurrentHealth>playerMaxHealth)
          playerCurrentHealth=playerMaxHealth;
        if(playerCurrentHealth<0)
          playerCurrentHealth=0;
    }

    public void HurtPlayer(int amt){
      playerCurrentHealth-=amt;
      flashActive=true;
      flashCounter=flashLength;

    }

    public void SetMaxHealth(){
      playerCurrentHealth=playerMaxHealth;
    }

}
