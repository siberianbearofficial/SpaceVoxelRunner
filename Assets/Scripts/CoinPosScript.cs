using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPosScript : MonoBehaviour
{
    public GameObject coinPrefab;
    
    void Start()
    {
        print("Should be generated!");
        if (randBool())
        {
            GameObject coin = Instantiate(coinPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            coin.transform.SetParent(transform);
            print("Should be instantiated!");
        }
    }

    bool randBool()
    {
        int randInt = Random.Range(0, 2);
        print(randInt);
        return randInt == 1;
    }
}
