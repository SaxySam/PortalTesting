using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using WSWhitehouse.TagSelector;

public class PickUpObject : MonoBehaviour
{
    [Header("Pickup Settings")]
    public InputActionReference pickupAction;
    [TagSelector] public string playerTag = "Player";
    [TagSelector] public string pickupTag = "CanPickUp";
    private GameObject playerObject;
    private GameObject heldObject;
    private Rigidbody heldObjectRB;
    private Material originalMaterial;
    private Color originalColour;
    private Color targetColour;
    public float pulseDuration = 1f;
    public Color pulseColour = Color.cyan;
    private float pulseTime;
    private bool shouldPulse;
    public Transform holdPosition;

    [Header("Physics Parameters")]
    public float pickupRange;
    public float pickupForce;
    public float forceAppliedOnDrop;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag(playerTag);
    }

    // Update is called once per frame
    void Update()
    {
        Ray objectRaycast = new Ray(transform.position, transform.TransformDirection(Vector3.forward));

        if (pickupAction.action.triggered || Input.GetKeyDown(KeyCode.E))
        {
            if (heldObject == null)
            {
                RaycastHit objectHit;

                if (Physics.Raycast(objectRaycast, out objectHit, pickupRange))
                {
                    Debug.DrawLine(objectRaycast.origin, objectHit.point, Color.grey);
                    if (objectHit.transform.gameObject.CompareTag(pickupTag))
                    {
                        PickUpObj(objectHit.transform.gameObject);
                    }
                }
            }
            else
            {
                DropObj();
            }

        }
        if (heldObject != null)
        {
            MoveObj();
        }

        if (shouldPulse)
        {
            pulseTime = Mathf.PingPong(Time.time, pulseDuration);
            heldObject.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", Color.Lerp(Color.black, targetColour, pulseTime));
        }
    }

    void PickUpObj(GameObject pickupObj)
    {
        originalMaterial = pickupObj.gameObject.GetComponent<MeshRenderer>().material;
        originalColour = originalMaterial.color;
        targetColour = originalColour * pulseColour;

        pickupObj.gameObject.GetComponent<MeshRenderer>().material.EnableKeyword("_EMISSION");
        shouldPulse = true;
        
        if (pickupObj.GetComponent<Rigidbody>())
        {
            heldObjectRB = pickupObj.GetComponent<Rigidbody>();
            heldObjectRB.useGravity = false;
            heldObjectRB.linearDamping = 10;
            heldObjectRB.constraints = RigidbodyConstraints.FreezeRotation;

            heldObjectRB.transform.parent = holdPosition;
            heldObject = pickupObj;
        }
    }

    void DropObj()
    {
        shouldPulse = false;
        heldObject.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", Color.black);
        heldObject.gameObject.GetComponent<MeshRenderer>().material.DisableKeyword("_EMISSION");

        targetColour = Color.black;
        originalColour = Color.black;
        originalMaterial = null;
        
        heldObjectRB.useGravity = true;
        heldObjectRB.linearDamping = 0;
        heldObjectRB.constraints = RigidbodyConstraints.None;
        
        heldObjectRB.AddForce(transform.forward * forceAppliedOnDrop, ForceMode.Impulse);

        heldObjectRB.transform.parent = null;
        heldObjectRB = null;
        heldObject = null;
    }

    void MoveObj()
    {
        if (Vector3.Distance(heldObject.transform.position, holdPosition.position) > 0.1f)
        {
            Vector3 moveDir = (holdPosition.position - heldObject.transform.position);
            heldObjectRB.AddForce(moveDir * pickupForce);
        }
    }
}

//!https://www.youtube.com/watch?v=6bFCQqabfzo
