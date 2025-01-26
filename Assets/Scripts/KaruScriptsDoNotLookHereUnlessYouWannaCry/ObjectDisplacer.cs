using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDisplacer : MonoBehaviour
{
    [SerializeField] private GameObject mcStandee;
    [SerializeField] private Transform target1;
    [SerializeField] private Transform target2;
    [SerializeField] private Transform target3;

    [SerializeField] private float movementSpeed = 1.0f;
    [SerializeField] private float smoothFactor = 0.1f;

    private int targetIndex = 0;
    private float lerpTime = 0f;

    private Vector3 cameraTargetPosition = new Vector3(-12f, 0f, 0f);
    [SerializeField] private Camera mainCamera;

    private float cameraMoveDuration = 30.0f;
    private float cameraLerpProgress = 0f;
    private bool isMovingCamera = false;

    void Start()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
    }

    void Update()
    {
        // Move the standee towards the current target
        Vector3 targetPosition = GetCurrentTargetPosition();
        lerpTime += Time.deltaTime * movementSpeed;

        mcStandee.transform.position = Vector3.Lerp(mcStandee.transform.position, targetPosition, lerpTime * smoothFactor);

        // Check if the standee has reached the current target
        if (Vector3.Distance(mcStandee.transform.position, targetPosition) < 0.1f)
        {
            targetIndex++;
            lerpTime = 0f;

            if (targetIndex == 3)
            {
                isMovingCamera = true;
            }
        }

        if (isMovingCamera)
        {
            SmoothMoveCamera();
        }
    }

    Vector3 GetCurrentTargetPosition()
    {
        switch (targetIndex)
        {
            case 0:
                return target1.position;
            case 1:
                return target2.position;
            case 2:
                return target3.position;
            default:
                return target3.position;
        }
    }

    void SmoothMoveCamera()
    {
        if (mainCamera != null)
        {
            cameraLerpProgress += Time.deltaTime / cameraMoveDuration;
            cameraLerpProgress = Mathf.Clamp01(cameraLerpProgress);

            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, cameraTargetPosition, cameraLerpProgress);

            mainCamera.transform.rotation = Quaternion.Lerp(mainCamera.transform.rotation, Quaternion.Euler(0, 90, 0), cameraLerpProgress);

            if (cameraLerpProgress >= 1.0f)
            {
                isMovingCamera = false; // Stop the camera movement
                cameraLerpProgress = 0f;
            }
        }
        else
        {
            Debug.LogWarning("No camera");
        }
    }
}

