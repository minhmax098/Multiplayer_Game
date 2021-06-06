using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class NetworkManagerScript : MonoBehaviour
{
    public Text TextInfos;

    public Transform SpawnPoint1; 

    public Transform SpawnPoint2; 


    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings("v01"); 
    }

    // Update is called once per frame
    void Update()
    {
        // TextInfos.text = PhotonNetwork.connectionStateDetailed.ToString(); 
        if(PhotonNetwork.connectionStateDetailed.ToString() != "Joined")
        {
            TextInfos.text = PhotonNetwork.connectionStateDetailed.ToString(); 

        }
        if(PhotonNetwork.connectionStateDetailed.ToString() != "Joined")
        {
            TextInfos.text = PhotonNetwork.connectionStateDetailed.ToString(); 
        }
        else 
        {
            TextInfos.text = " Connected to " + PhotonNetwork.room.Name + " Player(s) Online: " + PhotonNetwork.room.PlayerCount; 

        }
    }

    void OnConnectedToMaster()
    {
        Debug.Log("Connected with Master"); 
        PhotonNetwork.JoinLobby(); 
    }

    // Bước 3: Join vô cái Lobby 
    void OnJoinedLobby()
    {
        RoomOptions MyRoomOptions = new RoomOptions(); 
        MyRoomOptions.MaxPlayers = 2; 
        PhotonNetwork.JoinOrCreateRoom("Room1", MyRoomOptions, TypedLobby.Default);
        Debug.Log("Connected with Lobby"); 
    
    }

    // Bước 4: Join vô room 
    void OnJoinedRoom()
    {
        if(PhotonNetwork.playerList.Length > 1)
        {
            StartCoroutine(SpawnMyPlayer());
        }
        else
        {
            StartCoroutine(SpawnMyPlayer2()); 
        }
    }

    IEnumerator SpawnMyPlayer()
    {
        yield return new WaitForSeconds(1); 
        GameObject MyPlayer = PhotonNetwork.Instantiate("Tank", SpawnPoint1.position, Quaternion.identity, 0); 
    }

    IEnumerator SpawnMyPlayer2()
    {
        yield return new WaitForSeconds(1); 
        GameObject MyPlayer = PhotonNetwork.Instantiate("Tank",SpawnPoint2.position, Quaternion.identity, 0);

    }
}
