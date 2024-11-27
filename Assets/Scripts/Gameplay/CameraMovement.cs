using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private float mouseSensitivity = 400f;
    public Transform playerBody;
    private float xRotation = 0f;

    void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        /*if (AbilitySelector.activeAbilitySelector)
        {
            return;
        }*/
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.unscaledDeltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.unscaledDeltaTime;

        xRotation -= mouseY;    
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);    //Look up and down
        playerBody.Rotate(Vector3.up * mouseX);     //Rotate left and right
    }
}
