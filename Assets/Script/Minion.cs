using UnityEngine;
using System.Collections;

public class Minion : MonoBehaviour
{
    public int atk = 2;
    public int max_atk = 2;
    public int max_HP = 5;
    public int HP = 5;
    bool MyMinion = true;

    //bool battlestart = false;
    GameObject atkingminion = null;
    bool target = false;

    public int getatk() { return atk; }
    public int getHP() { return HP; }
    public void setatk(int _atk) { atk = _atk; }
    public void setHP(int _HP) { HP = _HP; }
    public int getmax_atk() { return max_atk; }
    public void setmax_atk(int _max) { max_atk = _max; }
    public void setMaxHP(int _Max) { max_HP = _Max; }
    public bool isMyMinion() { return MyMinion; }
    public void setifmy(bool _mym) { MyMinion = _mym; }

    public bool istargetted() { return target; }

    void OnMouseEnter() { target = true; }
    void OnMouseExit() { target = false; }

    /*void OnMouseDown()
    {
        if (MyMinion == true)
        {
            battlestart = true;
        }
    }*/


    void OnMouseUp()
    {
        //Animator myanimator = gameObject.GetComponent<Animator>();
        for (int i = 0; i < GameObject.FindWithTag("MainCamera").GetComponent<Player>().getOpMinionCount(); i++)
        {
            if (GameObject.FindWithTag("MainCamera").GetComponent<Player>().getMyMinionCount() == 0) { break; }
            else
            {
                if (GameObject.FindWithTag("MainCamera").GetComponent<Player>().getOpMinions(i).GetComponent<Minion>().istargetted() == true)
                {
                    atkingminion = GameObject.FindWithTag("MainCamera").GetComponent<Player>().getOpMinions(i);
                    if (atkingminion.GetComponent<Minion>().getatk() > 0)
                    {
                        Damage(atkingminion.GetComponent<Minion>().getatk());
                        Vector3 opposition = transform.localPosition;
                        GameObject newdamageani = (GameObject)Instantiate(Resources.Load("Damage"), opposition + new Vector3(0, 0.2f, 0), Quaternion.Euler(90, 180, 0));
                        newdamageani.gameObject.transform.Find("damagenum").GetComponent<Renderer>().material = (Material)Resources.Load("W" + atkingminion.GetComponent<Minion>().getatk());
                        updatecard();
                    }
                    if (atk > 0)
                    {
                        atkingminion.GetComponent<Minion>().Damage(atk);
                        Vector3 myposition = atkingminion.transform.localPosition;
                        GameObject newdamageani = (GameObject)Instantiate(Resources.Load("Damage"), myposition + new Vector3(0, 0.2f, 0), Quaternion.Euler(90, 180, 0));
                        newdamageani.gameObject.transform.Find("damagenum").GetComponent<Renderer>().material = (Material)Resources.Load("W" + atk);
                        atkingminion.GetComponent<Minion>().updatecard();
                    }
                    int k = 0;
                    while (GameObject.FindWithTag("MainCamera").GetComponent<Player>().getMyMinions(k) != gameObject && k != 6)
                    {
                        k = k + 1;
                    }
                    gameObject.GetComponent<NetworkView>().RPC("Damage", RPCMode.Others, i, k);
                    if (atkingminion.GetComponent<Minion>().isAlive() == false)
                    {
                        //myanimator.SetTrigger("die"); 
                        gameObject.GetComponent<NetworkView>().RPC("MyDestroy", RPCMode.Others, k);
                        Destroy(atkingminion);
                        for (int j = i; j < GameObject.FindWithTag("MainCamera").GetComponent<Player>().getOpMinionCount() - 1; j++)
                        {
                            GameObject.FindWithTag("MainCamera").GetComponent<Player>().setOpMinions(j, GameObject.FindWithTag("MainCamera").GetComponent<Player>().getOpMinions(j + 1));
                        }
                        GameObject.FindWithTag("MainCamera").GetComponent<Player>().setOpMinionCount(GameObject.FindWithTag("MainCamera").GetComponent<Player>().getOpMinionCount() - 1);
                    }
                    if (isAlive() == false)
                    {
                        gameObject.GetComponent<NetworkView>().RPC("OpDestroy", RPCMode.Others, i);
                        Destroy(gameObject);
                        for (int j = k; j < GameObject.FindWithTag("MainCamera").GetComponent<Player>().getMyMinionCount() - 1; j++)
                        {
                            GameObject.FindWithTag("MainCamera").GetComponent<Player>().setMyMinions(j, GameObject.FindWithTag("MainCamera").GetComponent<Player>().getMyMinions(j + 1));
                        }
                        GameObject.FindWithTag("MainCamera").GetComponent<Player>().setMyMinionCount(GameObject.FindWithTag("MainCamera").GetComponent<Player>().getMyMinionCount() - 1);
                    }
                    break;
                }
            }
        }
    }

    [RPC]
    void Damage(int myindex, int opindex)
    {
        Debug.Log(gameObject.name);
        GameObject atkingminion = GameObject.FindWithTag("MainCamera").GetComponent<Player>().getOpMinions(opindex);
        GameObject dfdingminion = GameObject.FindWithTag("MainCamera").GetComponent<Player>().getMyMinions(myindex);

        atkingminion.GetComponent<Minion>().Damage(dfdingminion.GetComponent<Minion>().getatk());
        Vector3 opposition = atkingminion.transform.localPosition;
        GameObject newdamageani = (GameObject)Instantiate(Resources.Load("Damage"), opposition + new Vector3(0, 0.2f, 0), Quaternion.Euler(90, 180, 0));
        newdamageani.gameObject.transform.Find("damagenum").GetComponent<Renderer>().material = (Material)Resources.Load("W" + atkingminion.GetComponent<Minion>().getatk());
        atkingminion.GetComponent<Minion>().updatecard();

        dfdingminion.GetComponent<Minion>().Damage(atkingminion.GetComponent<Minion>().getatk());
        Vector3 myposition = dfdingminion.transform.localPosition;
        GameObject newdefendani = (GameObject)Instantiate(Resources.Load("Damage"), myposition + new Vector3(0, 0.2f, 0), Quaternion.Euler(90, 180, 0));
        newdefendani.gameObject.transform.Find("damagenum").GetComponent<Renderer>().material = (Material)Resources.Load("W" + dfdingminion.GetComponent<Minion>().getatk());
        dfdingminion.GetComponent<Minion>().updatecard();
    }
    [RPC]
    void MyDestroy(int myindex)
    {
        GameObject myminion = GameObject.FindWithTag("MainCamera").GetComponent<Player>().getMyMinions(myindex);
        Destroy(myminion);
        for (int i = myindex; i < GameObject.FindWithTag("MainCamera").GetComponent<Player>().getMyMinionCount() - 1; i++)
        {
            GameObject.FindWithTag("MainCamera").GetComponent<Player>().setMyMinions(i, GameObject.FindWithTag("MainCamera").GetComponent<Player>().getMyMinions(i + 1));
        }
        GameObject.FindWithTag("MainCamera").GetComponent<Player>().setMyMinionCount(GameObject.FindWithTag("MainCamera").GetComponent<Player>().getMyMinionCount() - 1);
    }
    [RPC]
    void OpDestroy(int opindex)
    {
        GameObject opminion = GameObject.FindWithTag("MainCamera").GetComponent<Player>().getOpMinions(opindex);
        Destroy(opminion);
        for (int i = opindex; i < GameObject.FindWithTag("MainCamera").GetComponent<Player>().getOpMinionCount() - 1; i++)
        {
            GameObject.FindWithTag("MainCamera").GetComponent<Player>().setOpMinions(i, GameObject.FindWithTag("MainCamera").GetComponent<Player>().getOpMinions(i + 1));
        }
        GameObject.FindWithTag("MainCamera").GetComponent<Player>().setOpMinionCount(GameObject.FindWithTag("MainCamera").GetComponent<Player>().getOpMinionCount() - 1);
    }

    // Use this for initialization
    void Start()
    {
        if (HP / 10 == 0)
        {
            transform.Find("HP_1").GetComponent<Renderer>().material = (Material)Resources.Load("W" + HP);
            Color newcolor = transform.Find("HP_10").GetComponent<Renderer>().material.color;
            newcolor.a = 0;
            transform.Find("HP_10").GetComponent<Renderer>().material.color = newcolor;
            transform.Find("HP_1").transform.localPosition = new Vector3(0.307f, 0.153f, -1);
        }
        else
        {
            Color newcolor = transform.Find("HP_10").GetComponent<Renderer>().material.color;
            newcolor.a = 1;
            transform.Find("HP_10").GetComponent<Renderer>().material.color = newcolor;
            transform.Find("HP_10").GetComponent<Renderer>().material = (Material)Resources.Load("W" + HP / 10);
            transform.Find("HP_1").GetComponent<Renderer>().material = (Material)Resources.Load("W" + HP % 10);
            transform.Find("HP_1").transform.position = new Vector3(0.367f, 0.153f, -1);
        }
        if (atk / 10 == 0)
        {
            transform.Find("ATK_1").GetComponent<Renderer>().material = (Material)Resources.Load("W" + atk);
            Color newcolor = transform.Find("ATK_10").GetComponent<Renderer>().material.color;
            newcolor.a = 0;
            transform.Find("ATK_10").GetComponent<Renderer>().material.color = newcolor;
            transform.Find("ATK_1").transform.localPosition = new Vector3(-0.204f, 0.153f, -1);
        }
        else
        {
            Color newcolor = transform.Find("ATK_10").GetComponent<Renderer>().material.color;
            newcolor.a = 1;
            transform.Find("ATK_10").GetComponent<Renderer>().material.color = newcolor;
            transform.Find("ATK_10").GetComponent<Renderer>().material = (Material)Resources.Load("W" + atk / 10);
            transform.Find("ATK_1").GetComponent<Renderer>().material = (Material)Resources.Load("W" + atk % 10);
            transform.Find("ATK_1").transform.position = new Vector3(-0.146f, 0.153f, -1);
        }
    }

    // Update is called once per frame
    public void updatecard()
    {
        if (HP > max_HP)
        {
            if (HP / 10 == 0)
            {
                transform.Find("HP_1").GetComponent<Renderer>().material = (Material)Resources.Load("G" + HP);
                Color newcolor = transform.Find("HP_10").GetComponent<Renderer>().material.color;
                newcolor.a = 0;
                transform.Find("HP_10").GetComponent<Renderer>().material.color = newcolor;
                transform.Find("HP_1").transform.localPosition = new Vector3(0.307f, 0.153f, -1);
            }
            else
            {
                Color newcolor = transform.Find("HP_10").GetComponent<Renderer>().material.color;
                newcolor.a = 1;
                transform.Find("HP_10").GetComponent<Renderer>().material.color = newcolor;
                transform.Find("HP_10").GetComponent<Renderer>().material = (Material)Resources.Load("G" + HP / 10);
                transform.Find("HP_1").GetComponent<Renderer>().material = (Material)Resources.Load("G" + HP % 10);
                transform.Find("HP_1").transform.position = new Vector3(0.367f, 0.153f, -1);
            }
        }
        else if (HP == max_HP)
        {
            if (HP / 10 == 0)
            {
                transform.Find("HP_1").GetComponent<Renderer>().material = (Material)Resources.Load("W" + HP);
                Color newcolor = transform.Find("HP_10").GetComponent<Renderer>().material.color;
                newcolor.a = 0;
                transform.Find("HP_10").GetComponent<Renderer>().material.color = newcolor;
                transform.Find("HP_1").transform.localPosition = new Vector3(0.307f, 0.153f, -1);
            }
            else
            {
                Color newcolor = transform.Find("HP_10").GetComponent<Renderer>().material.color;
                newcolor.a = 1;
                transform.Find("HP_10").GetComponent<Renderer>().material.color = newcolor;
                transform.Find("HP_10").GetComponent<Renderer>().material = (Material)Resources.Load("W" + HP / 10);
                transform.Find("HP_1").GetComponent<Renderer>().material = (Material)Resources.Load("W" + HP % 10);
                transform.Find("HP_1").transform.position = new Vector3(0.367f, 0.153f, -1);
            }
        }
        else if (HP < max_HP)
        {
            if (HP / 10 == 0)
            {
                transform.Find("HP_1").GetComponent<Renderer>().material = (Material)Resources.Load("R" + HP);
                Color newcolor = transform.Find("HP_10").GetComponent<Renderer>().material.color;
                newcolor.a = 0;
                transform.Find("HP_10").GetComponent<Renderer>().material.color = newcolor;
                transform.Find("HP_1").transform.localPosition = new Vector3(0.307f, 0.153f, -1);
            }
            else
            {
                Color newcolor = transform.Find("HP_10").GetComponent<Renderer>().material.color;
                newcolor.a = 1;
                transform.Find("HP_10").GetComponent<Renderer>().material.color = newcolor;
                transform.Find("HP_10").GetComponent<Renderer>().material = (Material)Resources.Load("R" + HP / 10);
                transform.Find("HP_1").GetComponent<Renderer>().material = (Material)Resources.Load("R" + HP % 10);
                transform.Find("HP_1").transform.position = new Vector3(0.367f, 0.153f, -1);
            }
        }
        if (atk > max_atk)
        {
            if (atk / 10 == 0)
            {
                transform.Find("ATK_1").GetComponent<Renderer>().material = (Material)Resources.Load("G" + atk);
                Color newcolor = transform.Find("ATK_10").GetComponent<Renderer>().material.color;
                newcolor.a = 0;
                transform.Find("ATK_10").GetComponent<Renderer>().material.color = newcolor;
                transform.Find("ATK_1").transform.localPosition = new Vector3(-0.204f, 0.153f, -1);
            }
            else
            {
                Color newcolor = transform.Find("ATK_10").GetComponent<Renderer>().material.color;
                newcolor.a = 1;
                transform.Find("ATK_10").GetComponent<Renderer>().material.color = newcolor;
                transform.Find("ATK_10").GetComponent<Renderer>().material = (Material)Resources.Load("G" + atk / 10);
                transform.Find("ATK_1").GetComponent<Renderer>().material = (Material)Resources.Load("G" + atk % 10);
                transform.Find("ATK_1").transform.position = new Vector3(-0.146f, 0.153f, -1);
            }
        }
        else if (atk == max_atk)
        {
            if (atk / 10 == 0)
            {
                transform.Find("ATK_1").GetComponent<Renderer>().material = (Material)Resources.Load("W" + atk);
                Color newcolor = transform.Find("ATK_10").GetComponent<Renderer>().material.color;
                newcolor.a = 0;
                transform.Find("ATK_10").GetComponent<Renderer>().material.color = newcolor;
                transform.Find("ATK_1").transform.localPosition = new Vector3(-0.204f, 0.153f, -1);
            }
            else
            {
                Color newcolor = transform.Find("ATK_10").GetComponent<Renderer>().material.color;
                newcolor.a = 1;
                transform.Find("ATK_10").GetComponent<Renderer>().material.color = newcolor;
                transform.Find("ATK_10").GetComponent<Renderer>().material = (Material)Resources.Load("W" + atk / 10);
                transform.Find("ATK_1").GetComponent<Renderer>().material = (Material)Resources.Load("W" + atk % 10);
                transform.Find("ATK_1").transform.position = new Vector3(-0.146f, 0.153f, -1);
            }
        }
        else if (atk < max_atk)
        {
            if (atk / 10 == 0)
            {
                transform.Find("ATK_1").GetComponent<Renderer>().material = (Material)Resources.Load("R" + atk);
                Color newcolor = transform.Find("ATK_10").GetComponent<Renderer>().material.color;
                newcolor.a = 0;
                transform.Find("ATK_10").GetComponent<Renderer>().material.color = newcolor;
                transform.Find("ATK_1").transform.localPosition = new Vector3(-0.204f, 0.153f, -1);
            }
            else
            {
                Color newcolor = transform.Find("ATK_10").GetComponent<Renderer>().material.color;
                newcolor.a = 1;
                transform.Find("ATK_10").GetComponent<Renderer>().material.color = newcolor;
                transform.Find("ATK_10").GetComponent<Renderer>().material = (Material)Resources.Load("R" + atk / 10);
                transform.Find("ATK_1").GetComponent<Renderer>().material = (Material)Resources.Load("R" + atk % 10);
                transform.Find("ATK_1").transform.position = new Vector3(-0.146f, 0.153f, -1);
            }
        }
    }

    void Update()
    {
        updatecard();
    }
    public bool isAlive()
    {
        return HP > 0;
    }
    public void Damage(int damage)
    {
        HP -= damage;
    }
}