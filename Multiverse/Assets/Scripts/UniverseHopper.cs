using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniverseHopper : MonoBehaviour
{
    public int direction = 1, wowDirection = 1;
    Rigidbody rb;
    public bool walkOnWalls = false;
    public GameObject startButton;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void StartGame()
    {
        GetComponent<Rigidbody>().useGravity = true;
    }

    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.tag == "Goal")
        {
            Time.timeScale = 0;
            Camera.main.GetComponent<GameManager>().Win();
        }
        if (!walkOnWalls)
        {
            switch (c.gameObject.tag)
            {
                case "Vertical":
                    direction = -direction;
                    wowDirection = direction;
                    Vector3 tempVector = rb.velocity;
                    tempVector.x = -tempVector.x;
                    rb.velocity = tempVector;
                    break;
                case "Horizontal":
                    if (c.gameObject.transform.position.y < transform.position.y)
                    {
                        StartCoroutine(jump());
                    }
                    break;
                default:
                    break;
            }
        }
        else if (walkOnWalls)
        {
            switch (c.gameObject.tag)
            {
                case "Vertical":
                    if (c.gameObject.transform.position.x > transform.position.x)
                    {
                        Physics.gravity = new Vector3(9.8f, 0, 0);
                        wowDirection = direction;
                    }
                    else
                    {
                        Physics.gravity = new Vector3(-9.8f, 0, 0);
                        wowDirection = -direction;
                    }

                    StartCoroutine(jump());
                    break;
                case "Horizontal":
                    if (c.gameObject.transform.position.y > transform.position.y)
                    {
                        Physics.gravity = new Vector3(0, 9.8f, 0);
                        wowDirection = -direction;
                    }
                    else
                    {
                        Physics.gravity = new Vector3(0, -9.8f, 0);
                        wowDirection = direction;
                    }
                    StartCoroutine(jump());
                    break;
                default:
                    break;
            }
        }
    }

    IEnumerator jump()
    {
        yield return new WaitForSeconds(.25f);
        int tempDirection = 0;
        if (walkOnWalls)
        {
            tempDirection = wowDirection;
        }
        else
        {
            tempDirection = direction;
        }
        if (Physics.gravity.y != 0)
        {
            rb.AddForce(new Vector3(tempDirection * 100, 20.5f * Physics.gravity.y * -1, 0));
        }
        else if (Physics.gravity.x != 0)
        {
            rb.AddForce(new Vector3(20 * Physics.gravity.x * -1, tempDirection * 100, 0));
        }
    }
}
