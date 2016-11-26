using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HeroController : MonoBehaviour
{
    #region Fields
    private int heroHealth = MainHero.HeroHealth;
    private int heroMaxHealth = MainHero.HeroMaxHealth;
    private int enemyHealth = Enemy.EnemyHealth;
    private int enemyMaxHealth = Enemy.EnemyMaxHealth;


    private bool isWaitingNextRound; //should we wait or not

    private float fillAmount; //float for fogging. 1 = max.
    private bool isEndOfScene; //Is the end of scene now.

    private DialogInterface dialogIterface;


    #endregion


    void Update()
    {
        SceneTriggers(); //Pressed F, etc
    }

    void ActionsInTheEnd()
    {
        //Actions is here(after timer)
        Info.MainHeroPosition = "right";
        MainHero.IsLeft = true;
        MainHero.IsCanTalk = false;
        TopUI.SyncTopUi();
        Application.LoadLevel("street_1");
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

                StartCoroutine("WaitNextRound");
                CheckHealth(); //what to do, if heroHealth or enemyHealth <= 0
                StartCoroutine("CheckTheEndOfScene");
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
                ArenaInfo.AfterGame = (int)StatusAfterGame.lose;
            }

            if (enemyHealth <= 0)
            {
                ArenaInfo.AfterGame = (int)StatusAfterGame.won;
            }
        }
    }

    IEnumerator WaitNextRound()
    {
        yield return new WaitForSeconds(2);


        if (isEndOfScene == false)
        {
            UpdateHeroHealth();
            CheckHealth(); //what to do, if heroHealth or enemyHealth <= 0
            Controller.IsCanGo = true;
            StartCoroutine("CheckTheEndOfScene");
        }
        
        isWaitingNextRound = false;
    }

    IEnumerator CheckTheEndOfScene()
    {
        if (isEndOfScene == true) //If it's the end of scene, we should wait 2 seconds.
        {
            //Actions is here(before timer)
            Controller.IsCanGo = false;
            yield return new WaitForSeconds(1);
            for (int i = 0; i < 100; i++)
            {
                FoggingTheScreen();
                yield return new WaitForSeconds(0.02f);
            }

            ActionsInTheEnd();
        }

    }

    void UpdateEnemyHelth()
    {
        Controller.CheckGreenAreaDmg();
        enemyHealth -= Controller.HeroDmg;
        if (enemyHealth <= 0) enemyHealth = 0;
        GameObject.Find("Canvas/EnemyUI/EnemyHealth").GetComponent<Text>().text = enemyHealth + " / " + enemyMaxHealth;
        HealthController.UpdateEnemyHealthBar(enemyHealth, enemyMaxHealth);
    }

    void UpdateHeroHealth()
    {
        heroHealth -= Enemy.MakeDmg();
        if (heroHealth <= 0) heroHealth = 0;
        GameObject.Find("Canvas/HeroUI/HeroHealth").GetComponent<Text>().text = heroHealth + " / " + heroMaxHealth;
        HealthController.UpdateHeroHealthBar(heroHealth, heroMaxHealth);
    }

    void FoggingTheScreen()
    {
        fillAmount += 0.01f;
        GameObject.Find("BlackImage").GetComponent<Image>().fillAmount = fillAmount;
    }
}
