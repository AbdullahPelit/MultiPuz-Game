using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;


public class LaunchManager : MonoBehaviourPunCallbacks
{
    public GameObject EnterGamePanel;
    public GameObject ConnectionStatusPanel;
    public GameObject LobbyPanel;
    public GameObject PieceSelectPanel;



    #region Unity Methods 
    private void Awake() {

        PhotonNetwork.AutomaticallySyncScene = true;
    
    
    }
    #endregion
    void Start()
    {
        EnterGamePanel.SetActive(true);
        ConnectionStatusPanel.SetActive(false);
        LobbyPanel.SetActive(false);
   
    }

    // Update is called once per frame
    void Update()
    {


        
    }

    public void ConnetToPhotonServer()
    {
        if (!PhotonNetwork.IsConnected)
        {
            PhotonNetwork.ConnectUsingSettings();
            ConnectionStatusPanel.SetActive(true);
            EnterGamePanel.SetActive(false);

        }
        

    }

    public void JoinRandomRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }


    public override void OnConnectedToMaster()
    {
        Debug.Log(PhotonNetwork.NickName+"Connected To Photon Server");
        LobbyPanel.SetActive(true);
        ConnectionStatusPanel.SetActive(false);
    }
    public override void OnConnected()
    {
        Debug.Log("Connected to Internet");
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        base.OnJoinRandomFailed(returnCode, message);
        Debug.Log(message);
        CreateAndJoinRoom();
    }

    public override void OnJoinedRoom()
    {
        Debug.Log(PhotonNetwork.NickName + "joined to " + PhotonNetwork.CurrentRoom.Name);
        PhotonNetwork.LoadLevel("GameScene");

    }
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log(newPlayer.NickName + "joined to" + PhotonNetwork.CurrentRoom.Name + " " + PhotonNetwork.CurrentRoom.PlayerCount);
    }

    #region private methods
    void CreateAndJoinRoom()
    {

        string randomRoomName = "Room" + Random.Range(0,1000000);
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.IsOpen = true;
        roomOptions.IsVisible = true;
        
        PhotonNetwork.CreateRoom(randomRoomName,roomOptions);

    }
    #endregion
}