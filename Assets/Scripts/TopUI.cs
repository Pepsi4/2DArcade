using UnityEngine;
using UnityEngine.UI;

public class TopUI : MonoBehaviour {

    void Awake()
    {
        if (GameObject.Find("Canvas"))
        {
            DontDestroyOnLoad(this.gameObject);

            if (FindObjectsOfType(GetType()).Length > 1)
            {
                Destroy(gameObject);
            }
        }

        
    }

    static public void SyncTopUi()
    {
        GameObject.Find("Canvas/ArmorUISystem/Count").GetComponent<Text>().text = MainHero.Armor.ToString();
        GameObject.Find("Canvas/WeaponUISystem/Count").GetComponent<Text>().text = MainHero.Damage.ToString();
        GameObject.Find("Canvas/MoneyUISystem/Count").GetComponent<Text>().text = MainHero.Gold.ToString();
    }
}
