using UnityEngine;
using System.Collections;

public enum HERO_TYPE { CSE, CITE, PHYS, EE };

public class MyHeroScript : MonoBehaviour {
    public Hero MyHero;

    public class Hero
    {
       HERO_TYPE type;
       int HP;
       int atk;
       int MaxHP;

       public int getHP() { return HP; }
       public void setHP(int hp) { HP = hp; }
       public int getAtk() { return atk; }
       public void setAtk(int atk) { this.atk = atk; }
       public int getMaxHP() { return MaxHP; }
       public void setMaxHP(int hp) { MaxHP = hp; }
       public HERO_TYPE getType() { return type; }
       public void setType(HERO_TYPE a) { type = a; }
    }

	// Use this for initialization
	void Awake () {
        MyHero = new Hero();
        MyHero.setHP(30);
        MyHero.setMaxHP(30);
        MyHero.setAtk(0);
        MyHero.setType(GameObject.Find("HeroValue").GetComponent<typeSaver>().getType());
        Material mat;

        if (MyHero.getType() == HERO_TYPE.CSE)
        {
            mat = (Material)Resources.Load(MyHero.getType() + "HeroMaterial");
            gameObject.GetComponent<Renderer>().material = mat;
        }
        else if (MyHero.getType() == HERO_TYPE.CITE)
        {
            mat = (Material)Resources.Load(MyHero.getType() + "HeroMaterial");
            gameObject.GetComponent<Renderer>().material = mat;
        }
        else if (MyHero.getType() == HERO_TYPE.EE)
        {
            mat = (Material)Resources.Load(MyHero.getType() + "HeroMaterial");
            gameObject.GetComponent<Renderer>().material = mat;
        }
        else
        {
            mat = (Material)Resources.Load(MyHero.getType() + "HeroMaterial");
            gameObject.GetComponent<Renderer>().material = mat;
        }
	}

    public void ChangePicture()
    {
        Material mat;
        if (MyHero.getType() == HERO_TYPE.CSE)
        {
            mat = (Material)Resources.Load(MyHero.getType() + "HeroMaterial");
            gameObject.GetComponent<Renderer>().material = mat;
        }
        else if (MyHero.getType() == HERO_TYPE.CITE)
        {
            mat = (Material)Resources.Load(MyHero.getType() + "HeroMaterial");
            gameObject.GetComponent<Renderer>().material = mat;
        }
        else if (MyHero.getType() == HERO_TYPE.EE)
        {
            mat = (Material)Resources.Load(MyHero.getType() + "HeroMaterial");
            gameObject.GetComponent<Renderer>().material = mat;
        }
        else
        {
            mat = (Material)Resources.Load(MyHero.getType() + "HeroMaterial");
            gameObject.GetComponent<Renderer>().material = mat;
        }
    }
}
