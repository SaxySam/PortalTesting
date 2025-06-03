using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using WSWhitehouse.TagSelector;
using Image = UnityEngine.UI.Image;

public class PortalGunBehaviour : MonoBehaviour
{
    public InputActionReference primaryFire;
    public InputActionReference secondaryFire;
    [TagSelector] public string wallTag;
    [TagSelector] public string[] portalTags = {"PortalOne", "PortalTwo"};
    public GameObject portalOnePrefab;
    private GameObject spawnedPortalOne;
    public GameObject portalTwoPrefab;
    private GameObject spawnedPortalTwo;
    private List<GameObject> portalOneCount = new();
    private List<GameObject> portalTwoCount = new();
    private Image crosshair;
    private Color portalBlue = new Color(0, 0.753f, 1, 1);
    private Color portalOrange = new Color(1, 0.5f, 0, 1);


    void Awake()
    {
        gameObject.GetComponent<PortalGunBehaviour>().enabled = false;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        crosshair = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Image>();
        crosshair.color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        Ray portalCastRay = new Ray (transform.position, transform.forward);

        if (primaryFire.action.triggered && portalOnePrefab != null)
        {
            Debug.Log("Left Fire");

            if (Physics.Raycast(portalCastRay, out RaycastHit portalRayHit, 1000f))
            {
                Debug.DrawLine(portalCastRay.origin, portalRayHit.point, portalBlue);

                if (portalRayHit.collider.gameObject.CompareTag(wallTag))
                {
                    if (portalOneCount.Count != 0) //Spawn
                    {
                        Destroy(portalOneCount[0]); //Finding Existing Portal
                        portalOneCount.Clear();
                    }

                    spawnedPortalOne = GameObject.Instantiate(portalOnePrefab, portalRayHit.point, Quaternion.LookRotation(-portalRayHit.normal, Vector3.up));
                    crosshair.color = portalBlue;
                    portalOneCount.Add(spawnedPortalOne);
                }
            }
        }

        if (secondaryFire.action.triggered && portalTwoPrefab != null)
        {
            Debug.Log("Right Fire");

            if (Physics.Raycast(portalCastRay, out RaycastHit portalRayHit, 1000f))
            {
                Debug.DrawLine(portalCastRay.origin, portalRayHit.point, portalOrange);

                if (portalRayHit.collider.gameObject.CompareTag(wallTag))
                {

                    if (portalTwoCount.Count != 0) //Spawn
                    {
                        Destroy(portalTwoCount[0]); //Finding Existing Portal
                        portalTwoCount.Clear();
                    }
                    
                    spawnedPortalTwo = GameObject.Instantiate(portalTwoPrefab, portalRayHit.point, Quaternion.LookRotation(-portalRayHit.normal, Vector3.up));
                    crosshair.color = portalOrange;
                    portalTwoCount.Add(spawnedPortalTwo);
                }
            }
        }
    }
}
