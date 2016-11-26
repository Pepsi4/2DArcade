using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    #region Fields and Properties
    private static GameObject scroll;  //the black line on the scene "arena"
    private GameObject bg;  //background for the black line

    private static float speed = 7f;
    private static float bgMaxSizeX; //Max x for the black line
    private static float bgMinSizeX; //Min x for the black line

    private static float maxSizeXGreenArea_1;
    private static float minSizeXGreenArea_1;
    private static float maxSizeXGreenArea_2;
    private static float minSizeXGreenArea_2;
    private static float maxSizeXGreenArea_3;
    private static float minSizeXGreenArea_3;

    private static int lvl;
    private static int heroDmg = 1;

    private static bool isCanGo = true;
    private static bool isRight = true;
    private static bool isLeft;

    public bool IsLeft
    {
        get
        {
            return isLeft;
        }

        set
        {
            isLeft = value;
        }
    }

    public bool IsRight
    {
        get
        {
            return isRight;
        }

        set
        {
            isRight = value;
        }
    }

    public static bool IsCanGo
    {
        get
        {
            return isCanGo;
        }

        set
        {
            isCanGo = value;
        }
    }

    public static int HeroDmg
    {
        get
        {
            return heroDmg;
        }

        set
        {
            heroDmg = value;
        }
    }
    #endregion
    void Start()
    {
        IsCanGo = true;

        scroll = GameObject.Find("Canvas/Scroll");
        bg = GameObject.Find("Canvas/BG");

        maxSizeXGreenArea_1 = GameObject.Find("GreenArea_1").transform.position.x + GameObject.Find("GreenArea_1").GetComponent<RectTransform>().rect.width / 2;
        minSizeXGreenArea_1 = GameObject.Find("GreenArea_1").transform.position.x - GameObject.Find("GreenArea_1").GetComponent<RectTransform>().rect.width / 2;

        maxSizeXGreenArea_2 = GameObject.Find("GreenArea_2").transform.position.x + GameObject.Find("GreenArea_2").GetComponent<RectTransform>().rect.width / 2;
        minSizeXGreenArea_2 = GameObject.Find("GreenArea_2").transform.position.x - GameObject.Find("GreenArea_2").GetComponent<RectTransform>().rect.width / 2;

        maxSizeXGreenArea_3 = GameObject.Find("GreenArea_3").transform.position.x + GameObject.Find("GreenArea_3").GetComponent<RectTransform>().rect.width / 2;
        minSizeXGreenArea_3 = GameObject.Find("GreenArea_3").transform.position.x - GameObject.Find("GreenArea_3").GetComponent<RectTransform>().rect.width / 2;

        bgMaxSizeX = bg.transform.position.x + bg.GetComponent<RectTransform>().rect.width / 2;
        bgMinSizeX = bg.transform.position.x - bg.GetComponent<RectTransform>().rect.width / 2;
    }

    void Update()
    {
        IsGoLeft();
        IsGoRight();
    }

    //Check where the controller is
    public static string GetGreenArea()
    {
        float scrollX = scroll.transform.position.x;
        if (scrollX >= minSizeXGreenArea_3 && scrollX <= maxSizeXGreenArea_3)
        {
            return "GreenArea_3";
        }

        if (scrollX >= minSizeXGreenArea_2 && scrollX <= maxSizeXGreenArea_2)
        {
            return "GreenArea_2";
        }

        if (scrollX >= minSizeXGreenArea_1 && scrollX <= maxSizeXGreenArea_1)
        {
            return "GreenArea_1";
        }

        return "WhiteArea";
    }

    public static void CheckGreenAreaDmg()
    {
        switch (GetGreenArea())
        {
            case "GreenArea_1":
                HeroDmg = 1;
                HeroDmg = (int)(MainHero.Damage * 0.25f);
                break;

            case "GreenArea_2":
                HeroDmg = 2;
                HeroDmg = (int)(MainHero.Damage * 0.5f);
                break;

            case "GreenArea_3":
                HeroDmg = 3;
                HeroDmg = (int)(MainHero.Damage * 0.75f);
                break;

            case "WhiteArea":
                heroDmg = 0;
                break;
        }
    }

    void IsGoLeft()
    {
        if (IsLeft && isCanGo) //Go left
        {
            GoLeft();
            if (scroll.transform.position.x <= bgMinSizeX)  //If the black line is too far from the start point
            {
                IsRight = true;
                IsLeft = false;
            }
        }
    }

    void IsGoRight()
    {
        if (IsRight && isCanGo) //Go right
        {
            GoRight();
            if (scroll.transform.position.x >= bgMaxSizeX)  //If the black line is too far
            {
                IsLeft = true;
                IsRight = false;
            }
        }
    }

    void GoLeft()
    {
        scroll.transform.Translate(-speed, 0, 0);
    }

    void GoRight()
    {
        scroll.transform.Translate(speed, 0, 0);
    }

}
