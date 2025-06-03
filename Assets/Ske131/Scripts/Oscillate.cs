using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AxisOfOscillation
{
    X,
    Y,
    Z
}

public class Oscillate : MonoBehaviour
{
    public AxisOfOscillation axisOfOscillation;
    public float sineAmplitudeInMeters;
    public float frequencyInHertz;
    public float peroidInSeconds;
    //public bool startWithRandomOffset;
    private float tempValX;
    private float tempValY;
    private float tempValZ;
    private Vector3 tempPos;

    // Start is called before the first frame update
    void Start()
    {
        
        tempValX = transform.position.x;
        tempValY = transform.position.y;
        tempValZ = transform.position.z;

    }

    // Update is called once per frame
    void Update()
    {
        switch (axisOfOscillation)
        {
            case AxisOfOscillation.X:
            {
                tempPos.x = tempValX + sineAmplitudeInMeters * Mathf.Sin (Time.time * frequencyInHertz * Mathf.PI / peroidInSeconds);
                transform.position = tempPos;
                tempPos.y = tempValY;
                tempPos.z = tempValZ;
                break;
            }
            case AxisOfOscillation.Y:
            {
                tempPos.y = tempValY + sineAmplitudeInMeters * Mathf.Sin (Time.time * frequencyInHertz * Mathf.PI / peroidInSeconds);
                transform.position = tempPos;
                tempPos.x = tempValX;
                tempPos.z = tempValZ;
                break;
            }
            case AxisOfOscillation.Z:
            {
                tempPos.z = tempValZ + sineAmplitudeInMeters * Mathf.Sin (Time.time * frequencyInHertz * Mathf.PI / peroidInSeconds);
                transform.position = tempPos;
                tempPos.x = tempValX;
                tempPos.y = tempValY;
                break;
            }
        }
    }
}
