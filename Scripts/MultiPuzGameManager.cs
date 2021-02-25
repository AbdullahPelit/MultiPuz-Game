using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class MultiPuzGameManager : MonoBehaviourPunCallbacks
{
    [SerializeField]
    GameObject playerPreFab;
    void Start()
    {
        if (PhotonNetwork.IsConnected)
        {
            if (playerPreFab != null)
            {
                PhotonNetwork.Instantiate(playerPreFab.name, new Vector3(0, 0, 0), Quaternion.identity);
            }
            

        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnJoinedRoom()
    {
        Debug.Log(PhotonNetwork.NickName + "joined to" + PhotonNetwork.CurrentRoom.Name);
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log(PhotonNetwork.NickName + "joined to " + PhotonNetwork.CurrentRoom.Name + " " + PhotonNetwork.CurrentRoom.PlayerCount);
    }
}
