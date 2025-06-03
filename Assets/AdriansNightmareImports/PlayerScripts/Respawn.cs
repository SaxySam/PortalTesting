using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private Transform Player;
    [SerializeField] private Transform respawnPoint;

    void OnTriggerEnter(Collider playerCol)
    {
        if (playerCol.gameObject.tag == "AdrianPlayer")
        {
            playerCol.gameObject.GetComponent<CharacterController>().enabled = false;
            Player.transform.position = respawnPoint.transform.position;
            playerCol.gameObject.GetComponent<CharacterController>().enabled = true;
        }

    }
}
