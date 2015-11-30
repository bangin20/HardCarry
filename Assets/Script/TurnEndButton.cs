using UnityEngine;
using System.Collections;

public class TurnEndButton : MonoBehaviour {
    public Material[] TurnMat;
    public bool myturn = true;
    int turn = 1;

    private void OnConnectedToServer()
    {
        int rand = Random.Range(-1, 2);
        turn = 1;
        if (rand == 0)
        {
            myturn = false;
            turn = 0;
        }
        this.GetComponent<NetworkView>().RPC("setTurn", RPCMode.Others,!myturn);

        for (int i = turn+1; i <= 10; i++)
        {
            GameObject invisible_mana = GameObject.Find("manacost" + i);
            Color manaColor = invisible_mana.GetComponent<Renderer>().material.color;
            manaColor.a = 0;
            invisible_mana.GetComponent<Renderer>().material.color = manaColor;
        }
    }

    private void OnServerInitialized()
    {
        turn = 1;
        for (int i = 2; i <= 10; i++)
        {
            GameObject invisible_mana = GameObject.Find("manacost" + i);
            Color manaColor = invisible_mana.GetComponent<Renderer>().material.color;
            manaColor.a = 0;
            invisible_mana.GetComponent<Renderer>().material.color = manaColor;
        }
    }

    public Material[] ManaStatus;

    private void OnMouseEnter()
    {
        if(myturn)
            this.GetComponent<Renderer>().material = TurnMat[1];
    }
    private void OnMouseExit()
    {
        this.GetComponent<Renderer>().material = TurnMat[0];
    }

    private void OnMouseDown()
    {
        if (myturn)
        {
            this.GetComponent<Renderer>().material = TurnMat[2];
            myturn = !myturn;
            //GameObject.Find("OPMana").GetComponent<OPManacontrol>().SetManaturn(turn);
            this.GetComponent<NetworkView>().RPC("setTurn", RPCMode.Others,!myturn);
            this.GetComponent<NetworkView>().RPC("Draw", RPCMode.Others);
            if(turn <= 10)
                this.GetComponent<NetworkView>().RPC("TurnEnd", RPCMode.Others);
            // socket send message
        }
    }

    public int getTurn()
    {
        return turn;
    }

    [RPC]
    void setTurn(bool b)
    {
        if (Network.isServer && b == false && turn == 1)
            turn = 0;
        myturn = b;
    }
    [RPC]
    void TurnEnd()
    {
           turn++;
            string manaTime = "manacost" + turn;
            Debug.Log(manaTime);
            GameObject m = GameObject.Find(manaTime);

            Color manaColor = m.GetComponent<Renderer>().material.color;
            manaColor.a = 1.0f;
            m.GetComponent<Renderer>().material.color = manaColor;

            m.GetComponent<Renderer>().material = ManaStatus[1];
    }

    [RPC]
    void Draw()
    {
        GameObject new_card = (GameObject)Instantiate(Resources.Load("FalseCard"), new Vector3(-45f, 3.13f, 10.59f), Quaternion.Euler(0, 90, 0));
        StartCoroutine(wait(1.5f));
    }

    IEnumerator wait(float t)
    {
        yield return new WaitForSeconds(t);
        
        Player player = GameObject.FindWithTag("MainCamera").GetComponent<Player>();

        GameObject card = (GameObject)Instantiate(Resources.Load("Card"), new Vector3(0, 3, 30), Quaternion.Euler(90, 180, 0));


        player.setMyHand(player.getMyHandCount(), card);

        player.setMyHandCount(player.getMyHandCount() + 1);
        player.FixedPoint();
    }
}