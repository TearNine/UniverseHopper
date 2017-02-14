using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public enum portalType { normal, lowGravity, highGravity };
    public portalType type;



    void OnTriggerEnter(Collider c)
    {
        Rigidbody rb = c.gameObject.GetComponent<Rigidbody>();
        switch (type)
        {
            case portalType.normal:
                rb.mass = 1;
                break;
            case portalType.lowGravity:
                rb.mass = .45f;
                break;
            case portalType.highGravity:
                rb.mass = 50;
                break;
            default:
                break;
        }
        Destroy(gameObject);
    }
}
