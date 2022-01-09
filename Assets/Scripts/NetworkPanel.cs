using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using TMPro;
using UnityEngine;

public class NetworkPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text pingField;
    [SerializeField] private TMP_Text networkField;
    
    void Update()
    {
        pingField.text = PhotonNetwork.GetPing().ToString();
        networkField.color = PhotonNetwork.IsConnected ? Color.green : Color.red;
    }
}
