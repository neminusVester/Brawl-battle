using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Transform _player;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        
    }


    void LateUpdate()
    {
        Vector3 camPos = transform.position;
        camPos.x = _player.position.x;
        camPos.z = _player.position.z -4.2f;

        transform.position = camPos;
    }
}
