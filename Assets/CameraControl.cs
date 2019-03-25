using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.CrossPlatformInput.PlatformSpecific;

using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float RotationSpeed = 1.0f;
    public float SmoothFactor = 1.0f;
    public Transform PlayerTransform;
    private Vector3 _cameraOffset;

    private bool isColliding = false;


    // Use this for initialization
    void Start()
    {
        _cameraOffset = transform.position - PlayerTransform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        isColliding = true;
    }
    private void OnTriggerExit(Collider other)
    {
        isColliding = false;
    }

    private void OnTriggerStay(Collider other)
    {
        isColliding = true;
    }
    private void LateUpdate()
    {
       if(!isColliding)
        {
            Quaternion camTurnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * RotationSpeed, Vector3.up);
            Quaternion camPitchAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * RotationSpeed, Vector3.left);
            
            _cameraOffset = camTurnAngle * _cameraOffset;
            _cameraOffset = camPitchAngle * _cameraOffset;
        } else{
            Quaternion camTurnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * RotationSpeed, Vector3.down);
            Quaternion camPitchAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * RotationSpeed, Vector3.right);

            _cameraOffset = camTurnAngle * _cameraOffset;
            _cameraOffset = camPitchAngle * _cameraOffset;
        }

        //float zoom = UnityStandardAssets.CrossPlatformInput.CrossPlatformInputManager.GetAxis("MouseScrollWheel");

        /*if (Input.GetAxis("MouseScrollWheel") > 0)
        {
            GetComponent<Camera>().fieldOfView++;
        } else if(Input.GetAxis("MouseScrollWheel") < 0)
        {
            GetComponent<Camera>().fieldOfView--;
        }*/
       

       // _cameraOffset = zoom * _cameraOffset;

        Vector3 newPos = PlayerTransform.position + _cameraOffset;
        transform.position = Vector3.Slerp(transform.position, newPos, SmoothFactor);
        transform.LookAt(PlayerTransform);
    }


   
}
