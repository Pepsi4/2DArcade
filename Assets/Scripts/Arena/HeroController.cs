﻿using UnityEngine;
using UnityEngine.UI;

public class HeroController : MonoBehaviour
{
    #region Fileds
    public static int lvl = 1;
    public static int heroHealth = 15;
    public static int enemyHealth = 2;

    private float deltaTimeNextRound = 2;   //float for timer. w8ing 2 secs before the controller could move again
    private bool isWaitingNextRound; //should we wait or not
    
    private float fillAmount; //float for fogging. 1 = max.
    private bool isEndOfScene; //Is the end of scene now.

    private float deltaTimeTheEnd = 2; // w8ing 2 seconds before the game will end
    private bool isWaitedTheEnd;  //when 2 secs passed

    private DialogInterface dialogIterface;
    #endregion

    void Start()
    {
    }

    void Update()
    {
        
        SceneTriggers(); //Pressed F, etc
        CheckTimer(); //Checking, if we should wait 2 seconds for next round
        CheckHealth(); //what to do, if heroHealth or enemyHealth <= 0 
        IsTheEndOfScene();  //Checking, if the end of scene. And doing actions
        if (isWaitedTheEnd) //If 2 seconds flashed we fogging the screen
        {
            //Actions is here(after timer)
            Info.MainHeroPosition = "right";
            MainHero.IsLeft = true;
            Application.LoadLevel("street_1");
        }
        
        
    }

    void IsTheEndOfScene()
    {
        if (isEndOfScene == true) //If it's the end of scene, we should wait 2 seconds.
        {
            //Actions is here(before timer)
            FoggingTheScreen();

            Controller.IsCanGo = false;

            if (WaitingTheEnd())  //Showing us if we still should wait 2 seconds. //true - time passed
            {
                isWaitedTheEnd = true;
            }
        }
    }

    void SceneTriggers()
    {
        if (isEndOfScene == false)
        {
            if (MainHero.IsPressedF() && isWaitingNextRound == false)   //if F pressed
            {
                //Checking where is the contoler and makes demage to an enemy
                Controller.IsCanGo = false;
                UpdateEnemyHelth();
                isWaitingNextRound = true;
            }
        }
    }
    
    void CheckHealth() //for both heroes
    {
        //When the game is over
        if (heroHealth <= 0 || enemyHealth <= 0)
        {
            isEndOfScene = true;
            if (heroHealth <= 0)
            {
                ArenaInfo.IsWon = false;
                Debug.Log(ArenaInfo.IsWon);
            }

            if (enemyHealth <= 0)
            {
                ArenaInfo.IsWon = true;
                Debug.Log(ArenaInfo.IsWon);
            }
        }
    }

    void CheckTimer()
    {
        //Waiting 2 seconds
        if (isWaitingNextRound)
        {
            if (WaitingNextRound())
            {
                UpdateHeroHealth();
                isWaitingNextRound = false;
                if (isEndOfScene == false && isWaitedTheEnd == false)
                {
                    Controller.IsCanGo = true;
                }
            }
        }
    }
    
    bool WaitingNextRound()
    {
        if (deltaTimeNextRound <= 0)
        {
            deltaTimeNextRound = 2;
            return true;
        }
        else
        {
            deltaTimeNextRound -= Time.deltaTime;
            return false;
        }
    }

    bool WaitingTheEnd()
    {
        if (deltaTimeTheEnd <= 0)
        {
            deltaTimeTheEnd = 2;
            return true;
        }
        else
        {
            deltaTimeTheEnd -= Time.deltaTime;
            return false;
        }
    }
    
    void UpdateEnemyHelth()
    {
        Controller.CheckGreenAreaDmg();
        enemyHealth -= Controller.HeroDmg;
        if (enemyHealth <= 0) enemyHealth = 0;
        GameObject.Find("Canvas/EnemyHealthBG/EnemyHealth").GetComponent<Text>().text = enemyHealth + " / 20";
    }

    void UpdateHeroHealth()
    {
        heroHealth -= Enemy.MakeDmg();
        if (heroHealth <= 0) heroHealth = 0;
        GameObject.Find("Canvas/MainHeroHealthBG/MainHeroHealth").GetComponent<Text>().text = heroHealth + " / 20";
    }

    void FoggingTheScreen()
    {
        fillAmount += 0.01f;
        GameObject.Find("BlackImage").GetComponent<Image>().fillAmount = fillAmount;
    }
}
