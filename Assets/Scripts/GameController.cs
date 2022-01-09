using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using WebSocketSharp;
using Random = UnityEngine.Random;

public class GameController : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject playerPrefab;

    [SerializeField] private float SpawnMinX = -5;
    [SerializeField] private float SpawnMaxX = 5;
    [SerializeField] private float SpawnMinY = -2;
    [SerializeField] private float SpawnMaxY = 2;

    private GameObject _player;

    void Start()
    {
        var position = Vector3.Lerp(
            new Vector3(SpawnMinX, SpawnMinY, 0),
            new Vector3(SpawnMaxX, SpawnMaxY, 0),
            Random.value);
        _player = PhotonNetwork.Instantiate(playerPrefab.name, position, Quaternion.identity);
    }

    public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
    {
        _player.GetComponent<PlayerColor>().SyncColor();
    }
}