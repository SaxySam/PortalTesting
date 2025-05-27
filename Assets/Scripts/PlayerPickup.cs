using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnTriggerEnter(Collider pickupCollider)
    {
        if (pickupCollider.gameObject.tag.Equals("Player"))
        {
            Debug.Log("Grab");
            Destroy(gameObject.GetComponent<Spinner>());
            Destroy(gameObject.GetComponent<Oscillate>());
            gameObject.transform.SetParent(pickupCollider.gameObject.transform.Find("PlayerCamera").Find("RHAttatchPoint"));
            pickupCollider.gameObject.transform.Find("PlayerCamera").GetComponent<PickUpObject>().pickupRange = 7.5f;
            pickupCollider.gameObject.transform.Find("PlayerCamera").GetComponent<PickUpObject>().forceAppliedOnDrop = 10;
            gameObject.transform.localPosition = Vector3.zero;
            gameObject.transform.localRotation = Quaternion.Euler(Vector3.zero);
            gameObject.GetComponent<PortalGunBehaviour>().enabled = true;
            Destroy(gameObject.GetComponent<BoxCollider>());
            Destroy(gameObject.GetComponent<PlayerPickup>());
        }
    }
}
