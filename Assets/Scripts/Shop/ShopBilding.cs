using UnityEngine;
using UnityEngine.UI;

public class ShopBilding : MonoBehaviour
{

    private int Counter { get; set; }
    //private bool ShouldCheck { get; set; }
    private string[] Select;
    string input;

    private static GameObject dialogText;


    void Start()
    {
        Select = new string[2];
        Select[0] = ">";    // "No"
        Select[1] = " ";    // "Yes"

        dialogText = GameObject.Find("Canvas/Text");
    }

    void Update()
    {


        if (Input.GetKeyDown(KeyCode.F))
        {
            Counter++;
            ChangeTheText();
        }

        CheckArrows();
    }

    void CheckArrows()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Select[1] = ">";    // "No"
            Select[0] = " ";    // "Yes"
            ChangeTheText();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Select[0] = ">";    // "Yes"
            Select[1] = " ";    // "No"
            ChangeTheText();
        }
    }

    void ChangeTheText()
    {
        switch (Counter)
        {
            case 1:
                Counter_1();
                break;

            case 2:
                Counter_2();
                break;

            case 3:

                break;
        }


        

        Debug.Log(Counter);

    }

    void Counter_1()
    {
        input = "Do you want to buy something?\n";
        input += Select[0];
        input += "      Yes\n";
        input += Select[1];
        input += "      No\n";

        dialogText.GetComponent<Text>().text = input;

        //ShouldCheck = true;

    }

    void Counter_2()
    {
        input += Select[0];
        input = "      Sword(+2 dmg)\n";
        input += Select[1];
        input += "      Shield(+1 arrmor)\n";

        dialogText.GetComponent<Text>().text = input;

        //ShouldCheck = true;

    }
}
