using UnityEngine;
using UnityEngine.UI;

public class MainHero : MonoBehaviour
{
    #region Fields and Properties
    GameObject oldMan;

    private float speed = 0.015f;

    static private bool isCanGo = true;
    static private bool isTheEndOfPart = false;
    private bool isLeft = false;
    private bool isRight = false;

    static public bool IsTheEndOfPart
    {
        get
        {
            return isTheEndOfPart;
        }
        set
        {
            isTheEndOfPart = value;
        }
    }


    static public bool IsCanGo
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
    public float Speed
    {
        get
        {
            return speed;
        }
        set
        {
            speed = value;
        }
    }


    #endregion

    void Start()
    {
        oldMan = GameObject.Find("OldMan");

    }

    public void Update()
    {
        IsGoing();
        IsStaying();

        if (Input.GetKeyDown(KeyCode.F) && !IsTheEndOfPart)
        {
            IsTheOldManIsNear();
            isLeft = false;
            isRight = true;
        }

        if (IsTheEndOfPart && this.transform.position.x <= 16)
        {
            EndOfPart();
        }

    }

    void MainHeroGo(string vect)
    {
        if(vect == "Left")
        {
            GameObject.Find("MainHero").transform.Translate(-speed, 0, 0);
        }
        if(vect == "Right")
        {
            GameObject.Find("MainHero").transform.Translate(speed, 0, 0);
        }
    }

    //Is someone or something is near to main hero
    private bool IsNear(string name)
    {
        Collider2D[] coll = Physics2D.OverlapAreaAll(new Vector2(transform.position.x + 3, transform.position.y + 3), new Vector2(transform.position.x, transform.position.y));
        foreach (Collider2D collider in coll)
        {
            if (collider.gameObject.name == name)
            {
                return true;
            }
        }
        return false;
    }

    //Check if the OldMan is near
    void IsTheOldManIsNear()
    {
        if (IsNear("OldMan"))
        {
            DialogInterface dialogInterface = new DialogInterface();
            dialogInterface.ShowTheDialogWindow(true);
        }
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

    void EndOfPart()
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
