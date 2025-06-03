using UnityEngine;

public enum CameraMode
{
    FirstPerson,
    ThirdPerson
};
public class SwitchCamera : MonoBehaviour
{
    public Camera mainCamera;
    public CameraMode cameraMode;

    public Transform firstPersonCamPos;
    public Transform thirdPersonCamPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCamera = Camera.main;
        cameraMode = CameraMode.FirstPerson;
        mainCamera.transform.position = firstPersonCamPos.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (cameraMode == CameraMode.FirstPerson)
            {
                mainCamera.transform.position = thirdPersonCamPos.transform.position;
                cameraMode = CameraMode.ThirdPerson;
            }

            else if (cameraMode == CameraMode.ThirdPerson)
            {
                mainCamera.transform.position = firstPersonCamPos.transform.position;
                cameraMode = CameraMode.FirstPerson;
            }
        }
    }
}
