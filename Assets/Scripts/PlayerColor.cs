using System;
using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using WebSocketSharp;
using Random = UnityEngine.Random;

public class PlayerColor : MonoBehaviour
{
    private Renderer _renderer;
    private PhotonView _view;

    // Start is called before the first frame update
    void Start()
    {
        _view = GetComponent<PhotonView>();
        _renderer = GetComponent<Renderer>();
    }

    private void OnMouseUpAsButton()
    {
        if (!_view.IsMine) return;
        SetRandomColor();
    }
    
    void SetRandomColor()
    {
        var color = Random.ColorHSV();
        if (PhotonNetwork.IsConnected)
        {
            _view.RPC(nameof(SetColor), RpcTarget.All, color);   
        }
    }

    [PunRPC]
    private void SetColor(Color color)
    {
        GetComponent<Renderer>().material.color = color;
    }

    public void SyncColor()
    {
        _view.RPC(nameof(SetColor), RpcTarget.AllBuffered, _renderer.material.color);
    }

}
