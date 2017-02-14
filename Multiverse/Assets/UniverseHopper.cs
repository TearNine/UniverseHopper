using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniverseHopper : MonoBehaviour
{
    public int direction = 1;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision c)
    {
        switch (c.gameObject.tag)
        {
            case "Wall":
                direction = -direction;
                rb.velocity = -rb.velocity * 2f;
                break;
            case "Ground":
                StartCoroutine(jump());
                break;
            default:
                break;
        }
    }

    IEnumerator jump()
    {
        yield return new WaitForSeconds(.5f);
        rb.AddForce(new Vector3(direction * 100, 200, 0));
    }
}
