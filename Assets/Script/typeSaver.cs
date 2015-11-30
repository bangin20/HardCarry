using UnityEngine;
using System.Collections;

public class typeSaver : MonoBehaviour {
    HERO_TYPE type;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void setType(HERO_TYPE type)
    {
        this.type = type;
    }
    public HERO_TYPE getType()
    {
        return type;
    }
}
