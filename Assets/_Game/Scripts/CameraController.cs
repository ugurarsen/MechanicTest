using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 distance;
    void Update()
    {
        transform.position = target.transform.position + distance;
        transform.LookAt(target);
    }
}