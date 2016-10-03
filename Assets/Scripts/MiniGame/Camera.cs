using UnityEngine;

public class Camera : MonoBehaviour {
    
    public GameObject gm;
    public static bool isGoing = true;
    
	void Update () {
        CameraIsGoing();
	}

    public void CameraIsGoing()
    {
        if(isGoing == true)
        {
            transform.position = new Vector3(gm.transform.position.x, gm.transform.position.y, -1);
        }
    }

    /*public void CameraStoped(bool isStoped = false)
    {
        if(isStoped == true)
        {
            transform.po
        }
    }*/
}
