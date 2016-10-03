using UnityEngine;
using System.Collections;

public class UI : MonoBehaviour
{

    public Texture2D texture;
    public bool GameMenu = true;


    void OnGUI()
    {
        //GUI.DrawTexture(new Rect(X, Y, Screen.width / 5, Screen.height / 5), texture);
        GUI.skin.button.fontSize = 60;

        if (GameMenu == true)
        {
            GUI.BeginGroup(new Rect(Screen.width / 2 - 170, 0, Screen.width, Screen.height));

            if (GUI.Button(new Rect(10, 40, 400, 100), "Start the game"))
            {
                 Application.LoadLevel("second");
                 Debug.Log("Start the game");
            }


            
                GUI.Label(new Rect(10, 260, 400, 100), "HERE");

            if (GUI.Button(new Rect(10, 160, 400, 100), "Exit"))
            {
                Debug.Log("Exit");
                
                Application.Quit();
            }

            GUI.EndGroup();
        }


        

    }
}
