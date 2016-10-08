using System;
using UnityEngine;
using UnityEngine.UI;

public class DialogInterface : MonoBehaviour
{
    #region Variables and Properties
    static public GameObject dialogImage;
    static public GameObject dialogText;
    static public GameObject dialogName;

    static int counter = 0;

    static public int Counter
    {
        get
        {
            return counter;
        }
        set
        {
            counter = value;
        }
    }

    #endregion

    void Start()
    {
        Initialization();
        HideTheDialogInterface();
    }

    private void Initialization()
    {
        dialogImage = GameObject.Find("Canvas/DialogImage");
        dialogText = GameObject.Find("Canvas/DialogText");
        dialogName = GameObject.Find("Canvas/DialogName");
    }

    private void Synsynchronization()
    {
        GameObject.Find("Canvas/DialogImage").GetComponent<Image>().sprite = dialogImage.GetComponent<Image>().sprite;
        GameObject.Find("Canvas/DialogText").GetComponent<Text>().text = dialogText.GetComponent<Text>().text;
        GameObject.Find("Canvas/DialogName").GetComponent<Text>().text = dialogName.GetComponent<Text>().text;
    }

    private void ShowTheDialogInterface()
    {
        dialogImage.GetComponent<Image>().enabled = true;
        dialogName.GetComponent<Text>().enabled = true;
        dialogText.GetComponent<Text>().enabled = true;

        //Main hero sholudn't go anywhere from the object
        MainHero.IsCanGo = false;
    }

    private void HideTheDialogInterface()
    {
        //Hide the dialog image
        dialogImage.GetComponent<Image>().enabled = false;
        //Hide the dialog name
        dialogName.GetComponent<Text>().enabled = false;
        //Hide the dialog text
        dialogText.GetComponent<Text>().enabled = false;

        //Main hero again can go anywhere 
        MainHero.IsCanGo = true;
    }

    void Update()
    {
    }

    public void ShowTheDialogWindow(bool isTheEndOfPart, string textName)
    {
        Counter++;
        ShowTheDialogInterface();
        TextAsset txt = Resources.Load<TextAsset>("Texts/" + textName);

        //Here can be an excention "out of range"
        try
        {
            string[] text = txt.text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

            //Split the text from .txt file to dialogName and dialogText
            //It is spliting by string "||"
            string dialogText = text[Counter].Split(new string[] { "||" }, StringSplitOptions.None)[0];
            string dialogName = text[Counter].Split(new string[] { "||" }, StringSplitOptions.None)[1];
            
            SetDialogInterface(dialogName, dialogText);
        }
        catch
        {
            HideTheDialogInterface();
            if(isTheEndOfPart)
            {
                MainHero.IsTheEndOfPart = true;
            }
            return;
        }


    }

    public void SetDialogInterface(string name, string text)
    {
        dialogText.GetComponent<Text>().text = text;
        dialogName.GetComponent<Text>().text = name;
        Synsynchronization();
    }



}
