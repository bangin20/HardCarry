using UnityEngine;
using System.Collections;

public class CardScript : MonoBehaviour {

    string cardname;
    int cost;
    HERO_TYPE cardjob;
    float cardxoff;
    float cardyoff;
    float cardzoff;
    bool ismouseon = false;
    protected Material[] GMat = new Material[10];
    protected Material[] RMat = new Material[10];
    protected Material[] WMat = new Material[10];
    public Vector3 getoriginalposition()
    {
        return new Vector3(cardxoff, cardyoff, cardzoff);
    }
    public void setCardxoff(float x) { cardxoff = x; }
    public void setCardyoff(float y) { cardyoff = y; }
    public void setCardzoff(float z) { cardzoff = z; }
    public float getCardxoff() { return cardxoff; }
    public float getCardyoff() { return cardyoff; }
    public float getCardzoff() { return cardzoff; }
    public void setname(string _name) { cardname = _name; }
    public void setcardjob(HERO_TYPE _H) { cardjob = _H; }
    public void setcost(int _cost) { cost = _cost; }
    public int getcost() { return cost; }
    public void setismouseon(bool _b) { ismouseon = _b; }
    public bool getismouseon() { return ismouseon; }




    // Use this for initialization
    public void Start () {
	
	}
	
	// Update is called once per frame
	public void Update () {
	
	}
}
