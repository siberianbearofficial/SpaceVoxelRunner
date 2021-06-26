using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnvironment : MonoBehaviour
{
    public GameObject spawnRoadPos;
    public GameObject roadPrefab;
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            print("Destroy!");
            Destroy(other.gameObject);
            print("Spawn!");
            Instantiate(roadPrefab, spawnRoadPos.transform);
        }
    }
}
