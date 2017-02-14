using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalManager : MonoBehaviour
{
    Portal.portalType selectedPortal = Portal.portalType.normal;

    public GameObject portalPrefab;

    void SelectNormalPortal()
    {
        selectedPortal = Portal.portalType.normal;
    }
    void SelectLowGravityPortal()
    {
        selectedPortal = Portal.portalType.lowGravity;
    }
    void SelectHighGravityPortal()
    {
        selectedPortal = Portal.portalType.highGravity;
    }

}
