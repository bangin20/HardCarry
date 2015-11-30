using UnityEngine;
using System.Collections;

public class HPLabel : MonoBehaviour {
    GameObject HPtext_dec;
    GameObject HPtext_one;
    private int HP;

    void Start()
    {
        HP = 30;
        HPtext_dec = (GameObject)Instantiate(Resources.Load("Number/Decimal_pos"),new Vector3(-2.95f,2,28.5f), Quaternion.identity);
        HPtext_one = (GameObject)Instantiate(Resources.Load("Number/One_pos"), new Vector3(-4.1f, 2, 28.5f), Quaternion.identity);
        HPtext_dec.transform.Rotate(new Vector3(90, 180, 0));
        HPtext_one.transform.Rotate(new Vector3(90, 180, 0));
    }

    void Damage()
    {
    }

    [RPC]
    void PlayerDamage(int k)
    {
    }
}