using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        if (!PhotonNetwork.IsConnected)
        {
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    public override void OnConnectedToMaster()
    {
        ColorSerializer.RegisterType();
        PhotonNetwork.JoinRandomOrCreateRoom(roomOptions: new RoomOptions
        {
            MaxPlayers = 4,
            PublishUserId = true
        });
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Main map");
    }
}
