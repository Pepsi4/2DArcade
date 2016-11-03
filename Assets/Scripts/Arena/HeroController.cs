using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HeroController : MonoBehaviour
{
    #region Fileds
    public static int lvl = 1;
    private int heroMaxHealth = 20;
    private int heroHealth = 20;
    private int enemyHealth = 20;
    private int enemyMaxHealth = 20;

    //private float deltaTimeNextRound = 2;   //float for timer. w8ing 2 secs before the controller could move again
    private bool isWaitingNextRound; //should we wait or not

    private float fillAmount; //float for fogging. 1 = max.
    private bool isEndOfScene; //Is the end of scene now.

    //private float deltaTimeTheEnd = 2; // w8ing 2 seconds before the game will end
    //private bool isWaitedTheEnd;  //when 2 secs passed

    private DialogInterface dialogIterface;


    #endregion

    void Start()
    {
    }

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
                CheckHealth(); //what to do, if heroHealth or enemyHealth <= 0
                StartCoroutine("CheckTheEndOfScene");
                isWaitingNextRound = true;
                StartCoroutine("WaitNextRound");
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
        CheckHealth(); //what to do, if heroHealth or enemyHealth <= 0
        isWaitingNextRound = false;

        if (isEndOfScene == false)
        {
            UpdateHeroHealth();
            Controller.IsCanGo = true;
            StartCoroutine("CheckTheEndOfScene");
        }
    }

    IEnumerator CheckTheEndOfScene()
    {
        if (isEndOfScene == true) //If it's the end of scene, we should wait 2 seconds.
        {
            //Actions is here(before timer)
            Controller.IsCanGo = false;
            //isWaitedTheEnd = true;
            yield return new WaitForSeconds(1);
            for (int i = 0; i < 100; i++)
            {
                FoggingTheScreen();
                yield return new WaitForSeconds(0.02f);
                //yield return new WaitUntil(() => fillAmount >= 1);
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
