using UnityEngine;
using UnityEngine.UI;

public class MainHero : MonoBehaviour
{
    #region Fields and Properties

    private float speed = 0.015f;

    static private bool isCanGo = true;

    static private bool isTheEndOfPart = false;
    private bool isLeft = false;
    private bool isRight = false;

    static public bool IsTheEndOfPart
    {
        get { return isTheEndOfPart; }
        set { value = isTheEndOfPart; }
    }

    static public bool IsCanGo    {
        get { return isCanGo; }
        set { isCanGo = value; }
    }

    public bool IsLeft
    {
        get { return isLeft; }
        set { isLeft = value; }
    }

    public bool IsRight
    {
        get { return isRight; }
        set { isRight = value; }
    }

    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    #endregion

    void Start()
    {
    }

    public void Update()
    {
        IsGoing();
        IsStaying();

        if (IsTheEndOfPart && this.transform.position.x <= 16)
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
            GameObject.Find("MainHero").transform.Translate(-speed, 0, 0);
        }
        if (vect == "Right")
        {
            GameObject.Find("MainHero").transform.Translate(speed, 0, 0);
        }
    }

    //Is someone or something is near to main hero
    public bool IsNear(string name)
    {
        //inicialzation gm
        GameObject gm = GameObject.Find(name);
        //float mainHeroSizeX = GameObject.Find("MainHero").GetComponent<BoxCollider2D>().size.x;
        float gmSizeX = GameObject.Find(name).GetComponent<BoxCollider2D>().size.x;

        //Check if the gm's area has MainHero
        Collider2D[] coll = Physics2D.OverlapAreaAll(new Vector2(gm.transform.position.x - gmSizeX / 2, gm.transform.position.y - 2), new Vector2(gm.transform.position.x + gmSizeX / 2, gm.transform.position.y + 2));
        //Debug.Log((new Vector2(gm.transform.position.x, gm.transform.position.y - 1) + " " + new Vector2(gm.transform.position.x + gm.GetComponent<BoxCollider2D>().size.x - mainHeroSizeX / 2, gm.transform.position.y + 0.5f)));
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

    void GoToNextScene()
    {
        IsCanGo = false;
        AnimationGoRight();
        this.transform.Translate(transform.position.x * Time.deltaTime, 0, 0);
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
