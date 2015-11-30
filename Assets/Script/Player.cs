using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    private int MyMinionCount = 0;
    private int OpMinionCount = 0;
    public void setMyMinionCount(int _count) { MyMinionCount = _count; }
    public int getMyMinionCount() { return MyMinionCount; }
    public void setOpMinionCount(int _count) { OpMinionCount = _count; }
    public int getOpMinionCount() { return OpMinionCount; }

    GameObject[] MyHand = new GameObject[10];
    GameObject[] OpHand = new GameObject[10];
    public void setMyHand(int _index, GameObject _Game) { MyHand[_index] = _Game; }
    public GameObject getMyHand(int _index) { return MyHand[_index]; }
    public void setOpHand(int _index, GameObject _Game) { OpHand[_index] = _Game; }
    public GameObject getOpHand(int _index) { return OpHand[_index]; }

    private int MyHandCount = 0;
    private int OpHandCount = 0;
    public void setMyHandCount(int _count) { MyHandCount = _count; }
    public int getMyHandCount() { return MyHandCount; }
    public void setOpHandCount(int _count) { OpHandCount = _count; }
    public int getOpHandCount() { return OpHandCount; }

    GameObject[] MyMinions = new GameObject[7];
    GameObject[] OpMinions = new GameObject[7];
    public GameObject getMyMinions(int i) { return MyMinions[i]; }
    public GameObject getOpMinions(int i) { return OpMinions[i]; }
    public void setMyMinions(int i, GameObject _minion) { MyMinions[i] = _minion; }
    public void setOpMinions(int i, GameObject _minion) { OpMinions[i] = _minion; }

    GameObject[] MyDeck = new GameObject[30];
    GameObject[] OpDeck = new GameObject[30];


    // Use this for initialization
    void Start()
    {
        /*for(int i = 0; i < 30; i++)
        {
            GameObject newcard = (GameObject)Instantiate(Resources.Load("MinionCard"), new Vector3(0, -1, 20f), Quaternion.Euler(90, 180, 0));
            newcard.GetComponent<MinionScript>().setcardjob(HERO_TYPE.CSE);
            newcard.GetComponent<MinionScript>().setcost(i + 4);
            newcard.GetComponent<MinionScript>().setname("newCard" + i);
            newcard.GetComponent<MinionScript>().setatk(i + 4);
            newcard.GetComponent<MinionScript>().setmax_HP(i + 4);
            MyDeck[i] = newcard;
        }*/
        /*
        for (int i = 0; i < 4; i++)
        {
            GameObject icard = (GameObject)Instantiate(Resources.Load("MinionCard"), new Vector3(-30 + 15 * i, 1 + i, 31.5f), Quaternion.Euler(90, 180, 0));
            icard.GetComponent<MinionScript>().setcardjob((HERO_TYPE)(i - 1));
            icard.GetComponent<MinionScript>().setcost(i + 4);
            icard.GetComponent<MinionScript>().setname("MinionC" + i);
            icard.GetComponent<MinionScript>().setatk(i + 4);
            icard.GetComponent<MinionScript>().setmax_HP(i + 4);
            MyHand[i] = icard;
        }
        */
        /*for (int i = 0; i < 3; i++)
        {
            GameObject newminion = (GameObject)Instantiate(Resources.Load("Minion"), new Vector3(0.95f, 1, -11.5f), Quaternion.Euler(90, 180, 0));
            newminion.GetComponent<Minion>().setifmy(false);
            newminion.GetComponent<Minion>().setatk(i + 2);
            newminion.GetComponent<Minion>().setHP(i + 4);
            OpMinionCount += 1;
            setOpMinions(i, newminion);
        }*/
    }



    // Update is called once per frame
    void Update()
    {
        switch (MyMinionCount)
        {
            case 1:
                MyMinions[0].transform.position = new Vector3(-(502.5f - 512) / 10, 1, 8.4f);
                break;
            case 2:
                MyMinions[0].transform.position = new Vector3(-(442.5f - 512) / 10, 1, 8.4f);
                MyMinions[1].transform.position = new Vector3(-(562.5f - 512) / 10, 1, 8.4f);
                break;
            case 3:
                MyMinions[0].transform.position = new Vector3(-(382.5f - 512) / 10, 1, 8.4f);
                MyMinions[1].transform.position = new Vector3(-(502.5f - 512) / 10, 1, 8.4f);
                MyMinions[2].transform.position = new Vector3(-(622.5f - 512) / 10, 1, 8.4f);
                break;
            case 4:
                MyMinions[0].transform.position = new Vector3(-(322.5f - 512) / 10, 1, 8.4f);
                MyMinions[1].transform.position = new Vector3(-(442.5f - 512) / 10, 1, 8.4f);
                MyMinions[2].transform.position = new Vector3(-(562.5f - 512) / 10, 1, 8.4f);
                MyMinions[3].transform.position = new Vector3(-(682.5f - 512) / 10, 1, 8.4f);
                break;
            case 5:
                MyMinions[0].transform.position = new Vector3(-(262.5f - 512) / 10, 1, 8.4f);
                MyMinions[1].transform.position = new Vector3(-(382.5f - 512) / 10, 1, 8.4f);
                MyMinions[2].transform.position = new Vector3(-(502.5f - 512) / 10, 1, 8.4f);
                MyMinions[3].transform.position = new Vector3(-(622.5f - 512) / 10, 1, 8.4f);
                MyMinions[4].transform.position = new Vector3(-(742.5f - 512) / 10, 1, 8.4f);
                break;
            case 6:
                MyMinions[0].transform.position = new Vector3(-(202.5f - 512) / 10, 1, 8.4f);
                MyMinions[1].transform.position = new Vector3(-(322.5f - 512) / 10, 1, 8.4f);
                MyMinions[2].transform.position = new Vector3(-(442.5f - 512) / 10, 1, 8.4f);
                MyMinions[3].transform.position = new Vector3(-(562.5f - 512) / 10, 1, 8.4f);
                MyMinions[4].transform.position = new Vector3(-(682.5f - 512) / 10, 1, 8.4f);
                MyMinions[5].transform.position = new Vector3(-(802.5f - 512) / 10, 1, 8.4f);
                break;
            case 7:
                MyMinions[0].transform.position = new Vector3(-(142.5f - 512) / 10, 1, 8.4f);
                MyMinions[1].transform.position = new Vector3(-(262.5f - 512) / 10, 1, 8.4f);
                MyMinions[2].transform.position = new Vector3(-(382.5f - 512) / 10, 1, 8.4f);
                MyMinions[3].transform.position = new Vector3(-(502.5f - 512) / 10, 1, 8.4f);
                MyMinions[4].transform.position = new Vector3(-(622.5f - 512) / 10, 1, 8.4f);
                MyMinions[5].transform.position = new Vector3(-(742.5f - 512) / 10, 1, 8.4f);
                MyMinions[6].transform.position = new Vector3(-(862.5f - 512) / 10, 1, 8.4f);
                break;
            default:
                break;
        }
        switch (OpMinionCount)
        {
            case 1:
                OpMinions[0].transform.position = new Vector3(-(502.5f - 512) / 10, 1, -11.5f);
                break;
            case 2:
                OpMinions[0].transform.position = new Vector3(-(442.5f - 512) / 10, 1, -11.5f);
                OpMinions[1].transform.position = new Vector3(-(562.5f - 512) / 10, 1, -11.5f);
                break;
            case 3:
                OpMinions[0].transform.position = new Vector3(-(382.5f - 512) / 10, 1, -11.5f);
                OpMinions[1].transform.position = new Vector3(-(502.5f - 512) / 10, 1, -11.5f);
                OpMinions[2].transform.position = new Vector3(-(622.5f - 512) / 10, 1, -11.5f);
                break;
            case 4:
                OpMinions[0].transform.position = new Vector3(-(322.5f - 512) / 10, 1, -11.5f);
                OpMinions[1].transform.position = new Vector3(-(442.5f - 512) / 10, 1, -11.5f);
                OpMinions[2].transform.position = new Vector3(-(562.5f - 512) / 10, 1, -11.5f);
                OpMinions[3].transform.position = new Vector3(-(682.5f - 512) / 10, 1, -11.5f);
                break;
            case 5:
                OpMinions[0].transform.position = new Vector3(-(262.5f - 512) / 10, 1, -11.5f);
                OpMinions[1].transform.position = new Vector3(-(382.5f - 512) / 10, 1, -11.5f);
                OpMinions[2].transform.position = new Vector3(-(502.5f - 512) / 10, 1, -11.5f);
                OpMinions[3].transform.position = new Vector3(-(622.5f - 512) / 10, 1, -11.5f);
                OpMinions[4].transform.position = new Vector3(-(742.5f - 512) / 10, 1, -11.5f);
                break;
            case 6:
                OpMinions[0].transform.position = new Vector3(-(202.5f - 512) / 10, 1, -11.5f);
                OpMinions[1].transform.position = new Vector3(-(322.5f - 512) / 10, 1, -11.5f);
                OpMinions[2].transform.position = new Vector3(-(442.5f - 512) / 10, 1, -11.5f);
                OpMinions[3].transform.position = new Vector3(-(562.5f - 512) / 10, 1, -11.5f);
                OpMinions[4].transform.position = new Vector3(-(682.5f - 512) / 10, 1, -11.5f);
                OpMinions[5].transform.position = new Vector3(-(802.5f - 512) / 10, 1, -11.5f);
                break;
            case 7:
                OpMinions[0].transform.position = new Vector3(-(142.5f - 512) / 10, 1, -11.5f);
                OpMinions[1].transform.position = new Vector3(-(262.5f - 512) / 10, 1, -11.5f);
                OpMinions[2].transform.position = new Vector3(-(382.5f - 512) / 10, 1, -11.5f);
                OpMinions[3].transform.position = new Vector3(-(502.5f - 512) / 10, 1, -11.5f);
                OpMinions[4].transform.position = new Vector3(-(622.5f - 512) / 10, 1, -11.5f);
                OpMinions[5].transform.position = new Vector3(-(742.5f - 512) / 10, 1, -11.5f);
                OpMinions[6].transform.position = new Vector3(-(862.5f - 512) / 10, 1, -11.5f);
                break;
            default:
                break;
        }
    }

    public void FixedPoint()
    {
        switch (MyHandCount)
        {
            case 1:
                MyHand[0].transform.position = new Vector3(0, 3, 30);
                break;
            case 2:
                MyHand[0].transform.position = new Vector3(-10, 3, 30);
                MyHand[1].transform.position = new Vector3(0, 3, 30);
                break;
            case 3:
                MyHand[0].transform.position = new Vector3(-10, 3, 30);
                MyHand[1].transform.position = new Vector3(0, 3, 30);
                MyHand[2].transform.position = new Vector3(10, 3, 30);
                break;
            case 4:
                MyHand[0].transform.position = new Vector3(-20, 3, 30);
                MyHand[1].transform.position = new Vector3(-10, 3, 30);
                MyHand[2].transform.position = new Vector3(0, 3, 30);
                MyHand[3].transform.position = new Vector3(10, 3, 30);
                break;
            case 5:
                MyHand[0].transform.position = new Vector3(-20, 3, 30);
                MyHand[1].transform.position = new Vector3(-10, 3, 30);
                MyHand[2].transform.position = new Vector3(0, 3, 30);
                MyHand[3].transform.position = new Vector3(10, 3, 30);
                MyHand[4].transform.position = new Vector3(20, 3, 30);
                break;
            case 6:
                MyHand[0].transform.position = new Vector3(-20, 3, 30);
                MyHand[1].transform.position = new Vector3(-10, 3, 30);
                MyHand[2].transform.position = new Vector3(0, 3, 30);
                MyHand[3].transform.position = new Vector3(10, 3, 30);
                MyHand[4].transform.position = new Vector3(20, 3, 30);
                MyHand[5].transform.position = new Vector3(30, 3, 30);
                break;

        }
    }
}