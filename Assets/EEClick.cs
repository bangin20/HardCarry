using UnityEngine;
using System.Collections;

public class EEClick : MonoBehaviour {

    void OnMouseDown()
    {
        transform.Translate(0, -2f, 0);
        GameObject.Find("CiTE character").SendMessage("HideBack");
        GameObject.Find("PHY character").SendMessage("HideBack");
        GameObject.Find("CSE character").SendMessage("HideBack");
        GameObject.Find("HeroValue").GetComponent<typeSaver>().setType(HERO_TYPE.EE);
    }
    void OnMouseUp()
    {
        transform.Translate(0, +2f, 0);
        GameObject.Find("EE character").SendMessage("ComingOut");
    }
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
