using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnvironment : MonoBehaviour
{
    public float speed;

    void FixedUpdate()
    {
        if (!Game.paused)
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - speed * Time.deltaTime);
    }
}
