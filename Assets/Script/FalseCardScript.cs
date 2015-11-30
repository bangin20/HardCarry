using UnityEngine;
using System.Collections;

public class FalseCardScript : MonoBehaviour {
    float s;
    float cur;

	// Use this for initialization
	void Start () {
        s = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        cur = Time.time;
        if ((cur - s) >= 1.33)
            Destroy(gameObject);
	}
}
