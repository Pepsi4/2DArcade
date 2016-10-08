using UnityEngine;
using System.Collections;

public class MainHeroStreet_0 : MonoBehaviour
{
    #region Fileds

    private MainHero mainHero;      //для наследования класса MainHero
    private DialogInterface table;  //для наследования класса DialogInterface

    #endregion
    void Start()
    {
        mainHero = GameObject.Find("MainHero").AddComponent<MainHero>();
        table = GameObject.Find("MainHero").AddComponent<DialogInterface>();
    }

    void Update()
    {
        mainHero.Update();

        if (mainHero.IsPressedF() == true)
        {
            IsTableIsNear();
            IsBuildingIsNear();
            
        }
    }

    void IsBuildingIsNear()
    {
        Debug.Log(mainHero.IsNear("BLD"));

        if (mainHero.IsNear("BLD"))
        {
            BuildingIsNear();
        }
    }

    void BuildingIsNear()
    {
        Application.LoadLevel("Street_1");
    }

    void IsTableIsNear()
    {
        if (mainHero.IsNear("Table"))
        {
            TableIsNear();
        }
    }

    void TableIsNear()
    {
        Debug.Log("table is near");
        table.ShowTheDialogWindow(false , "TableStreet0");
    }




}
