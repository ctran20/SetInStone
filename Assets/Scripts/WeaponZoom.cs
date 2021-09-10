using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera fpsCamera;
    [SerializeField] GameObject player;
    [SerializeField] float zoomedOutFOV = 60f;
    [SerializeField] float zoomedInFOV = 35f;
    [SerializeField] float zoomedOutSensitivity = 4f;
    [SerializeField] float zoomedInSensitivity = 2f;
    [SerializeField] float zoomedInMoveSpeed = 4f;
    [SerializeField] float zoomedOutMoveSpeed = 6f;

    RigidbodyFirstPersonController fpsController;

    private void Start()
    {
        fpsController = player.GetComponent<RigidbodyFirstPersonController>();
    }
     
    private void Update()
    {
        if(Input.GetMouseButtonDown(1)){
            fpsCamera.fieldOfView = zoomedInFOV;
            fpsController.mouseLook.XSensitivity = zoomedInSensitivity;
            fpsController.mouseLook.YSensitivity = zoomedInSensitivity;
            fpsController.movementSettings.ForwardSpeed = zoomedInMoveSpeed;
        }
        else if (Input.GetMouseButtonUp(1))
        {
            fpsCamera.fieldOfView = zoomedOutFOV;
            fpsController.mouseLook.XSensitivity = zoomedOutSensitivity;
            fpsController.mouseLook.YSensitivity = zoomedOutSensitivity;
            fpsController.movementSettings.ForwardSpeed = zoomedOutMoveSpeed;
        }
    }
}
