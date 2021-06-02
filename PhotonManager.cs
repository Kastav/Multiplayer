using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PhotonManager : MonoBehaviourPunCallbacks
{

    //This script is just for connection to the room which is one big overall room.

    public GameObject player;
   
    

    public Clist clist;
    
    [SerializeField] private GameObject lobbycamera;
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
      
      

    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions { MaxPlayers = 20 }, TypedLobby.Default);
    }



    public override void OnJoinedRoom()
    {

        PhotonNetwork.Instantiate( "Player",new Vector3(Random.Range(6f,-5f), transform.position.y), Quaternion.identity);
        lobbycamera.SetActive(false);

    }
    

  

}

