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
    }

    void Update()
    {
        mainHero.Update();

        if (MainHero.IsPressedF())
        {
            MainHero.IsLeft = true;
            IsTableIsNear();
            IsBuildingIsNear();
        }
    }

    void IsBuildingIsNear()
    {
        if (mainHero.IsNear("BLD"))
        {
            BuildingIsNear();
        }
    }

    void BuildingIsNear()
    {
        Application.LoadLevel("shop");
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
        DialogInterface.ShowTheDialogWindow(false , "TableStreet_0");
    }
}
