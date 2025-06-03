using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorControl : MonoBehaviour
{
    private Transform mirrorTransform;
    private Vector3 mirrorOffset;

    // Start is called before the first frame update
    void Start()
    {
        mirrorTransform = GameObject.FindWithTag("MainCamera").GetComponent<Transform>();
        // mirrorOffset = mirrorTransform.eulerAngles - transform.rotation.eulerAngles;
        // mirrorOffset = mirrorTransform.eulerAngles - transform.rotation.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion mirrorRotation = Quaternion.Euler(mirrorTransform.rotation.eulerAngles * -1f);
        gameObject.transform.rotation = mirrorRotation;
    }
}
