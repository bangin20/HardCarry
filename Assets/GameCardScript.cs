using UnityEngine;
using System.Collections;

public class GameCardScript : CardScript {
    
    // Use this for initialization
    new public void Start () {

        setCardxoff(this.transform.position.x);
        setCardyoff(this.transform.position.y);
        setCardzoff(this.transform.position.z);
        for (int i = 0; i < 10; i++)
        {
            GMat[i] = (Material)Resources.Load("G" + i);
            RMat[i] = (Material)Resources.Load("R" + i);
            WMat[i] = (Material)Resources.Load("W" + i);
        }
	}

	void OnMouseDown()
    {
        setismouseon(true);
        Vector3 pos = transform.position;
        pos.y = 10;
        transform.position = pos;
    }
    void OnMouseUp()
    {
        setismouseon(false);
        transform.position = new Vector3(getCardxoff(), 1, getCardyoff());
    }
	// Update is called once per frame
	new public void Update () {
        if (getismouseon() == true)
        {
            Debug.Log(Input.mousePosition.x + "," + Input.mousePosition.y);
            transform.position = new Vector3(-((Input.mousePosition.x-512)/10), 10, -((Input.mousePosition.y-384)/10));
        }
	}

    /*public GUISkin CardText;
    void OnGUI()
    {
        GUI.skin = CardText;
        if (GUI.TextArea(new Rect(this.transform.position.x, this.transform.position.y,100,100), "Hi")=="Hi")
        {
            transform.position = new Vector3(0, 25, 0);
        }
    }*/
}
