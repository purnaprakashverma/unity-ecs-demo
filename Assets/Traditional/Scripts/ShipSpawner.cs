using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSpawner : MonoBehaviour
{
    public GameObject shipPrefab;
    public int noOfShips = 5000;

    private void Start()
    {
        for (int i = 0; i < noOfShips; i++)
        {
            float x = UnityEngine.Random.Range(-100, 100);
            float z = UnityEngine.Random.Range(-100, 100);
            Vector3 position = new Vector3(x, 0, z);
            //var rotation = Quaternion.Euler(new Vector3(0, 45, 0));
            var instance = GameObject.Instantiate(shipPrefab,position,Quaternion.identity);
            var ship = instance.GetComponent<Ship>();
            ship.SetData(Random.Range(5, 20), Random.Range(3, 5), 0);
        }
    }
}