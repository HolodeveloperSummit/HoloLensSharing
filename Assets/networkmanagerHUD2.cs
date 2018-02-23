using UnityEngine.UI;


namespace UnityEngine.Networking
 
{
 
//[AddComponentMenu("Network/NetworkManagerHUD")]
 
[RequireComponent(typeof(NetworkManager))]
 
//[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
 
public class networkmanagerHUD2 : MonoBehaviour
 
{
 
  public NetworkManager manager;

public Text host;
public Text client;
public Text clientAddress;
public Text portNumber;
public Text stop;
public Text matchMaker;
public Text createMatchText;
public Text findMatchText;
public Text joinMatchText;


 
  // Runtime variable
 
  bool showServer = false;
 
 
  void Awake()
 
  {
 
   manager = GetComponent<NetworkManager>();
 
  }

void Start()
{
            ////manager.StartClient();
            //manager.StartMatchMaker();
            ////manager.matchMaker.CreateMatch("HoloLens Room", manager.matchSize, true, "", "", "", 0, 0, manager.OnMatchCreate);

            //manager.matchName = "surfacebook2";

            //manager.matchSize = (uint)match.currentSize;

            //manager.matchMaker.JoinMatch(match.networkId, "", "", "", 0, 0, manager.OnMatchJoined);

        }
 
 
  void Update()
 
  {

 
 
   if (!NetworkClient.active && !NetworkServer.active && manager.matchMaker == null)
 
   {
 
    if (Input.GetKeyDown(KeyCode.S))
 
    {
 
     manager.StartServer();
 
    }
 
    if (Input.GetKeyDown(KeyCode.H))
 
    {
 
     manager.StartHost();
 
    }
 
    if (Input.GetKeyDown(KeyCode.C))
 
    {
 
     manager.StartClient();
 
    }
 
   }
 
   if (NetworkServer.active && NetworkClient.active)
 
   {
 
    if (Input.GetKeyDown(KeyCode.X))
 
    { 
     manager.StopHost(); 
    }
 
   } 
 
   if (!NetworkClient.active && !NetworkServer.active && manager.matchMaker == null) 
   {
                host.text = "LAN Host(H)";          
                
                client.text = "LAN Client(C)";                
   }
 
   else 
   { 
    if (NetworkServer.active) 
    { 
     portNumber.text = "Server: port=" + manager.networkPort; 
    }
 
    if (NetworkClient.active) 
    {
                    clientAddress.text = "Client: address=" + manager.networkAddress; 
                        portNumber.text = " port=" + manager.networkPort;
 
    }
 
   } 
 
   if (NetworkClient.active && !ClientScene.ready) 
   { 
     ClientScene.Ready(manager.client.connection); 
 
     if (ClientScene.localPlayers.Count == 0) 
     { 
      ClientScene.AddPlayer(0); 
     } 
   } 
 
   if (NetworkServer.active || NetworkClient.active)
 
   {
                stop.text = "Stop (X)";   
   } 
   if (!NetworkServer.active && !NetworkClient.active)
 
   { 
    if (manager.matchMaker == null) 
    {
                    matchMaker.text = "Enable Match Maker (M)"; 
                     
    }
 
    else 
    { 
     if (manager.matchInfo == null) 
     { 
      if (manager.matches == null) 
      {
                            createMatchText.text = "Create Internet Match";
                            findMatchText.text = "Find Internet Match"; 
      } 
      else 
      { 
       foreach (var match in manager.matches) 
       {
                                joinMatchText.text = "Join Match:" + match.name;   
       }
 
      }
 
     }
 
 
 
    }
 
   }
 
  }

        public void createMatch()
        {
            manager.matchName = "hololensroom";
            manager.matchMaker.CreateMatch(manager.matchName, manager.matchSize, true, "", "", "", 0, 0, manager.OnMatchCreate);            
        }

        public void findMatch()
        {
            manager.matchMaker.ListMatches(0, 20, "", true, 0, 0, manager.OnMatchList);
        }

        public void joinMatch()
        {
            foreach (var match in manager.matches)
            {
                joinMatchText.text = "Join Match:" + match.name;

                manager.matchName = match.name;
                manager.matchSize = (uint)match.currentSize;
                manager.matchMaker.JoinMatch(match.networkId, "", "", "", 0, 0, manager.OnMatchJoined);
            }
        }

        public void stopHost()
        {
            manager.StopHost();
        }

        public void startMM()
        {
            manager.StartMatchMaker(); 
        }

        public void startH()
        {
            manager.StartHost();
        }

        public void startC()
        {
            manager.StartClient(); 
        }



    }

};


