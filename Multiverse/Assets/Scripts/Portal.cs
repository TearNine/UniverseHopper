using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public enum portalType { normal, lowGravity, highGravity, walkOnWalls };
    public portalType type;
    public List<Material> materialList;


    void OnTriggerEnter(Collider c)
    {
        Physics.gravity = new Vector3(0, -9.8f, 0);
        UniverseHopper temp = GameObject.FindGameObjectWithTag("Player").GetComponent<UniverseHopper>();
        temp.direction = temp.wowDirection;
        Rigidbody rb = c.gameObject.GetComponent<Rigidbody>();
        switch (type)
        {
            case portalType.normal:
                rb.mass = 1;
                c.gameObject.GetComponent<UniverseHopper>().walkOnWalls = false;
                break;
            case portalType.lowGravity:
                rb.mass = .45f;
                c.gameObject.GetComponent<UniverseHopper>().walkOnWalls = false;
                break;
            case portalType.highGravity:
                rb.mass = 50;
                c.gameObject.GetComponent<UniverseHopper>().walkOnWalls = false;
                break;
            case portalType.walkOnWalls:
                rb.mass = 1;
                c.gameObject.GetComponent<UniverseHopper>().walkOnWalls = true;
                break;
            default:
                break;
        }
        Destroy(gameObject);
    }

    public void UpdateVisuals()
    {
        gameObject.GetComponent<Renderer>().material = materialList[(int)type];
    }

}
