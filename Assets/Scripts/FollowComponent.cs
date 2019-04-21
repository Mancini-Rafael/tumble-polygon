using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowComponent : MonoBehaviour
{
    public Transform Player;
    public Vector3 CameraOffset = new Vector3(0, 2, -5);

    void Update()
    {
        Vector3 PlayerCurrentPosition = Player.position;

        transform.position = PlayerCurrentPosition + CameraOffset;
    }
}
