using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WSWhitehouse.TagSelector;

public enum PortalNumber
{
    PortalOne,
    PortalTwo
}

public class PortalBehaviour : MonoBehaviour
{
    [TagSelector] public string playerTag = "Player";
    public PortalNumber portalNumber;
    [TagSelector] public string[] portalTags = {"PortalOne", "PortalTwo"};
    // public List<GameObject> portals;
    public GameObject otherPortal;
    private bool canTeleport = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.tag = portalTags[(int) portalNumber];
        
        if (portalNumber == PortalNumber.PortalOne)
        {
            gameObject.tag = portalTags[0];
        }
        else if (portalNumber == PortalNumber.PortalTwo)
        {
            gameObject.tag = portalTags[1];
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (portalNumber == PortalNumber.PortalOne)
        {
            otherPortal = GameObject.FindGameObjectWithTag(portalTags[1]);
        }
        else if (portalNumber == PortalNumber.PortalTwo)
        {
            otherPortal = GameObject.FindGameObjectWithTag(portalTags[0]);
        }
    }

    void OnTriggerEnter(Collider EnteredPortalObject)
    {
        if (canTeleport)
        {
            if (EnteredPortalObject.gameObject.CompareTag(playerTag))
            {
                EnteredPortalObject.GetComponent<CharacterController>().enabled = false;
                // EnteredPortalObject.transform.position = otherPortal.transform.position;
                EnteredPortalObject.transform.position = new Vector3 (otherPortal.transform.localPosition.x, otherPortal.transform.localPosition.y, otherPortal.transform.localPosition.z - 1);
                EnteredPortalObject.transform.rotation *= Quaternion.Euler(0, 180, 0);
                EnteredPortalObject.GetComponent<CharacterController>().enabled = true;
                EnteredPortalObject.GetComponent<Rigidbody>().AddForce(EnteredPortalObject.transform.forward, ForceMode.Impulse);
                Debug.Log("Teleported" + EnteredPortalObject.gameObject.name + " to " + otherPortal.name);
            }
        }
    }

    void OnTriggerStay(Collider EnteredPortalObject)
    {
        canTeleport = false;
    }

    void OnTriggerExit(Collider EnteredPortalObject)
    {
        canTeleport = true;
    }

}
