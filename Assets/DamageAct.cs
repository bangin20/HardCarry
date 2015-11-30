using UnityEngine;
using System.Collections;

public class DamageAct : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(gameObject.GetComponent<Animation>().IsPlaying("DamAni")== false)
        {
            Destroy(gameObject);
        }
	}
}
