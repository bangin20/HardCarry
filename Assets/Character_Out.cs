using UnityEngine;
using System.Collections;

public class Character_Out : MonoBehaviour {
    void HideBack()
    {
        transform.position = new Vector3(this.gameObject.transform.position.x, -10, this.gameObject.transform.position.z);
    }
    void ComingOut()
    {
        transform.position = new Vector3(this.gameObject.transform.position.x, 10, this.gameObject.transform.position.z);
    }
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
