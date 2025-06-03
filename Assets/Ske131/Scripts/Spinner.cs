using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    public GameObject theSpin;
    
    [Range (0, 180f)]
    public float xOffsetRange;
    
    [Range (0, 180f)]
    public float yOffsetRange;
    
    [Range (0, 180f)]
    public float zOffsetRange;
    public Vector3 rotateAmmount;

    // Start is called before the first frame update
    void Start()
    {
        theSpin = this.gameObject;

        theSpin.transform.Rotate(Random.Range(0, xOffsetRange), Random.Range(0, yOffsetRange), Random.Range(0, zOffsetRange));
    }
    
    void Update()
    {
        transform.Rotate(rotateAmmount * Time.deltaTime);
    }

}
