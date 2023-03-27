using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Behaviour : MonoBehaviour
{
    [Header("Camera Settings")]
    [SerializeField] float cameraSpeed = 1f;
    Camera myCamera;
    bool canControl_Camera;

    [Header("Input Settings")]
    float mouseY;
    float mouseZ;
    

    void Start()
    {
        myCamera = GetComponent<Camera>();
        StartCoroutine(Enable_Camera_Movement());
    }

    IEnumerator Enable_Camera_Movement()
    {
        myCamera.transform.position = new Vector3(0f, -1.5f, -18f);
        yield return new WaitForSeconds(4f);
        canControl_Camera = true;
    }

    void LateUpdate()
    {
        if (canControl_Camera)
        {
            float mouseY = Input.GetAxis("Mouse Y");
            float mouseZ = Input.GetAxis("Mouse ScrollWheel");

            float cameraMoveDistance_Y = mouseY * cameraSpeed * Time.deltaTime;
            float cameraMoveDistance_Z = mouseZ * cameraSpeed * Time.deltaTime;

            myCamera.transform.position += new Vector3(0f, cameraMoveDistance_Y, cameraMoveDistance_Z);
        }
        
    }
}
