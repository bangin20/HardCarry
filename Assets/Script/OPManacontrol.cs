using UnityEngine;
using System.Collections;

public class OPManacontrol : MonoBehaviour
{
    /*
    public int mana = 0;

    private int turn = 1;
    private GameObject dec;
    private GameObject one;
    private Color col;

    void Start()
    {
        dec = (GameObject)Instantiate(Resources.Load("Decimal_pos"), new Vector3(-39.5f, 3, -29.85f), Quaternion.identity);
        dec.transform.Rotate(new Vector3(90, 180, 0));
        one = (GameObject)Instantiate(Resources.Load("One_pos"), new Vector3(-40.5f, 3, -29.85f), Quaternion.identity);
        one.transform.Rotate(new Vector3(90, 180, 0));
        dec.GetComponent<Renderer>().material = (Material)Resources.Load("W0");
        one.GetComponent<Renderer>().material = (Material)Instantiate(Resources.Load("W1"));
        turn = 1;
    }

    void Update()
    {
        
        

        if ((turn / 10) == 0)
        {
            col = dec.GetComponent<Renderer>().material.color;
            col.a = 0;
            dec.GetComponent<Renderer>().material.color = col;
        }
        else
        {
            col = dec.GetComponent<Renderer>().material.color;
            col.a = 1;
            dec.GetComponent<Renderer>().material.color = col;
        }
        
    }

    public void SetManaturn(int t)
    {
        turn = t;
        dec.GetComponent<Renderer>().material = (Material)Resources.Load("W" + (turn / 10));
        one.GetComponent<Renderer>().material = (Material)Instantiate(Resources.Load("W" + (turn % 10)));
    }
     */
}