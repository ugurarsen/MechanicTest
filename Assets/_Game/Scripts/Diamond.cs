using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    [HideInInspector] public DiamondSpawner diamondSpawner;
    public void OnDeactivate()
    {
        gameObject.SetActive(false);
    }

    public void OnSpawn()
    {
        gameObject.SetActive(true);

    }

    public void OnCreated()
    {
        OnDeactivate();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 3)
        {
            UIManager.S.CollectDiamond(10);
            diamondSpawner.SpawnDiamond();
            OnDeactivate();
        }
    }
}
