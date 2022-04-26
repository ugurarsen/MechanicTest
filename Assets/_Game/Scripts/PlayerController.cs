using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : Singleton<PlayerController>
{
    [Range(1, 50)] [SerializeField] private float Speed = 3;
    public Rigidbody rb;


    public void OnGameStarted()
    {
        
    }
    
    
    public void Move(Vector3 dif)
    {
        float v = Mathf.Clamp(dif.magnitude/2f,0.2f,5f);
        rb.velocity = transform.forward * v * Speed;
        Rotate(dif);
    }

    void Rotate( Vector3 dif)
    {
        dif.x = dif.x * -1;
        Vector3 n = dif.normalized;
        float rot = (Mathf.Atan2(n.y, n.x) * Mathf.Rad2Deg)-90;
        transform.rotation = Quaternion.Euler(Vector3.up*rot);
    }
    
    public void StopRun()
    {
        rb.velocity = Vector3.zero;
    }


    

}
