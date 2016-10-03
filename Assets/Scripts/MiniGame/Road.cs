using UnityEngine;
public class Road : MonoBehaviour {

	public static bool isGoing = true;
	void Start () {
	
	}
	
	void Update () {
	MoveTheRoad(isGoing);
	}

void MoveTheRoad(bool isGoing)
	{
		GameObject pointMain = GameObject.Find("Point_main");
		if(isGoing == true)
		{
			GameObject.Find("Road_01").transform.position = new Vector3(0, pointMain.transform.position.y, 1);  // Ведем дорогу за ПоинтМейном
		}
	}
}
