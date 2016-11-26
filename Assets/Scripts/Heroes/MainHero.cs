using UnityEngine;
using UnityEngine.UI;

public class MainHero : MonoBehaviour
{
    #region Fields and Properties

    private float speed = 0.015f;

    static private bool isCanGo = true;

    static private bool isTheEndOfPart = false;
    static private bool isLeft = false;
    static private bool isRight = false;
    static private bool isCanTalk = true;

    private static int gold = 15;
    private static int damage = 3;
    private static int armor = 1;

    private static int heroHealth = 20;
    private static int heroMaxHealth = 20;

    private static int level = 1;

    static public int HeroHealth
    {
        get { return heroHealth; }
        set { heroHealth = value; }
    }

    static public int HeroMaxHealth
    {
        get { return heroMaxHealth; }
        set { heroMaxHealth = value; }
    }


    static public int Level
    {
        get { return level; }
        set { level = value; }
    }

    static public int Damage
    {
        get { return damage; }
        set { damage = value; }
    }

    public static int Armor
    {
        get { return armor; }
        set { armor = value; }
    }

    static public bool IsTheEndOfPart
    {
        get { return isTheEndOfPart; }
        set { isTheEndOfPart = value; }
    }

    static public bool IsCanGo
    {
        get { return isCanGo; }
        set { isCanGo = value; }
    }

    static public bool IsLeft
    {
        get { return isLeft; }
        set { isLeft = value; }
    }

    static public bool IsRight
    {
        get { return isRight; }
        set { isRight = value; }
    }

    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    public static bool IsCanTalk
    {
        get { return isCanTalk; }
        set { isCanTalk = value; }
    }

    public static int Gold
    {
        get { return gold; }
        set { gold = value; }
    }

    #endregion

    void Start()
    {
        // Where should shows the main hero: right or left side
        if (Info.MainHeroPosition == "left")
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -1);
        }

        if (Info.MainHeroPosition == "right")
        {
            transform.position = new Vector3(transform.position.x + 1.5f, transform.position.y, -1);
        }


    }

    public void Update()
    {
        IsGoing();
        IsStaying();


        if (IsTheEndOfPart && this.transform.position.x <= 3)
        {
            GoToNextScene();
        }
    }

    public static bool IsPressedF()
    {
        if (Input.GetKeyDown(KeyCode.F) && !IsTheEndOfPart)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    void MainHeroGo(string vect)
    {
        if (vect == "Left")
        {
            //obj
            GameObject.Find("MainHero").transform.Translate(-speed, 0, 0);
            //UI
            GameObject.Find("Canvas/TextLvl").transform.Translate(-speed, 0, 0);
            GameObject.Find("Canvas/PanelLvl").transform.Translate(-speed, 0, 0);

        }
        if (vect == "Right")
        {
            //obj
            GameObject.Find("MainHero").transform.Translate(speed, 0, 0);
            //UI
            GameObject.Find("Canvas/TextLvl").transform.Translate(speed, 0, 0);
            GameObject.Find("Canvas/PanelLvl").transform.Translate(speed, 0, 0);
        }
    }

    //Is someone or something is near to main hero
    public bool IsNear(string name)
    {
        //inicialzation gm
        GameObject gm = GameObject.Find(name);
        float gmSizeX = GameObject.Find(name).GetComponent<BoxCollider2D>().size.x;

        //Checking if the gm's area has MainHero
        Collider2D[] coll = Physics2D.OverlapAreaAll(new Vector2(gm.transform.position.x - gmSizeX / 2, gm.transform.position.y - 2), new Vector2(gm.transform.position.x + gmSizeX / 2, gm.transform.position.y + 2));
        foreach (Collider2D collider in coll)
        {
            if (collider.gameObject.name == "MainHero")
            {
                return true;
            }
        }
        return false;
    }

    //If the main hero do nothing
    void IsStaying()
    {
        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            if (IsRight)
            {
                AnimationStopRight();
            }
            else if (IsLeft)
            {
                AnimationStopLeft();
            }
        }
    }

    //Left and Right
    void IsGoing()
    {
        if (Input.GetKey(KeyCode.D) && IsCanGo)
        {
            AnimationGoRight();
            IsRight = true;
            IsLeft = false;
            MainHeroGo("Right");
        }
        else if (Input.GetKey(KeyCode.A) && IsCanGo)
        {
            AnimationGoLeft();
            IsLeft = true;
            IsRight = false;
            MainHeroGo("Left");
        }
    }

    static void GoToNextScene()
    {
        IsCanGo = false;
        AnimationGoRight();
        GameObject.Find("MainHero").transform.Translate(GameObject.Find("MainHero").transform.position.x * Time.deltaTime, 0, 0);
    }

    static void AnimationGoRight()
    {
        GameObject.Find("MainHero").GetComponent<Animator>().Play("right");
    }

    static void AnimationGoLeft()
    {
        GameObject.Find("MainHero").GetComponent<Animator>().Play("left");
    }

    static void AnimationStopRight()
    {
        GameObject.Find("MainHero").GetComponent<Animator>().Play("MainHeroRightStop");
    }

    static void AnimationStopLeft()
    {
        GameObject.Find("MainHero").GetComponent<Animator>().Play("MainHeroLeftStop");
    }
}
