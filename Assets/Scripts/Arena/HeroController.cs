using UnityEngine;
using UnityEngine.UI;

public class HeroController : MonoBehaviour
{
    #region Fileds
    public static int lvl = 1;
    public static int heroHealth = 20;
    public static int enemyHealth = 20;

    private float deltaTime = 2;
    private bool isWaiting; //should we wait or not

    private float fillAmount; //for fogging

    #endregion

    void Update()
    {
        EndOfScene();
        if (MainHero.IsPressedF())
        {
            //Checking where is the contoler and makes demage to an enemy
            Controller.IsCanGo = false;
            UpdateEnemyHelth();
            isWaiting = true;
        }

        //Checking, if we should wait 2 sec
        CheckTimer();
    }

    void CheckTimer()
    {
        //Waiting 2 seconds
        if (isWaiting)
        {
            if (Wait())
            {
                UpdateHeroHealth();
                Controller.IsCanGo = true;
                isWaiting = false;
            }
        }
    }



    bool Wait()
    {
        if (deltaTime <= 0)
        {
            deltaTime = 2;
            return true;
        }
        else
        {
            deltaTime -= Time.deltaTime;
            return false;
        }
    }


    void UpdateEnemyHelth()
    {
        Controller.CheckGreenAreaDmg();
        enemyHealth -= Controller.HeroDmg;
        GameObject.Find("Canvas/EnemyHealthBG/EnemyHealth").GetComponent<Text>().text = enemyHealth + " / 20";
    }

    void UpdateHeroHealth()
    {
        heroHealth -= Enemy.MakeDmg();
        GameObject.Find("Canvas/MainHeroHealthBG/MainHeroHealth").GetComponent<Text>().text = heroHealth + " / 20";
    }

    void EndOfScene()
    {
        fillAmount += 0.01f;
        GameObject.Find("BlackImage").GetComponent<Image>().fillAmount = fillAmount;
    }
}
