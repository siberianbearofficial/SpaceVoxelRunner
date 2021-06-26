using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static bool paused;
    public GameObject player;
    public Transform rightPos, centerPos, leftPos;
    public float lrSpeed;
    public float jumpForce;
    public float jumpCoef;
    private int posInt; // -1 : left; 0 : center; 1 : right;
    private bool needChangeLine;
    private Transform target;
    public bool isGrounded;
    private bool needJump;

    public int coins;

    void Start()
    {
        coins = 0;
        needChangeLine = false;
        posInt = 0;
        needJump = false;
        CoinsTextScript.UpdateUI(coins);
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
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (isGrounded)
                {
                    needJump = true;
                    StartCoroutine(StopJump());
                }
            }
            if (player.transform.position.x < leftPos.position.x)
            {
                player.transform.position = new Vector3(leftPos.position.x, player.transform.position.y, player.transform.position.z);
            }
            if (player.transform.position.x > rightPos.position.x)
            {
                player.transform.position = new Vector3(rightPos.position.x, player.transform.position.y, player.transform.position.z);
            }
            if (player.transform.position.z > 1 || player.transform.position.z < 1)
            {
                player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, 1);
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
            if (needJump)
            {
                Jump();
            }
        }
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
        player.transform.position = Vector3.MoveTowards(player.transform.position, new Vector3(target.position.x, player.transform.position.y, player.transform.position.z), lrSpeed * Time.deltaTime);
        print("Moving...");
    }

    void Jump()
    {
        player.transform.position = Vector3.MoveTowards(player.transform.position, new Vector3(player.transform.position.x, player.transform.position.y + jumpForce * jumpCoef, player.transform.position.z), jumpForce * Time.deltaTime); ;
    }

    IEnumerator StopChangeLine()
    {
        yield return new WaitForSeconds(0.3f);
        needChangeLine = false;
    }
    
    IEnumerator StopJump()
    {
        yield return new WaitForSeconds(0.3f);
        needJump = false;
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            coins++;
            CoinsTextScript.UpdateUI(coins);
        }
    }
}
