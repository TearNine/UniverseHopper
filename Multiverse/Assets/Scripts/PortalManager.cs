using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PortalManager : MonoBehaviour
{
    Portal.portalType selectedPortal = Portal.portalType.normal;
    bool selected = false;
    public GameObject portalPrefab;



    public void SelectNormalPortal()
    {
        selectedPortal = Portal.portalType.normal;
        selected = true;
    }
    public void SelectLowGravityPortal()
    {
        selectedPortal = Portal.portalType.lowGravity;
        selected = true;
    }
    public void SelectHighGravityPortal()
    {
        selectedPortal = Portal.portalType.highGravity;
        selected = true;
    }
    public void SelectWalkOnWallsPortal()
    {
        selectedPortal = Portal.portalType.walkOnWalls;
        selected = true;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && selected)
        {
            selected = false;
            Vector3 temp = Input.mousePosition;
            temp.z = 0 - Camera.main.transform.position.z;
            GameObject portal = Instantiate(portalPrefab, Camera.main.ScreenToWorldPoint(temp), Quaternion.identity);
            portal.GetComponent<Portal>().type = selectedPortal;
            portal.GetComponent<Portal>().UpdateVisuals();
            Camera.main.GetComponent<GameManager>().ExtraMove();
        }
    }


}
