using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_control : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Vector3 pos;

    private void Update()
    {
        transform.position = player.transform.position -pos;
    }
}
