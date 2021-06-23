using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static bool paused;
    public GameObject player;
    public Transform rightPos, centerPos, leftPos;
    public float speed;
    public int posInt; // -1 : left; 0 : center; 1 : right;
    public bool needChangeLine;
    public Transform target;

    void Start()
    {
        needChangeLine = false;
        posInt = 0;
    }

    void Update()
    {
        if (!paused)
        {
            if ((Input.GetKeyDown(KeyCode.RightArrow)) && (posInt != 1))
            {
                print("Right!");
                if (!needChangeLine)
                {
                    if (posInt == 0)
                    {
                        posInt = 1;
                    }
                    else posInt = 0;
                    setTarget();
                }
                needChangeLine = true;
            }
            if ((Input.GetKeyDown(KeyCode.LeftArrow)) && (posInt != -1))
            {
                print("Left!");
                if (!needChangeLine)
                {
                    if (posInt == 0)
                    {
                        posInt = -1;
                    }
                    else posInt = 0;
                    setTarget();
                }
                needChangeLine = true;
            }
        }
    }

    void FixedUpdate()
    {
        if (!paused)
        {
            if (needChangeLine)
            {
                ChangeLine();
            }
            Move();
        }
    }

    void Move()
    {
        //player.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + speed * Time.deltaTime);
    }

    void setTarget()
    {
        if (posInt == -1)
        {
            target = leftPos;
        }
        else if (posInt == 0)
        {
            target = centerPos;
        }
        else
        {
            target = rightPos;
        }
        StartCoroutine(StopChangeLine());
    }

    void ChangeLine()
    {
        player.transform.position = Vector3.MoveTowards(player.transform.position, new Vector3(target.position.x, player.transform.position.y, player.transform.position.z), speed * Time.deltaTime);
        print("Moving...");
    }

    IEnumerator StopChangeLine()
    {
        yield return new WaitForSeconds(1);
        needChangeLine = false;
    }
}
