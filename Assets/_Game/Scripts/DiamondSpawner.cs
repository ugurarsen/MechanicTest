using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class DiamondSpawner : MonoBehaviour
{
    public Transform startPoint, endPoint;
    public Diamond diamondPrefab; 
    private Diamond _diamond; 

    private void Start()
    {
        _diamond = Instantiate(diamondPrefab);
        _diamond.diamondSpawner = this;
        _diamond.OnCreated();
        SpawnDiamond();
    }

    public void SpawnDiamond()
    {
        StartCoroutine(WaitAndSpawn(Random.Range(0.1f, 3f)));
    }

    private IEnumerator WaitAndSpawn(float second)
    {
        yield return new WaitForSeconds(second);
        TransformRandomizer();
        if (Distance() > 5f)
        {
            Spawn();
        }
        else
        {
            StartCoroutine(WaitAndSpawn(0f));
            Debug.Log("TekrarÜret");
        }
    }

    public void TransformRandomizer()
    {
        Vector3 tempSpawnPoint = new Vector3(Random.Range(startPoint.position.x,endPoint.position.x),_diamond.transform.position.y,Random.Range(startPoint.position.z,endPoint.position.z));
        _diamond.transform.position = tempSpawnPoint;
    }

    public float Distance()
    {
        return Vector3.Distance(_diamond.transform.position, PlayerController.S.transform.position);
    }

    public void Spawn()
    {
        Vector3 tempSpawnPoint = new Vector3(Random.Range(startPoint.position.x,endPoint.position.x),_diamond.transform.position.y,Random.Range(startPoint.position.z,endPoint.position.z));
        _diamond.transform.position = tempSpawnPoint;
        _diamond.OnSpawn();
    }

}
