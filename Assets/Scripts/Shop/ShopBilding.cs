#define Debug
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ShopBilding : MonoBehaviour
{
    private int counter = 0;

    //private string currentScene = "greetings"


    private int Counter
    {
        get { return counter; }
        set { counter = value; }
    }


    private ArrayList selected = new ArrayList();

    private const int SwordCost = 5;
    private const int SwordDamage = 2;
    private const int ShieldCost = 4;
    private const int ShieldArmor = 1;

    private static GameObject dialogText;


    void Start()
    {
        selected.Add(true);
        //selected.Add(false);

        dialogText = GameObject.Find("Canvas/Text");    //sync
    }

    void Update()
    {
        CheckArrows();

        if (Input.GetKeyDown(KeyCode.F))
        {
            Counter++;
            ChangeTheText(true , false);
            Debug.Log(Counter);
        }
#if Debug
        if (Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log("Counter: " + Counter);
            Debug.Log("Lengh of array: " + selected.Count);
        }
#endif
    }

    void SetTheMarkInArray(ArrayList list, int number)
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (i == number)
            {
                list[i] = true;
            }
            else
            {
                list[i] = false;
            }
        }
    }

    //Possible marks
    void SetSizeOfMarksInArray(ArrayList list, int size)
    {
        //adding the elements to array
        for (int i = 0; i < size; i++)
        {
            //if it needs, adding more marks
            if (size > list.Count)
            {
                list.Add(false);
            }


            //save all old marks
            if (GetFirstTrueOfArray(list) == i)
            {
                list[i] = true;
            }
            else
            {
                list[i] = false;
            }

            

            //Removing useless elements of array
            
            if (list.Count >= size)
            {
                int sizeOfArray = list.Count - 1;
                //list.Remove(sizeOfArray);
                list.Remove(3);
            }
        }
    }

    void CheckArrows()
    {

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            int number = GetFirstTrueOfArray(selected);
            //trying to change the mark to the next position (+1)
            if (selected.Count - 1 > number && number >= 0)
            {
                SetTheMarkInArray(selected, ++number);
                //sync
                ChangeTheText(false, true);
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            int number = GetFirstTrueOfArray(selected);
            //trying to change the mark to the next position (+1)
            if (number > 0)
            {
                SetTheMarkInArray(selected, --number);
                //sync
                ChangeTheText(false , true);
            }

        }
    }

    public int GetFirstTrueOfArray(ArrayList array)
    {
        for (int i = 0; i < array.Count; i++)
        {
            if ((bool)array[i] == true)
            {
                return i;
            }
        }
        return -1;
    }
    


    void ChangeTheText(bool isPressedF , bool isPressedArrow)
    {
        switch (Counter)
        {
            case 1:
                //if (isPressedF) Counter++;
                
                Counter_1(isPressedF, isPressedArrow);

                break;

            case 2:
                //if (isPressedF) Counter++;
                Counter_2(isPressedF, isPressedArrow);
                break;

            case 3:
                if (!BuyItems(isPressedF, isPressedArrow))
                {
                    Counter-= 2;
                }

                //BuyItems(isPressedF, isPressedArrow);
                break;

            case 4:
                Counter_4();
                break;
        }
    }

    void Counter_1(bool isPressedF, bool isPressedArrow)
    {
        string input = null;
        SetSizeOfMarksInArray(selected, 2);

        input = "Do you want to buy something?\n";
        if ((bool)selected[0])
            input += ">";

        input += "      Yes\n";

        if ((bool)selected[1])
            input += ">";

        input += "      No\n";

        Sync(input);
    }

    void Counter_2(bool isPressedF, bool isPressedArrow)
    {
        if (isPressedF && CheckExit(1))
        {
            ChangeTheLvl("Street_0");
        }
        else
        {
            string input = null;
            SetSizeOfMarksInArray(selected, 3);

            if ((bool)selected[0])
                input += ">";

            input += "      Sword(+2 dmg)\n";

            if ((bool)selected[1])
                input += ">";

            input += "      Shield(+1 arrmor)\n";
            if ((bool)selected[2])
                input += ">";
            input += "      Exit\n";

            Sync(input);
        }
    }

    bool BuyItems(bool isPressedF, bool isPressedArrow)
    {
        if (isPressedF && CheckExit(2))
        {
            ChangeTheLvl("Street_0");
            return true;
        }
        else
        {
            if ((bool)selected[0] && MainHero.Gold >= SwordCost) //sword
            {
                MainHero.Gold -= SwordCost;
                MainHero.Damage += SwordDamage;
                TopUI.SyncTopUi();

                GoToScene(1);
                SetTheMarkInArray(selected, 0);
                return true;
            }
            else if (MainHero.Gold < SwordCost && isPressedF)
            {
                NotEnoughGold(SwordCost);
                return false;
            }

            if ((bool)selected[1] && MainHero.Gold >= ShieldCost) //shiled
            {
                MainHero.Gold -= ShieldCost;
                MainHero.Armor += ShieldArmor;
                TopUI.SyncTopUi();

                GoToScene(1);
                SetTheMarkInArray(selected, 0);
                return true;
            }
            else if (MainHero.Gold < ShieldCost)
            {
                NotEnoughGold(ShieldCost);
                return false;
            }
        }
        return true;
    }

    void Counter_4()
    {
        GoToScene(1);
        SetTheMarkInArray(selected, 0);
        ChangeTheText(false, false);
    }

    void GoToScene(int numberOfScene)
    {
        Counter = numberOfScene;
        ChangeTheText(false, false);
    }

    bool CheckExit(int numberOfExitButton)
    {
        if ((bool)selected[numberOfExitButton])
        {
            return true;
        }
        return false;
    }

    void ChangeTheLvl(string nameOfLvl)
    {
        Application.LoadLevel(nameOfLvl);
    }

    void NotEnoughGold(int itemCost)
    {
        SetTheMarkInArray(selected, 0);
        string input = null;

        input = "Not enough gold! You have: " + MainHero.Gold + " You should to have: " + itemCost;
        Sync(input);
    }

    void Sync(string input)
    {
        dialogText.GetComponent<Text>().text = input;
    }


}
