using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public const byte RotationEventCode = 25;
    public const byte MovementEventCode = 26;

    [SerializeField] private float rotationSpeed = 20;
    [SerializeField] private float movingSpeed = 5;

    readonly RaiseEventOptions _raiseEventOptions = new RaiseEventOptions {Receivers = ReceiverGroup.All};

    private Rigidbody _rb;
    private PhotonView _view;

    void Start()
    {
        _view = GetComponent<PhotonView>();
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (!_view.IsMine) return;

        var hor = Input.GetAxis("Horizontal");
        var vert = Input.GetAxis("Vertical");

        var target = new Vector3(hor, vert);
        MoveToDirection(target);
    }

    private void OnMouseDrag()
    {
        if (!_view.IsMine) return;

        float rotationX = Input.GetAxis("Mouse X") * rotationSpeed * Mathf.Deg2Rad;
        float rotationY = Input.GetAxis("Mouse Y") * rotationSpeed * Mathf.Deg2Rad;

        var rotation = new Vector2(rotationX, rotationY);
        Rotate(rotation);
    }


    private void Rotate(Vector2 rotation)
    {
        transform.Rotate(Vector3.up, -rotation.x);
        transform.Rotate(Vector3.right, rotation.y);
    }

    private void MoveToDirection(Vector3 targetDirection)
    {
        _rb.AddForce(targetDirection * movingSpeed, ForceMode.Acceleration);
    }
}