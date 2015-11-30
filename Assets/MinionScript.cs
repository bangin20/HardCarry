using UnityEngine;
using System.Collections;

public class MinionScript : GameCardScript
{

    int atk;
    int max_HP;
    public int getatk() { return atk; }
    public int getmax_HP() { return max_HP; }
    public void setatk(int _atk) { atk = _atk; }
    public void setmax_HP(int _max_HP) { max_HP = _max_HP; }

    // Use this for initialization

    /*void OnMouseEnter()
    {
        transform.Find("ATK_1").GetComponent<Renderer>().material = GMat[1];
        transform.Find("ATK_10").GetComponent<Renderer>().material = RMat[8];
        GameObject newCard = (GameObject)Instantiate((Object)Resources.Load("Card"), getoriginalposition()+new Vector3(-15,0,0), Quaternion.Euler(90,180,0));
    }
    void OnMouseExit()
    {
        transform.Find("ATK_1").GetComponent<Renderer>().material = WMat[0];
        transform.Find("ATK_10").GetComponent<Renderer>().material = WMat[1];
    }*/
    new public void Start()
    {
        setCardxoff(this.transform.position.x);
        setCardyoff(this.transform.position.y);
        setCardzoff(this.transform.position.z);
        for (int i = 0; i < 10; i++)
        {
            GMat[i] = (Material)Resources.Load("G" + i);
            RMat[i] = (Material)Resources.Load("R" + i);
            WMat[i] = (Material)Resources.Load("W" + i);
        }
        if (max_HP / 10 == 0)
        {
            transform.Find("HP_1").GetComponent<Renderer>().material = WMat[max_HP];
            Color newcolor = transform.Find("HP_10").GetComponent<Renderer>().material.color;
            newcolor.a = 0;
            transform.Find("HP_10").GetComponent<Renderer>().material.color = newcolor;
            transform.Find("HP_1").transform.localPosition = new Vector3(0.325f, -0.369f, -0.14f);
        }
        else
        {
            Color newcolor = transform.Find("HP_10").GetComponent<Renderer>().material.color;
            newcolor.a = 1;
            transform.Find("HP_10").GetComponent<Renderer>().material.color = newcolor;
            transform.Find("HP_10").GetComponent<Renderer>().material = WMat[max_HP / 10];
            transform.Find("HP_1").GetComponent<Renderer>().material = WMat[max_HP % 10];
            transform.Find("HP_1").transform.position = new Vector3(0.350f, -0.369f, -0.14f);
        }
        if (atk / 10 == 0)
        {
            transform.Find("ATK_1").GetComponent<Renderer>().material = WMat[atk];
            Color newcolor = transform.Find("ATK_10").GetComponent<Renderer>().material.color;
            newcolor.a = 0;
            transform.Find("ATK_10").GetComponent<Renderer>().material.color = newcolor;
            transform.Find("ATK_1").transform.localPosition = new Vector3(-0.285f, -0.362f, -0.14f);
        }
        else
        {
            Color newcolor = transform.Find("ATK_10").GetComponent<Renderer>().material.color;
            newcolor.a = 1;
            transform.Find("ATK_10").GetComponent<Renderer>().material.color = newcolor;
            transform.Find("ATK_10").GetComponent<Renderer>().material = WMat[atk / 10];
            transform.Find("ATK_1").GetComponent<Renderer>().material = WMat[atk % 10];
            transform.Find("ATK_1").transform.position = new Vector3(-0.255f, -0.362f, -0.14f);
        }
        transform.Find("Cost").GetComponent<Renderer>().material = WMat[getcost()];
    }
    void OnMouseUp()
    {
        setismouseon(false);
        int count = GameObject.FindWithTag("MainCamera").GetComponent<Player>().getMyMinionCount();
        if (count < 7)
        {
            if (Input.mousePosition.x > 45 && Input.mousePosition.x < 960 && Input.mousePosition.y > 130 && Input.mousePosition.y < 400)
            {
                Vector3 minionposition;
                switch (count)
                {
                    case 0:
                        minionposition = new Vector3(-(502.5f - 512) / 10, 1, 8.4f);
                        GameObject.FindWithTag("MainCamera").GetComponent<Player>().setMyMinionCount(++count);
                        break;
                    case 1:
                        GameObject.FindWithTag("MainCamera").GetComponent<Player>().getMyMinions(0).transform.position = new Vector3(-(442.5f - 512) / 10, 1, 8.4f);
                        minionposition = new Vector3(-(562.5f - 512) / 10, 1, 8.4f);
                        GameObject.FindWithTag("MainCamera").GetComponent<Player>().setMyMinionCount(++count);
                        break;
                    case 2:
                        GameObject.FindWithTag("MainCamera").GetComponent<Player>().getMyMinions(0).transform.position = new Vector3(-(382.5f - 512) / 10, 1, 8.4f);
                        GameObject.FindWithTag("MainCamera").GetComponent<Player>().getMyMinions(1).transform.position = new Vector3(-(502.5f - 512) / 10, 1, 8.4f);
                        minionposition = new Vector3(-(622.5f - 512) / 10, 1, 8.4f);
                        GameObject.FindWithTag("MainCamera").GetComponent<Player>().setMyMinionCount(++count);
                        break;
                    case 3:
                        GameObject.FindWithTag("MainCamera").GetComponent<Player>().getMyMinions(0).transform.position = new Vector3(-(322.5f - 512) / 10, 1, 8.4f);
                        GameObject.FindWithTag("MainCamera").GetComponent<Player>().getMyMinions(1).transform.position = new Vector3(-(442.5f - 512) / 10, 1, 8.4f);
                        GameObject.FindWithTag("MainCamera").GetComponent<Player>().getMyMinions(2).transform.position = new Vector3(-(562.5f - 512) / 10, 1, 8.4f);
                        minionposition = new Vector3(-(682.5f - 512) / 10, 1, 8.4f);
                        GameObject.FindWithTag("MainCamera").GetComponent<Player>().setMyMinionCount(++count);
                        break;
                    case 4:
                        GameObject.FindWithTag("MainCamera").GetComponent<Player>().getMyMinions(0).transform.position = new Vector3(-(262.5f - 512) / 10, 1, 8.4f);
                        GameObject.FindWithTag("MainCamera").GetComponent<Player>().getMyMinions(1).transform.position = new Vector3(-(382.5f - 512) / 10, 1, 8.4f);
                        GameObject.FindWithTag("MainCamera").GetComponent<Player>().getMyMinions(2).transform.position = new Vector3(-(502.5f - 512) / 10, 1, 8.4f);
                        GameObject.FindWithTag("MainCamera").GetComponent<Player>().getMyMinions(3).transform.position = new Vector3(-(622.5f - 512) / 10, 1, 8.4f);
                        minionposition = new Vector3(-(742.5f - 512) / 10, 1, 8.4f);
                        GameObject.FindWithTag("MainCamera").GetComponent<Player>().setMyMinionCount(++count);
                        break;
                    case 5:
                        GameObject.FindWithTag("MainCamera").GetComponent<Player>().getMyMinions(0).transform.position = new Vector3(-(202.5f - 512) / 10, 1, 8.4f);
                        GameObject.FindWithTag("MainCamera").GetComponent<Player>().getMyMinions(1).transform.position = new Vector3(-(322.5f - 512) / 10, 1, 8.4f);
                        GameObject.FindWithTag("MainCamera").GetComponent<Player>().getMyMinions(2).transform.position = new Vector3(-(442.5f - 512) / 10, 1, 8.4f);
                        GameObject.FindWithTag("MainCamera").GetComponent<Player>().getMyMinions(3).transform.position = new Vector3(-(562.5f - 512) / 10, 1, 8.4f);
                        GameObject.FindWithTag("MainCamera").GetComponent<Player>().getMyMinions(4).transform.position = new Vector3(-(682.5f - 512) / 10, 1, 8.4f);
                        minionposition = new Vector3(-(802.5f - 512) / 10, 1, 8.4f);
                        GameObject.FindWithTag("MainCamera").GetComponent<Player>().setMyMinionCount(++count);
                        break;
                    case 6:
                        GameObject.FindWithTag("MainCamera").GetComponent<Player>().getMyMinions(0).transform.position = new Vector3(-(142.5f - 512) / 10, 1, 8.4f);
                        GameObject.FindWithTag("MainCamera").GetComponent<Player>().getMyMinions(1).transform.position = new Vector3(-(262.5f - 512) / 10, 1, 8.4f);
                        GameObject.FindWithTag("MainCamera").GetComponent<Player>().getMyMinions(2).transform.position = new Vector3(-(382.5f - 512) / 10, 1, 8.4f);
                        GameObject.FindWithTag("MainCamera").GetComponent<Player>().getMyMinions(3).transform.position = new Vector3(-(502.5f - 512) / 10, 1, 8.4f);
                        GameObject.FindWithTag("MainCamera").GetComponent<Player>().getMyMinions(4).transform.position = new Vector3(-(622.5f - 512) / 10, 1, 8.4f);
                        GameObject.FindWithTag("MainCamera").GetComponent<Player>().getMyMinions(5).transform.position = new Vector3(-(742.5f - 512) / 10, 1, 8.4f);
                        minionposition = new Vector3(-(862.5f - 512) / 10, 1, 8.4f);
                        GameObject.FindWithTag("MainCamera").GetComponent<Player>().setMyMinionCount(++count);
                        break;
                    default:
                        minionposition = new Vector3(-(162.5f - 512) / 10, 1, 8.4f);
                        break;
                }
                GameObject newminion = (GameObject)Instantiate(Resources.Load("Minion"), minionposition, Quaternion.Euler(90, 180, 0));
                newminion.GetComponent<Minion>().setatk(atk);
                newminion.GetComponent<Minion>().setMaxHP(max_HP);
                newminion.GetComponent<Minion>().setHP(max_HP);
                newminion.GetComponent<Minion>().setifmy(true);
                newminion.GetComponent<Minion>().setmax_atk(atk);
                GameObject.FindWithTag("MainCamera").GetComponent<Player>().setMyMinions(count - 1, newminion);
                gameObject.GetComponent<NetworkView>().RPC("setOpCard", RPCMode.Others, atk, atk, max_HP, max_HP, false);
            }
        }
        transform.position = getoriginalposition();
    }

    [RPC]
    void setOpCard(int atk, int max_atk, int max_HP, int HP, bool _ifmy)
    {
        GameObject newminion = (GameObject)Instantiate(Resources.Load("Minion"), new Vector3(0.95f, 1, -11.5f), Quaternion.Euler(90, 180, 0));
        newminion.GetComponent<Minion>().setatk(atk);
        newminion.GetComponent<Minion>().setMaxHP(max_HP);
        newminion.GetComponent<Minion>().setHP(max_HP);
        newminion.GetComponent<Minion>().setifmy(true);
        newminion.GetComponent<Minion>().setmax_atk(atk);
        GameObject.FindWithTag("MainCamera").GetComponent<Player>().setOpMinionCount(GameObject.FindWithTag("MainCamera").GetComponent<Player>().getOpMinionCount() + 1);
        GameObject.FindWithTag("MainCamera").GetComponent<Player>().setOpMinions(GameObject.FindWithTag("MainCamera").GetComponent<Player>().getOpMinionCount() - 1, newminion);
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
        newdamageani.gameObject.transform.Find("damagenum").GetComponent<Renderer>().material = (Material)Resources.Load("W" + dfdingminion.GetComponent<Minion>().getatk());
        atkingminion.GetComponent<Minion>().updatecard();

        dfdingminion.GetComponent<Minion>().Damage(atkingminion.GetComponent<Minion>().getatk());
        Vector3 myposition = dfdingminion.transform.localPosition;
        GameObject newdefendani = (GameObject)Instantiate(Resources.Load("Damage"), myposition + new Vector3(0, 0.2f, 0), Quaternion.Euler(90, 180, 0));
        newdefendani.gameObject.transform.Find("damagenum").GetComponent<Renderer>().material = (Material)Resources.Load("W" + atkingminion.GetComponent<Minion>().getatk());
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

}