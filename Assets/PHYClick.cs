using UnityEngine;
using System.Collections;

public class PHYClick : MonoBehaviour {

    void OnMouseDown()
    {
        transform.Translate(0, -2f, 0);
        GameObject.Find("CiTE character").SendMessage("HideBack");
        GameObject.Find("EE character").SendMessage("HideBack");
        GameObject.Find("CSE character").SendMessage("HideBack");
        GameObject.Find("HeroValue").GetComponent<typeSaver>().setType(HERO_TYPE.PHYS);
    }
    void OnMouseUp()
    {
        transform.Translate(0, +2f, 0);
        GameObject.Find("PHY character").SendMessage("ComingOut");
    }
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
