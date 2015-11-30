using UnityEngine;
using System.Collections;

public class GUISetting : MonoBehaviour {
    public Rect Myposition = new Rect(145, 490, 150, 150);
	public Rect OPposition = new Rect (154, 105, 120, -120);
    public GUISkin Myskin = null;
    public GUISkin Opskin = null;
    public Texture2D  texture= null;
    public string IP = "127.0.0.1";
    public int portNum = 8899;

    private bool hosted = false;
    private bool connected = false;
    private NetworkConnectionError errno;
    private bool failed = false;
    private bool setted = false;

    GameObject Myhero;
    GameObject MyAbil;
    GameObject MyHP;
    GameObject Ophero;
    GameObject OpHP;
    GameObject OpAbil;

    // GameObject Card[30];

    private void OnServerInitialized()
    {
        hosted = true;
    }

    void Start()
    {
        MyAbil = GameObject.Find("MyHero");
        OpAbil = GameObject.Find("OpHero");
        Myhero = (GameObject)Instantiate(Resources.Load("Hero"), new Vector3((Screen.width) / 100 - 10f, 0, (Screen.height) / 100 + 17.85f), Quaternion.identity);
        MyAbil.GetComponent<Renderer>().material = (Material)Resources.Load(Myhero.GetComponent<MyHeroScript>().MyHero.getType().ToString() + "AbilityMaterial");
        MyHP = (GameObject)Instantiate(Resources.Load("HeroHP"), new Vector3(-3.5f, 1f, 28.2f), Quaternion.identity);
        MyHP.transform.Rotate(new Vector3(90, 180, 0));
    }

    private void OnConnectedToServer()
    {
        connected = true;

        string hero = Myhero.GetComponent<MyHeroScript>().MyHero.getType().ToString();

        gameObject.GetComponent<NetworkView>().RPC("setHero", RPCMode.Others,hero);
    }

    void OnPlayerConnected()
    {
        string hero_type = Myhero.GetComponent<MyHeroScript>().MyHero.getType().ToString();

        gameObject.GetComponent<NetworkView>().RPC("setHero", RPCMode.Others, hero_type);
    }

    private void OnFailedToConnect(NetworkConnectionError error)
    {
        errno = error;
        failed = true;
    }

    public void OnGUI()
    {

        /*
        Myposition.x = Screen.width / 2 - 62;
        OPposition.x = Screen.width / 2 - 64;
        Myposition.y = Screen.height / 2 + 205;
        OPposition.y = Screen.height / 2 - 350;
        */
        if (hosted)
        {
            GUILayout.Label("I made Server !!!!!!!!");
            GUILayout.Label(Myhero.transform.position.x + "," + Myhero.transform.position.y + "," + Myhero.transform.position.z);
            GUILayout.Label(MyHP.transform.position.x + "," + MyHP.transform.position.y + "," + MyHP.transform.position.z);
            GUILayout.Label(Input.mousePosition.x + "," + Input.mousePosition.y);
            /*
            GUI.skin = Myskin;
            GUI.Button(Myposition, texture);
            GUI.skin = Opskin;
            GUI.Button(OPposition, texture);
            */
        }
        else if (connected)
        {
            
            GUILayout.Label("I Connected to server !!");
            /*
            GUI.skin = Myskin;
            GUI.Button(Myposition, texture);
            GUI.skin = Opskin;
            GUI.Button(OPposition, texture);
            */
        }
        else if (failed)
            GUILayout.Label("Connection Failed : " + errno);
        else
        {
            IP = GUILayout.TextField(IP);
            int.TryParse(GUILayout.TextField(portNum.ToString()), out portNum);

            if (GUILayout.Button("Connect"))
                Network.Connect(IP, portNum);

            if (GUILayout.Button("Host"))
                Network.InitializeServer(2, portNum, true);
        }
    }



    [RPC]
    void setHero(string op)
    {
        Ophero = (GameObject)Instantiate(Resources.Load("Hero"), new Vector3(0, 0, -28.35f), Quaternion.identity);
        MyHP = (GameObject)Instantiate(Resources.Load("HeroHP"), new Vector3(3.5f, 1f, -32.2f), Quaternion.identity);
        MyHP.transform.Rotate(new Vector3(90, 0, 0));
        Ophero.transform.Rotate(new Vector3(0, 180, 0));

        if (op == "CSE")
        {
            Ophero.GetComponent<MyHeroScript>().MyHero.setType(HERO_TYPE.CSE);
        }
        else if (op == "CITE")
        {
            Ophero.GetComponent<MyHeroScript>().MyHero.setType(HERO_TYPE.CITE);
        }
        else if (op == "EE")
        {
            Ophero.GetComponent<MyHeroScript>().MyHero.setType(HERO_TYPE.EE);
        }
        else
        {
            Ophero.GetComponent<MyHeroScript>().MyHero.setType(HERO_TYPE.PHYS);
        }
        OpAbil.GetComponent<Renderer>().material = (Material)Resources.Load(op + "AbilityMaterial");
        Ophero.GetComponent<MyHeroScript>().ChangePicture();
    }
}
