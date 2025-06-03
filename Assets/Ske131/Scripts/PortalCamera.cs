/*
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using RenderPipeline = UnityEngine.Rendering.RenderPipeline;

public class PortalCamera : MonoBehaviour
{

    [SerializeField]
    private List<Portal> portals = new(2);

    [SerializeField]
    private Camera portalCamera;

    [SerializeField]
    [Range(1, 12)] public int recursions = 7;

    private RenderTexture portalOneRenderTexture;
    private RenderTexture portalTwoRenderTexture;

    private Camera mainCamera;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        mainCamera = Camera.main;

        portalOneRenderTexture = new RenderTexture(Screen.width, Screen.height, 32, RenderTextureFormat.ARGB32);
        portalTwoRenderTexture = new RenderTexture(Screen.width, Screen.height, 32, RenderTextureFormat.ARGB32);
    }

    void Start()
    {
        portals[0].Renderer.material.mainTexture = portalOneRenderTexture;
        portals[1].Renderer.material.mainTexture = portalTwoRenderTexture;
    }

    void OnEnable()
    {
        RenderPipelineManager.beginCameraRendering += UpdateCamera;
    }

    void OnDisable()
    {
        RenderPipelineManager.beginCameraRendering -= UpdateCamera;
    }

    void UpdateCamera(ScriptableRenderContext SRC, Camera camera)
    {
        if (!portals[0].IsPlaced || !portals[1].IsPlaced)
        {
            return;
        }

        if (portals[0].Renderer.isVisible)
        {
            portalCamera.targetTexture = portalOneRenderTexture;
            for (int i = recursions - 1; i > 0; i--)
            {
                RenderCamera(portals[0], portals[1], i, SRC);
            }
        }

        if (portals[1].Renderer.isVisible)
        {
            portalCamera.targetTexture = portalTwoRenderTexture;
            for (int i = recursions - 1; i > 0; i--)
            {
                RenderCamera(portals[1], portals[0], i, SRC);
            }
        }
    }

    private void RenderCamera(Portal inPortal, Portal outPortal, int iterationID, ScriptableRenderContext SRC)
    {
        Transform inTransform = inPortal.transform;
        Transform outTransform = outPortal.transform;

        Transform cameraTransform = portalCamera.transform;
        cameraTransform.position = transform.position;
        cameraTransform.rotation = transform.rotation;

        for (int i = 0; i <= iterationID; ++i)
        {
            Vector3 relativePosition = inTransform.InverseTransformPoint(cameraTransform.position);
            relativePosition = Quaternion.Euler(0, 180, 0) * relativePosition;
            cameraTransform.position = outTransform.TransformPoint(relativePosition);

            Quaternion relativeRotation = Quaternion.Inverse(inTransform.rotation) * cameraTransform.rotation;
            relativeRotation = Quaternion.Euler(0, 180, 0) * relativeRotation;
            cameraTransform.rotation = outTransform.rotation * relativeRotation;

            Plane obliqueClipPlane = new Plane(-outTransform.forward, outTransform.position);
            Vector4 clipPlaneWorldSpace = new Vector4(obliqueClipPlane.normal.x, obliqueClipPlane.normal.y, obliqueClipPlane.normal.z, obliqueClipPlane.distance);
            Vector4 clipPlaneCameraSpace = Matrix4x4.Transpose(Matrix4x4.Inverse(portalCamera.worldToCameraMatrix)) * clipPlaneWorldSpace;

            var newMarrix = mainCamera.CalculateObliqueMatrix(clipPlaneCameraSpace);
            portalCamera.projectionMatrix = newMarrix;

            // UniversalRenderPipeline.RenderSingleCamera(SRC, portalCamera);
            UniversalRenderPipeline.SubmitRenderRequest(portalCamera, SRC);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

//!https://www.youtube.com/watch?v=PkGjYig8avo
//!https://www.youtube.com/watch?v=cuQao3hEKfs
//!https://www.reddit.com/r/Unity3D/comments/elj8sn/how_i_made_my_seamless_portals/
//!https://www.reddit.com/r/videos/comments/12cnp8t/seamless_3rd_person_portals_in_unity3d/
//!https://www.youtube.com/watch?v=D7cTPZAbAfw
//!https://www.youtube.com/watch?v=KjG4fDTWOHA

*/